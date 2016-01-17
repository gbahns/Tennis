using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization;
//using log4net;
//using Csla;
//using Csla.Core;
//using Csla.Data;
//using Csla.Validation;
//using Bahns.Data;
using Bahns.Core.BusinessObjects;

namespace TennisObjects
{
	//[Serializable()]
	public class Player : BusinessBase
	{

		//private static ILog log = LogManager.GetLogger(typeof(Player).ToString());

		#region Events
		public static event CreatedEventHandler Created;
		public delegate void CreatedEventHandler(Player obj);
		public static event UpdatedEventHandler Updated;
		public delegate void UpdatedEventHandler(Player obj);
		public static event DeletedEventHandler Deleted;
		public delegate void DeletedEventHandler(int ID);

		public void OnCreated()
		{
			if (Created != null)
			{
				Created(this);
			}
		}

		public void OnUpdated()
		{
			if (Updated != null)
			{
				Updated(this);
			}
		}

		public void OnDeleted()
		{
			if (Deleted != null)
			{
				Deleted(this.ID);
			}
		}

		public static void OnDeleted(int ID)
		{
			if (Deleted != null)
			{
				Deleted(ID);
			}
		}
		#endregion

		#region Private Data
		private Int32 _ID;
		private string _FirstName = "";
		private string _LastName = "";
		#endregion

		#region Business Properties and Methods
		public Int32 ID
		{
			get { return _ID; }
		}

		public string FirstName
		{
			get { return _FirstName; }
			set { SetProperty(ref _FirstName, value); }
		}

		public string LastName
		{
			get { return _LastName; }
			set { SetProperty(ref _LastName, value); }
		}

		public string FullName
		{
			get
			{
				if (FirstName.Length == 0 & LastName.Length == 0)
					return "";
				return string.Format("{0} {1}", FirstName, LastName);
			}
			set
			{
				//string[] array = value.Split(' ', 2, StringSplitOptions.RemoveEmptyEntries);

				string[] array = value.Split(new char[] {' '}, StringSplitOptions.RemoveEmptyEntries);

				if (array.Length > 0)
				{
					FirstName = array[0];
					if (array.Length > 1)
					{
						LastName = array[1];
					}
				}
			}
		}


		//public override Player Save()
		//{
		//    bool creating = IsNew;
		//    Player player = base.Save();
		//    if (creating)
		//    {
		//        player.OnCreated();
		//    }
		//    else if (IsNew)
		//    {
		//        player.OnDeleted();
		//    }
		//    else
		//    {
		//        player.OnUpdated();
		//    }
		//    return player;
		//}
		#endregion

		#region System.Object Overrides
		public override string ToString()
		{
			//Return String.Format("{0} {1} ({2})", FirstName, LastName, ID) 
			return FullName;
		}
		#endregion

		#region Shared Methods
		public static List<Player> GetList()
		{
			List<Player> list = new List<Player>();
			list.Add(new Player("Greg Bahns"));
			list.Add(new Player("Mirko Ravlic"));
			list.Add(new Player("Brian Wessinger"));
			return list;
		}

		public static Player Create()
		{
			return Create("");
		}

		public static Player Create(string initialName)
		{
			//todo: make sure MarkChild is set when the new player is being created as a child object 
			return new Player(initialName);
		}

		//internal static Player Fetch(Bahns.Data.SafeDataReader dr)
		//{
		//    Player Player = new Player();
		//    Player.MarkAsChild();
		//    Player._Fetch(dr);
		//    return Player;
		//}

		public static Player Fetch(Int32 ID)
		{
			//return (Player)DataPortal.Fetch(new Criteria(ID));
			return new Player("Test Player");
		}

		public static void Delete(Int32 ID)
		{
			//DataPortal.Delete(new Criteria(ID));
			OnDeleted(ID);
		}
		#endregion

		#region "Constructors"
		private Player()
		{
		}

		private Player(string initialName)
		{
			FullName = initialName;
		}
		#endregion

		#region Criteria
		//[Serializable()]
		private class Criteria
		{
			public Int32 ID;
			public Criteria()
			{
			}
			public Criteria(Int32 ID)
			{
				this.ID = ID;
			}
		}
		#endregion

		#region Data Access
		//private void _Fetch(Bahns.Data.SafeDataReader dr)
		//{
		//    _ID = dr.GetInt32();
		//    _FirstName = dr.GetString();
		//    _LastName = dr.GetString();
		//}

		/*internal void Update(PlayerList Parent) 
		{ 
			//todo: insert or update object data into database 
		}*/

		//protected override void DataPortal_Fetch(object Criteria)
		//{
		//    Bahns.Util.CheckReadAccess();

		//    Criteria crit = (Criteria)Criteria;
		//    //using (SafeDataReader dr = DbHelper.ExecuteReader("csla_get_player", crit.ID))
		//    //{
		//    //    if (!dr.Read())
		//    //    {
		//    //        throw new RecordNotFoundException(string.Format("Player not found (ID:{0})", crit.ID));
		//    //    }
		//    //    _Fetch(dr);
		//    //}
		//    MarkOld();
		//}

		//private DbResultsDictionary Update()
		//{
		//    return DbHelper.ExecuteNonQuery("csla_save_player", Util.IDParam(_ID, IsNew), _FirstName, _LastName, null);
		//}

		//protected override void DataPortal_Insert()
		//{
		//    Util.CheckAddAccess();
		//    Update();
		//}

		//protected override void DataPortal_Update()
		//{
		//    Util.CheckEditAccess();
		//    DbResultsDictionary ret = Update();
		//    if (IsNew)
		//    {
		//        _ID = (int)ret["@ID"];
		//        log.Info(string.Format("New id is {0}", _ID));
		//    }
		//    MarkOld();
		//}

		//protected override void DataPortal_DeleteSelf()
		//{
		//    Util.CheckDeleteAccess();
		//    DbHelper.ExecuteNonQuery("csla_delete_player", _ID);
		//}

		//DataPortal_Delete supports direct object deletion. If we don't want to 
		//support direct deletion, delete this method. 
		//protected override void DataPortal_Delete(object Criteria)
		//{
		//    Util.CheckDeleteAccess();

		//    Criteria crit = (Criteria)Criteria;
		//    DbHelper.ExecuteNonQuery("csla_delete_player", crit.ID);
		//}
		#endregion

		protected override void AddBusinessRules()
		{
			//base.AddBusinessRules();

			//ValidationRules.AddRule(CommonRules.StringRequired, new RuleArgs("FirstName", "First name"));
			//ValidationRules.AddRule(CommonRules.StringRequired, new RuleArgs("LastName", "Last name"));
		}

		//protected override object GetIdValue()
		//{
		//    return this._ID;
		//}
	}
}