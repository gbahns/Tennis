using System;
using System.Collections.Generic;
using System.Text;
using log4net;
using Bahns.Data;
using Bahns.Core.BusinessObjects;
using Bahns.Util.Validation;

namespace TennisObjects.Info
{
	public class MatchScore
	{

		private static ILog log = LogManager.GetLogger(typeof(MatchScore).ToString());

		internal static MatchScore FromEditable(TennisObjects.MatchScore source)
		{
			MatchScore item = new MatchScore();
			item._LoserDefaulted = source.LoserDefaulted;
			for (Int16 i = 0; i <= 4; i++)
			{
				item._Sets[i].FromEditable(source.Sets[i]);
			}
			return item;
		}

		#region MatchSet
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
		/// player whose record is being retrieved". 
		/// 
		/// MatchSet does not know which way it is being used, as it does not contain any information about the 
		/// players. It is up to the parent class to know which way it is using MatchSet. 
		/// 
		/// Note that WGames and LGames are named with just 'W' and 'L' in order 
		/// </remarks> 
		public class MatchSet
		{
			private int _setNumber;
			private MatchScore _parent;

			internal MatchSet(int setNumber, MatchScore parent)
			{
				_setNumber = setNumber;
				_parent = parent;
			}

			public int SetNumber { get; private set; }

			public byte WGames { get; private set; }
			public byte LGames { get; private set; }
			public byte WTiebreak { get; private set; }
			public byte LTiebreak { get; private set; }

			public bool SetPlayed { get { return WGames > 0 || LGames > 0; } }
			public MatchSet PreviousSet { get { return SetNumber > 1 ? _parent._Sets[SetNumber - 2] : null; } }
			public bool TiebreakPlayed {get { return WTiebreak > 0 || LTiebreak > 0; }}
			public override string ToString() {return ToString(false);}

			public string ToString(bool IncludeTiebreaks)
			{
				if (!SetPlayed)
				{
					return "";
				}
				else if (TiebreakPlayed && IncludeTiebreaks)
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
			}


			internal void FromEditable(TennisObjects.MatchScore.MatchSet matchSet)
			{
				WGames = matchSet.WGames;
				LGames = matchSet.LGames;
				WTiebreak = matchSet.WTiebreak;
				LTiebreak = matchSet.LTiebreak;
			}
		}
		#endregion

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

		public bool ShowSet(int index)
		{
			return index == 0 || _Sets[index - 1].SetPlayed;
		}

		public bool LoserDefaulted { get; private set; }

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
		#endregion

		#region Constructors
		internal MatchScore()
		{
			for (Int16 i = 0; i <= 4; i++)
			{
				_Sets[i] = new MatchSet(i + 1, this);
			}
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
		}
		#endregion
	}
}
