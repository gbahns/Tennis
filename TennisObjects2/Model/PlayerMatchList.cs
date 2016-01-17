using System;
using Microsoft.VisualBasic;
using log4net;
using Csla;
using Bahns.Data;

namespace TennisObjects
{
	[Serializable()]
	public class PlayerMatchList : Csla.ReadOnlyListBase<PlayerMatchList, PlayerMatch> //.ReadOnlyCollectionBase
	{

		private static ILog log = LogManager.GetLogger(typeof(PlayerMatchList).ToString());

		private const int PlayerPointOfViewID = 1;

		#region "Business Properties and Methods"
		/*public PlayerMatch item
		{
			get { return (PlayerMatch)List.Item(index); }
		}*/
		#endregion

		#region "Contains"
		/*public bool Contains(PlayerMatch item)
		{
			foreach (PlayerMatch child in List)
			{
				if (child.Equals(item))
				{
					return true;
				}
			}
			return false;
		}

		public int IndexOf(int ID)
		{
			for (int i = 0; i <= Count - 1; i++)
			{
				if (this(i).ID == ID)
				{
					return i;
				}
			}
			return -1;
		}*/
		#endregion

		#region "Shared Methods"
		public static PlayerMatchList GetPlayerMatchList()
		{
			return (PlayerMatchList)DataPortal.Fetch(new Criteria());
		}

		public static PlayerMatchList SelectRecentMatches(PlayerMatchList source, int count)
		{
			PlayerMatchList target = new PlayerMatchList();
			target.IsReadOnly = false;
			for (int i = source.Count - count; i <= source.Count - 1; i++)
			{
				target.Add(source[i]);
			}
			target.IsReadOnly = true;
			return target;
		}

		public static PlayerMatchList SelectRecentMatches(PlayerMatchList source, int count, DateInterval dateInterval)
		{
			PlayerMatchList target = new PlayerMatchList();
			target.IsReadOnly = false;
			foreach (PlayerMatch match in source)
			{
				if (match.MatchDate > DateAndTime.DateAdd(dateInterval, -count, System.DateTime.Today))
				{
					target.Add(match);
				}
			}
			target.IsReadOnly = true;
			return target;
		}

		public static PlayerMatchList SelectMatchesByEvent(PlayerMatchList source, int eventID)
		{
			PlayerMatchList target = new PlayerMatchList();
			target.IsReadOnly = false;
			foreach (PlayerMatch match in source)
			{
				if (match.EventID == eventID)
				{
					target.Add(match);
				}
			}
			target.IsReadOnly = true;
			return target;
		}

		public static PlayerMatchList SelectMatchesByOpponent(PlayerMatchList source, int opponentID)
		{
			PlayerMatchList target = new PlayerMatchList();
			target.IsReadOnly = false;
			foreach (PlayerMatch match in source)
			{
				if (match.OpponentID == opponentID)
				{
					target.Add(match);
				}
			}
			target.IsReadOnly = true;
			return target;
		}

		#endregion

		#region "Constructors"
		private PlayerMatchList()
		{
			//AllowSort = true;
			AddHandlers();
		}

		private void AddHandlers()
		{
			/*Match.Created += NewMatch;
			Match.Updated += UpdatedMatch;
			Match.Deleted += DeletedMatch;*/
		}

		//todo: replace this with new approach
		/*protected override void Deserialized()
		{
			base.Deserialized();
			//when an object is deserialized, such as happens with the Clone method, 
			//the event handlers need to be re-hooked 
			AddHandlers();
		}*/

		/*/// <summary> 
		/// Whenever a new event is created, automatically add it to the list. 
		/// </summary> 
		/// <param name="Match"></param> 
		/// <remarks></remarks> 
		private void NewMatch(Match Match)
		{
			int i = this.Add(PlayerMatch.Copy(Match, PlayerPointOfViewID));
			base.OnListChanged(new System.ComponentModel.ListChangedEventArgs(System.ComponentModel.ListChangedType.ItemAdded,Count-1));
			//base.OnInsertComplete(i, this.InnerList(i));
		}

		private void UpdatedMatch(Match Match)
		{
			int i = IndexOf(Match.ID);
			if (i >= 0)
			{
				PlayerMatch OldMatch = this(i);
				IsReadOnly = false;
				this[i] = PlayerMatch.Copy(Match, PlayerPointOfViewID);
				IsReadOnly = true;
				base.OnListChanged(new System.ComponentModel.ListChangedEventArgs(System.ComponentModel.ListChangedType.ItemChanged, i));
				//base.OnSetComplete(i, OldMatch, Match);
			}
		}

		private void DeletedMatch(int ID)
		{
			//Dim BindingList As System.ComponentModel.IBindingList = Me 
			//Dim i As Integer = BindingList.Find("ID", ID) 
			int i = IndexOf(ID);
			if (i == -1)
				return;
			IsReadOnly = false;
			RemoveAt(i);
			IsReadOnly = true;
		}*/
		#endregion

		#region Criteria
		[Serializable()]
		private class Criteria
		{
			public Criteria()
			{
			}
		}
		#endregion

		#region Data Access
		protected override void DataPortal_Fetch(object Criteria)
		{
			Criteria crit = (Criteria)Criteria;
			using (SafeDataReader dr = DbHelper.ExecuteReader("csla_get_matchlist_personal", PlayerPointOfViewID))
			{
				IsReadOnly = false;
				while (dr.Read())
					Add(PlayerMatch.Fetch(dr));
				IsReadOnly = false;
			}
		}
		#endregion

	}
}
