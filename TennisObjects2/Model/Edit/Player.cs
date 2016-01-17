using System;
using System.Collections;
using System.Collections.Generic;
using log4net;
using Bahns.Data;
using Bahns.Core.BusinessObjects;
using Bahns.Util.Validation;
using System.Data;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace TennisObjects
{
	[Serializable()]
	public class Player : BusinessBase
	{
		private static ILog log = LogManager.GetLogger(typeof(Player).ToString());

		#region Static Methods
		public static Player Create()
		{
			return Create("");
		}

		public static Player Create(string initialName)
		{
			//todo: make sure MarkChild is set when the new player is being created as a child object 
			return new Player(initialName);
		}

		public static Player Get(IDataReader dr)
		{
			//Util.CheckReadAccess();
			Player item = new Player();
			item.Populate(dr);
			item.MarkOld();
			return item;
		}

		public static Player Get(int ID)
		{
			return Get(DataAccess.GetPlayer(ID));
		}

		public static List<Player> GetList(IDataReader dr)
		{
			var list = new List<Player>();
			while (dr.Read())
				list.Add(Player.Get(dr));
			return list;
		}

		//public static void Delete(Int32 ID)
		//{
		//    DataPortal.Delete(new Criteria(ID));
		//    OnDeleted(ID);
		//}
		#endregion

		#region Constructors
		public Player()
		{
		}

		private Player(string initialName)
		{
			FullName = initialName;
		}
		#endregion

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

		[DisplayName("First Name")]
		[Required]
		[StringLength(25, ErrorMessage="The first name cannot be longer than 25 characters.")]
		public string FirstName
		{
			get { return _FirstName; }
			set { SetProperty(ref _FirstName, value); }
		}

		[DisplayName("Last Name")]
		[Required]
		[StringLength(25, ErrorMessage = "The last name cannot be longer than 25 characters.")]
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
				string[] array = value.Split(" ".ToCharArray(), 2, StringSplitOptions.RemoveEmptyEntries);
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

		#region Data Access
		private void Populate(IDataReader dr)
		{
			int i = 0;
			_ID = dr.GetInt32(i++);
			_FirstName = dr.GetString(i++);
			_LastName = dr.GetString(i++);
		}

		protected override void Update()
		{
			DbResultsDictionary ret = DbUpdate();
			if (IsNew)
			{
				_ID = (int)ret["@IDout"];
				log.Info(string.Format("New id is {0}", _ID));
			}
			MarkOld();
		}

		private DbResultsDictionary DbUpdate()
		{
			return DbHelper.ExecuteNonQuery("csla_save_player", Util.IDParam(_ID, IsNew), _FirstName, _LastName, null);
		}

		protected void DataPortal_Insert()
		{
			Util.CheckAddAccess();
			DbUpdate();
		}

		protected void DataPortal_Update()
		{
			Util.CheckEditAccess();
			DbResultsDictionary ret = DbUpdate();
			if (IsNew)
			{
				_ID = (int)ret["@ID"];
				log.Info(string.Format("New id is {0}", _ID));
			}
			MarkOld();
		}

		protected void DataPortal_DeleteSelf()
		{
			Util.CheckDeleteAccess();
			DbHelper.ExecuteNonQuery("csla_delete_player", _ID);
		}

		//DataPortal_Delete supports direct object deletion. If we don't want to 
		//support direct deletion, delete this method. 
		protected void DataPortal_Delete(object Criteria)
		{
			Util.CheckDeleteAccess();

			//Criteria crit = (Criteria)Criteria;
			//DbHelper.ExecuteNonQuery("csla_delete_player", crit.ID);
		}
		#endregion

		protected override void AddBusinessRules()
		{
			base.AddBusinessRules();

			ValidationRules.AddRule(CommonRules.StringRequired, new RuleArgs("FirstName", "First name"));
			ValidationRules.AddRule(CommonRules.StringRequired, new RuleArgs("LastName", "Last name"));
		}
	}
}