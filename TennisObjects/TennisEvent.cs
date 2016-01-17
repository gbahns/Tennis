using System;
using System.Collections.Generic;
using System.Text;
using Csla;
using log4net;
using Bahns.Data;
using Bahns.Util;
using System.Collections;

namespace TennisObjects
{
	public enum EventTypeEnum : short
	{
		All = -1, //used for querying
		Normal = 0,
		League = 1,
		Tournament = 2
	}

	[Serializable()]
	public class TennisEvent : BusinessBase<TennisEvent>
	{

		private static ILog log = LogManager.GetLogger(typeof(TennisEvent).ToString());

		#region Events
		//these events only occur when updating to the database 
		//maybe they should happen when ApplyEdit is called? 
		//maybe they should happen when IsDirtyChanged is raised? 
		//hmmm.... 
		//maybe ApplyEdit is the best time, but how do we hook into that? 

		public static event CreatedEventHandler Created;
		public delegate void CreatedEventHandler(TennisEvent obj);
		public static event UpdatedEventHandler Updated;
		public delegate void UpdatedEventHandler(TennisEvent obj);
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

		#region Fields
		private int _ID;
		private string _Name = "";
		//Private _Classification As Classification 
		private int _ClassificationID;
		private SmartDate _BeginDate; // = new SmartDate(true);
		private SmartDate _EndDate; // = new SmartDate(false);
		private bool _TeamPlay;
		private EventTypeEnum _EventType;
		#endregion

		#region Properties
		public int ID
		{
			get { return _ID; }
		}

		public string Name
		{
			get { return _Name; }
			set { SetProperty(ref _Name, value); }
		}

		public int ClassificationID
		{
			get { return _ClassificationID; }
			set { SetProperty(ref _ClassificationID, value); }
		}

		public SmartDate BeginDate
		{
			get { return _BeginDate; }
			set { SetProperty(ref _BeginDate, value); }
		}

		public string BeginDateText
		{
			get { return _BeginDate.Text; }
			set { BeginDate = SmartDate.FromString(value);}
		}

		public SmartDate EndDate
		{
			get { return _EndDate; }
			set { SetProperty(ref _EndDate, value); }
		}

		public string EndDateText
		{
			get { return _EndDate.Text; }
			set { EndDate = SmartDate.FromString(value); }
		}

		public bool TeamPlay
		{
			get { return _TeamPlay; }
			set { SetProperty(ref _TeamPlay, value); }
		}

		public EventTypeEnum EventType
		{
			get { return _EventType; }
			set { SetProperty(ref _EventType, value); }
		}

		public bool IsLeague
		{
			get { return EventType == EventTypeEnum.League; }
			set { EventType = (value ? EventTypeEnum.League : EventType); }
		}

		public bool IsTournament
		{
			get { return EventType == EventTypeEnum.Tournament; }
			set { EventType = (value ? EventTypeEnum.Tournament : EventType); }
		}

		public bool IsCurrent
		{
			get 
			{
				return (BeginDate.IsNull || BeginDate < DateTime.Now) && (EndDate.IsNull || EndDate > DateTime.Now);
			}
		}
	

		public override TennisEvent Save()
		{
			bool creating = IsNew;
			TennisEvent tennisEvent = base.Save();
			if (creating)
			{
				tennisEvent.OnCreated();
			}
			else if (IsNew)
			{
				tennisEvent.OnDeleted();
			}
			else
			{
				tennisEvent.OnUpdated();
			}
			return tennisEvent;
		}

		#endregion

		#region System.Object Overrides
		protected override object GetIdValue()
		{
			return _ID;
		}
		#endregion

		#region Static Methods
		public static TennisEvent Create() // ERROR: Unsupported modifier : In, Optional string initialName) 
		{
			return Create("");
		}

		public static TennisEvent Create(string initialName) // ERROR: Unsupported modifier : In, Optional string initialName) 
		{
			return new TennisEvent(initialName);
		}

		public static TennisEvent Fetch(int ID)
		{
			return (TennisEvent)DataPortal.Fetch(new Criteria(ID));
		}

		internal static TennisEvent Fetch(SafeDataReader dr)
		{
			TennisEvent TennisEVent = new TennisEvent();
			TennisEVent.MarkAsChild();
			TennisEVent._Fetch(dr);
			return TennisEVent;
		}

		public static void Delete(int ID)
		{
			DataPortal.Delete(new Criteria(ID));
			OnDeleted(ID);
		}
		#endregion

		#region Constructors
		private TennisEvent()
		{
		}

		private TennisEvent(string initialName)
		{
			Name = initialName;
		}
		#endregion

		#region Criteria
		[Serializable()]
		private class Criteria
		{
			public Int32 ID;
			public Criteria(Int32 ID)
			{
				this.ID = ID;
			}
		}
		#endregion

		#region Data Access
		private void _Fetch(SafeDataReader dr)
		{
			_ID = dr.GetInt32();
			_Name = dr.GetString();
			_ClassificationID = dr.GetInt32();
			_BeginDate = dr.GetDateTime();
			_EndDate = dr.GetDateTime();
			_EventType = (EventTypeEnum)dr.GetInt16();
			_TeamPlay = dr.GetBoolean();
		}

		protected override void DataPortal_Fetch(object Criteria)
		{
			Criteria crit = (Criteria)Criteria;
			using (SafeDataReader dr = DbHelper.ExecuteReader("csla_get_event", crit.ID))
			{
				if (!dr.Read())
				{
					throw new RecordNotFoundException(string.Format("Event not found (ID:{0})", crit.ID));
				}
				_Fetch(dr);
			}
			MarkOld();
		}

		protected override void DataPortal_Insert()
		{
			Util.CheckAddAccess();

			//insert or update object data into database 
			log.Debug("updating event " + ToString());

			DbResultsDictionary ret = DbHelper.ExecuteNonQuery("csla_save_event", Util.IDParam(_ID, IsNew), _Name, _ClassificationID, _BeginDate.DbValue, _EndDate.DbValue, _EventType, _TeamPlay);
			_ID = (int)ret["@ID"];
			log.Info(string.Format("New id is {0}", _ID));
		}

		protected override void DataPortal_Update()
		{
			Util.CheckEditAccess();

			//insert or update object data into database 
			log.Debug("updating event " + ToString());

				DbResultsDictionary ret = DbHelper.ExecuteNonQuery("csla_save_event", Util.IDParam(_ID, IsNew), _Name, _ClassificationID, _BeginDate.DbValue, _EndDate.DbValue, _EventType, _TeamPlay);
				if (IsNew)
				{
					_ID = (int)ret["@ID"];
					log.Info(string.Format("New id is {0}", _ID));
				}
		}

		protected override void DataPortal_DeleteSelf()
		{
			Util.CheckDeleteAccess();
			DbHelper.ExecuteNonQuery("csla_delete_event", ID);
		}

		protected override void DataPortal_Delete(object Criteria)
		{
			Criteria crit = (Criteria)Criteria;
			DbHelper.ExecuteNonQuery("csla_delete_event", crit.ID);
		}
		#endregion

	}

}
