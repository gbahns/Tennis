using System;
using System.Collections.Generic;
using System.Text;
using Csla;
using log4net;
using Bahns.Data;
using Csla.Validation;


namespace TennisObjects
{
	[Serializable()]
	public class MatchScore : BusinessBase<MatchScore>
	{

		private static ILog log = LogManager.GetLogger(typeof(MatchScore).ToString());

		/// <summary> 
		/// MatchSet represents a single set from a match score. 
		/// </summary> 
		/// <remarks> 
		/// MatchSet can be used to represent a match score in one of two ways: objectively and subjectively. 
		/// 
		/// When used objectively, WGames and LGames represent the number of games won by the winner and loser, 
		/// respectively. In this case, WGames is interpreted as "winner games won" (games won in this set by 
		/// the winner of the match), and LGames is "loser games won". 
		/// 
		/// When used subjectively, WGames and LGames represent the number of games won and lost 
		/// by a specific player. In this case, WGames and LGames are interpreted as "games won and lost by the 
		/// player the player whose record is being retrieved". 
		/// 
		/// MatchSet does not know which way it is being used, as it does not contain any information about the 
		/// players. It is up to the parent class to know which way it is using MatchSet. 
		/// 
		/// Note that WGames and LGames are named with just 'W' and 'L' in order 
		/// </remarks> 
		[Serializable()]
		public class MatchSet : BusinessBase<MatchSet>
		{
			private byte _WGames;
			private byte _LGames;
			private byte _WTiebreak;
			private byte _LTiebreak;
			private int _SetNumber;
			private MatchScore _parent;

			internal void MatchScore_Saved(object sender, Csla.Core.SavedEventArgs e)
			{
				//MatchScore parent = (MatchScore)e.NewObject;
				MarkOld();
			}

			internal MatchSet(int setNumber, MatchScore parent)
			{
				_SetNumber = setNumber;
				_parent = parent;
			}

			//if the tiebreak was played, the winner of the tiebreak must also be the winner of the set 
			//todo: this rule is not true if the loser defaulted the match during the tiebreak 
			//in this case the game score would be tied, and the tiebreak score could be anything 
			private bool IsScoreValid()
			{
				if (TiebreakPlayed && _WGames != _LGames)
				{
					return Math.Sign(_WGames.CompareTo(_LGames)) == Math.Sign(_WTiebreak.CompareTo(_LTiebreak));
				}
				return true;
			}

			public bool ValidSetScore(object target, RuleArgs e)
			{
				if (!_parent.LoserDefaulted && TiebreakPlayed)
				{
					e.Description = string.Format("The set {0} winner must have won the tiebreak.", _SetNumber);
					return Math.Sign(_WGames.CompareTo(_LGames)) == Math.Sign(_WTiebreak.CompareTo(_LTiebreak));
				}

				//commented out because the parent is responsible for checking the overall match score
				//i.e. the parent calls AddInstanceBusinessRule to register ValidMatchScore, so we don't
				//     need to call it here
				//return _parent.ValidMatchScore(_parent, e);
				return true;
			}

			protected override void AddBusinessRules()
			{
				//ValidationRules.AddRule(IsScoreValid, "WGames");
				//ValidationRules.AddRule(CommonRules.StringRequired, new RuleArgs("FirstName", "First name"));
				//ValidationRules.AddRule(CommonRules.StringRequired, new RuleArgs("LastName", "Last name"));

				ValidationRules.AddDependantProperty("WGames", "LGames", true);
				ValidationRules.AddDependantProperty("WGames", "WTiebreak", true);
				ValidationRules.AddDependantProperty("WGames", "LTiebreak", true);
			}

			protected override void AddInstanceBusinessRules()
			{
				ValidationRules.AddInstanceRule(ValidSetScore, "WGames");
				//ValidationRules.AddInstanceRule(ValidSetScore, "LGames");
				//ValidationRules.AddInstanceRule(ValidSetScore, "WTiebreak");
				//ValidationRules.AddInstanceRule(ValidSetScore, "LTiebreak");
			}

			//private bool SetWinnerIsTiebreakWinner(object target, Csla.Validation.RuleArgs e)
			//{
			//    //if loser defaulted, no extra validation is needed 
			//    if (_LoserDefaulted)
			//        return true;

			//    //otherwise check validity of match score 
			//    //winner must have won more sets than loser 
			//    if (WSets <= LSets)
			//        return false;


			//    return true;
			//}


			private void ValidateScore()
			{
				//BrokenRules.Assert(propertyName & "_Score", "Score must be valid", propertyName, Not IsScoreValid()) 
				//BrokenRules.Assert("Set" + _SetNumber + "_Score", string.Format("Set {0} winner must have also won the tiebreak", _SetNumber), "LTiebreak", !IsScoreValid());
			}

			public byte WGames
			{
				get { return _WGames; }
				set { SetProperty(ref _WGames, value); }
			}
			public byte LGames
			{
				get { return _LGames; }
				set { SetProperty(ref _LGames, value); }
			}
			public byte WTiebreak
			{
				get { return _WTiebreak; }
				set { SetProperty(ref _WTiebreak, value); }
			}
			public byte LTiebreak
			{
				get { return _LTiebreak; }
				set { SetProperty(ref _LTiebreak, value); }
			}

			public bool SetPlayed
			{
				get { return WGames > 0 | LGames > 0; }
			}
			public bool TiebreakPlayed
			{
				get { return WTiebreak > 0 | LTiebreak > 0; }
			}
			public override string ToString()
			{
				return ToString(false);
			}
			public string ToString(bool IncludeTiebreaks)
			{
				if (!SetPlayed)
				{
					return "";
				}
				else if (TiebreakPlayed & IncludeTiebreaks)
				{
					return string.Format("{0}-{1} ({2}-{3})", WGames, LGames, WTiebreak, LTiebreak);
				}
				else
				{
					return string.Format("{0}-{1}", WGames, LGames);
				}
			}

			internal void Fetch(SafeDataReader dr)
			{
				WGames = dr.GetByte();
				LGames = dr.GetByte();
				WTiebreak = dr.GetByte();
				LTiebreak = dr.GetByte();
				MarkOld();
			}

			protected override object GetIdValue()
			{
				throw new Exception("The method or operation is not implemented.");
			}
		}

		#region Private Data
		private MatchSet[] _Sets = new MatchSet[5];
		private bool _LoserDefaulted;
		#endregion

		#region Business Properties and Methods
		/// <summary> 
		/// Returns the specified MatchSet object for the match (0-based). 
		/// </summary> 
		/// <param name="index">0-based index of the set</param> 
		/// <value></value> 
		/// <returns></returns> 
		/// <remarks></remarks> 
		/*public MatchSet Sets
		{
			get { return _Sets[index]; }
		}*/

		public MatchSet[] Sets
		{
			get { return _Sets; }
		}

		/// <summary> 
		/// Returns 0-based array of MatchSets for the match. 
		/// This version is for C# compatibility (the Sets property is not 
		/// available in C#). 
		/// </summary> 
		/// <value></value> 
		/// <returns></returns> 
		/// <remarks></remarks> 
		public MatchSet[] MatchSets
		{
			get { return _Sets; }
		}

		public bool ShowSet(int index)
		{
			return index == 0 || _Sets[index - 1].SetPlayed;
		}

		public bool LoserDefaulted
		{
			get { return _LoserDefaulted; }
			set
			{
				if (_LoserDefaulted == value)
					return;
				_LoserDefaulted = value;
				//MarkDirty();
				//ValidateProperty("LoserDefaulted", _LoserDefaulted) 
				PropertyHasChanged();
			}
		}

		public Int32 WSets
		{
			get
			{
				Int32 n = 0;
				for (int i = 0; i <= 4; i++)
				{
					if (_Sets[i].WGames > _Sets[i].LGames)
						n += 1;
				}
				return n;
			}
		}

		public Int32 LSets
		{
			get
			{
				Int32 n = 0;
				for (int i = 0; i <= 4; i++)
				{
					if (_Sets[i].LGames > _Sets[i].WGames)
						n += 1;
				}
				return n;
			}
		}

		#endregion

		#region Validation
		protected override void AddBusinessRules()
		{
			//ValidationRules.AddRule(IsScoreValid, "WGames");
			//ValidationRules.AddRule(CommonRules.StringRequired, new RuleArgs("FirstName", "First name"));
			//ValidationRules.AddRule(CommonRules.StringRequired, new RuleArgs("LastName", "Last name"));

		}

		protected override void AddInstanceBusinessRules()
		{
			ValidationRules.AddInstanceRule(ValidMatchScore, "LoserDefaulted");
		}

		private bool ValidMatchScore(object target, Csla.Validation.RuleArgs e)
		{
			//if loser didn't default, winner must have won more sets than loser 
			e.Description = "Winner must have won more sets than loser.";
			return _LoserDefaulted || WSets > LSets;
		}

		#endregion

		#region IsValid and IsDirty
		public override bool IsValid
		{
			get
			{
				if (!base.IsValid)
					return false;

				for (int i = 0; i <= 4; i++)
				{
					if (!_Sets[i].IsValid)
						return false;
				}

				return true;
			}
		}

		public override bool IsDirty
		{
			get
			{
				if (base.IsDirty)
					return true;
				for (int i = 0; i <= 4; i++)
				{
					if (_Sets[i].IsDirty)
						return true;
				}
				return false;
			}
		}

		//Sub Set_IsDirtyChanged(ByVal sender As Object, ByVal e As EventArgs) 
		// Me.OnIsDirtyChanged() 
		//End Sub 

		public override List<BrokenRule> GetAllBrokenRules()
		{
			List<BrokenRule> rules = base.GetAllBrokenRules();
			for (int i = 0; i <= 4; i++)
			{
				foreach (BrokenRule rule in _Sets[i].GetAllBrokenRules())
					rules.Add(rule);
			}
			return rules;
		}

		#endregion

		#region System.Object Overrides
		public override string ToString()
		{
			return ToString(false);
		}

		public string ToString(bool IncludeTiebreaks)
		{
			System.Text.StringBuilder s = new System.Text.StringBuilder();
			for (int i = 0; i <= 4; i++)
			{
				s.Append(_Sets[i].ToString(IncludeTiebreaks));
				s.Append(" ");
			}
			return s.ToString().Trim();
		}

		protected override object GetIdValue()
		{
			throw new Exception("The method or operation is not implemented.");
		}
		#endregion

		#region Constructors
		internal MatchScore()
		{
			//Prevent direct creation 
			MarkAsChild();
			for (Int16 i = 0; i <= 4; i++)
			{
				_Sets[i] = new MatchSet(i + 1, this);
				_Sets[i].PropertyChanged += Child_PropertyChangedGeneric;
				_Sets[i].PropertyChanged += new System.ComponentModel.PropertyChangedEventHandler(MatchScore_PropertyChanged);
				Saved += new EventHandler<Csla.Core.SavedEventArgs>(_Sets[i].MatchScore_Saved);
			}
		}

		void MatchScore_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
		{
			//e.PropertyName;
			ValidationRules.CheckRules("LoserDefaulted");
		}

		internal void Match_Saved(object sender, Csla.Core.SavedEventArgs e)
		{
			MarkOld();
		}

		#endregion

		#region Data Access
		internal void Fetch(SafeDataReader dr)
		{
			for (int i = 0; i <= 4; i++)
			{
				_Sets[i].Fetch(dr);
			}
			_LoserDefaulted = dr.GetBoolean();
			MarkOld();
		}
		#endregion


	}

}
