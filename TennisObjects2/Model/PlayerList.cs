using System;
using System.Collections.Generic;
using System.Text;
using log4net;
using Csla;
using Bahns.Data;

namespace TennisObjects
{

	[Serializable()]
	public class PlayerList : Csla.ReadOnlyListBase<PlayerList, Player>
	{

		private static ILog log = LogManager.GetLogger(typeof(PlayerList).ToString());

		#region Private Data
		/// <summary> 
		/// Cached list of players from database. 
		/// </summary> 
		/// <remarks> 
		/// When deployed in an n-tier model, this cached list exists both on 
		/// the client and on the server. Both caches are useful. 
		/// 
		/// The cache on each client means that each client only needs to retrieve 
		/// the list from the server once. 
		/// 
		/// The cach on the server means that the server only needs to retrieve 
		/// the list from the database once, and then distribute it to each 
		/// client upon request. 
		/// </remarks> 
		private static PlayerList _AllPlayers;
		#endregion

		#region Business Properties and Methods
		/*public Player item
		{
			get { return (Player)List.Item(index); }
		}*/

		public Player Find(int ID)
		{
			foreach (Player player in this)
			{
				if (player.ID == ID)
					return player;
			}
			return null;
		}

		public void Add()
		{
			this.Add(Player.Create());
		}

		public void AddBlankSelection()
		{
			//hack: using InnerList because the player object does not call MarkAsChild 
			IsReadOnly = false;
			Insert(0, Player.Create());
			IsReadOnly = true;
			//InnerList.Insert(0, Player.Create());
		}

		/*public void Remove(Player Child)
		{
			List.Remove(Child);
		}*/
		#endregion

		#region "Contains"
		//public bool Contains(Player item)
		//{
		//    foreach (Player child in this)
		//    {
		//        if (child.Equals(item))
		//            return true;
		//    }
		//    return false;
		//}

		//Public Overloads Function ContainsDeleted(ByVal item As Player) As Boolean 
		// Dim child As Player 
		// For Each child In deletedList 
		// If child.Equals(item) Then 
		// Return True 
		// End If 
		// Next 
		// Return False 
		// End Function 

		public int IndexOf(int ID)
		{
			for (int i = 0; i <= Count - 1; i++)
			{
				if (this[i].ID == ID)
				{
					return i;
				}
			}
			return -1;
		}
		#endregion

		#region Shared Methods
		public static PlayerList CreateList()
		{
			return new PlayerList();
		}

		public static PlayerList GetList()
		{
			return GetList(false);
		}

		/// <summary> 
		/// Retrieves a complete list of all players. 
		/// </summary> 
		/// <returns>List of all players.</returns> 
		/// <remarks> 
		/// This method executes on the client side. If the player list is stored 
		/// in the client's cache, it is returned without going to the server. 
		/// If not, the DataPortal is used to retrieve the list from the server 
		/// and then it is stored in the cache. 
		/// </remarks> 
		public static PlayerList GetList(bool forceReload)
		{
			if (_AllPlayers == null | forceReload)
			{
				_AllPlayers = (PlayerList)DataPortal.Fetch(new Criteria(forceReload));
			}
			return _AllPlayers;
		}

		public static PlayerList GetDropdownList()
		{
			return GetDropdownList(false);
		}

		public static PlayerList GetDropdownList(bool forceReload) // ERROR: Unsupported modifier : In, Optional bool forceReload) 
		{
			PlayerList list = (PlayerList)GetList(forceReload).Clone();
			list.AddBlankSelection();
			return list;
		}

		public static void DeleteList()
		{
			DataPortal.Delete(new Criteria());
		}
		#endregion

		#region "Constructors"
		private PlayerList()
		{
			//AllowSort = true;
			AddHandlers();
		}

		//todo: find new way of implementing this
		/*protected override void Deserialized()
		{
			base.Deserialized();
			//when an object is deserialized, such as happens with the Clone method, 
			//the event handlers need to be re-hooked 
			AddHandlers();
		}*/

		private void AddHandlers()
		{
			Player.Created += NewPlayer;
			Player.Updated += UpdatedPlayer;
			Player.Deleted += DeletedPlayer;
		}

		/// <summary> 
		/// Whenever a new player is created, automatically add it to the list. 
		/// </summary> 
		/// <param name="Player"></param> 
		/// <remarks></remarks> 
		private void NewPlayer(Player Player)
		{
			this.Add(Player);
			base.OnListChanged(new System.ComponentModel.ListChangedEventArgs(System.ComponentModel.ListChangedType.ItemAdded, this.Count - 1));
			//base.OnInsertComplete(i, this.InnerList(i));
		}

		private void UpdatedPlayer(Player Player)
		{
			int i = IndexOf(Player.ID);
			Player OldPlayer = this[i];
			IsReadOnly = false;
			this[i] = Player;
			IsReadOnly = true;
			base.OnListChanged(new System.ComponentModel.ListChangedEventArgs(System.ComponentModel.ListChangedType.ItemChanged, i));
			//base.OnSetComplete(i, OldPlayer, Player);
		}

		private void DeletedPlayer(int ID)
		{
			//Dim BindingList As System.ComponentModel.IBindingList = Me 
			//Dim i As Integer = BindingList.Find("ID", ID) 
			int i = IndexOf(ID);
			if (i == -1)
				return;
			IsReadOnly = false;
			RemoveAt(i);
			//MyBase.OnRemoveComplete(i, value) 
			IsReadOnly = true;
			base.OnListChanged(new System.ComponentModel.ListChangedEventArgs(System.ComponentModel.ListChangedType.ItemDeleted, i));
		}

		#endregion

		#region "Criteria"
		[Serializable()]
		private class Criteria
		{
			public bool ForceReload;

			public Criteria()
			{
				this.ForceReload = false;
			}

			public Criteria(bool forceReload)
			{
				this.ForceReload = forceReload;
			}
		}
		#endregion

		#region Data Access
		protected override void DataPortal_Fetch(object Criteria)
		{
			Criteria crit = (Criteria)Criteria;
			if (_AllPlayers == null | crit.ForceReload)
			{
				using (SafeDataReader dr = DbHelper.ExecuteReader("csla_get_playerlist"))
				{
					IsReadOnly = false;
					while (dr.Read())
						this.Add(Player.Fetch(dr));
					IsReadOnly = true;
				}
			}
			else
			{
				foreach (Player player in _AllPlayers)
					this.Add(player);
			}
		}

		//Protected Overrides Sub DataPortal_Update() 
		// 'loop through each deleted child object and call its update method 
		// For Each Player As Player In deletedList 
		// Player.Update(Me) 
		// Next 

		// 'then clear the list of deleted objects because they are truly gone now 
		// deletedList.Clear() 

		// 'loop through each non-deleted child object and call its update method 
		// For Each Player As Player In List 
		// Player.Update(Me) 
		// Next 
		//End Sub 

		//DataPortal_Delete supports direct object deletion. If we don't want to 
		//support direct delition, delete this method. 
		//Protected Overrides Sub DataPortal_Delete(ByVal Criteria As Object) 
		// Dim crit As Criteria = CType(Criteria, Criteria) 
		// 'delete all Player data that matches the criteria 
		//End Sub 
		#endregion

	}

}
