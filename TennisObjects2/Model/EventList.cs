using System;
using System.Collections.Generic;
using System.Text;
using log4net;
using Csla;
using Bahns.Data;

namespace TennisObjects
{

[Serializable()] 
public class EventList : Csla.ReadOnlyListBase<EventList,TennisEvent>
{ 
    
    private static ILog log = LogManager.GetLogger(typeof(EventList).ToString()); 
    
    /// <summary> 
    /// Cached list of events from database. 
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
    private static EventList _AllEvents; 
    
    //_FilteredEvents is used client-side only; it is a view 
    private static EventList _FilteredEvents; 
    
    
    #region Contains 
   
    public bool Contains(int ID) 
    { 
        foreach (TennisEvent child in this) { 
            if (child.ID == ID) { 
                return true; 
            } 
        } 
        return false; 
    } 
    
    public int IndexOf(int ID) 
    { 
        for (int i = 0; i <= Count - 1; i++) { 
            if (this[i].ID == ID) { 
                return i; 
            } 
        } 
        return -1; 
    } 
    
    public TennisEvent Find(int ID) 
    { 
        int i = IndexOf(ID); 
        if (i == -1) 
            return null; 
        return this[i]; 
    } 
    #endregion 
    
    #region Static Methods
	public static EventList GetList()
	{
		return GetList(false);
	}

	public static EventList GetList(bool forceReload) 
	{
		return GetList(false, false, -1, forceReload);
	}

	public static EventList GetList(bool allLeagues, bool allTournaments, int specificID)
	{
		return GetList(allLeagues, allTournaments, specificID, false);
	}

    public static EventList GetList(bool allLeagues, bool allTournaments, int specificID, bool forceReload)
    { 
        //make sure the main list has been initialized 
        GetListAll(forceReload); 
        if (allLeagues & allTournaments) 
            return _AllEvents; 
        
        System.DateTime now = System.DateTime.Now; 
        _FilteredEvents = null; 
        _FilteredEvents = new EventList();
		_FilteredEvents.IsReadOnly = false;
        foreach (TennisEvent TennisEvent in _AllEvents) 
		{ 
            if (TennisEvent.IsCurrent || (allTournaments && TennisEvent.IsTournament) || (allLeagues && TennisEvent.IsLeague) || (TennisEvent.ID == specificID)) 
			{ 
                _FilteredEvents.Add(TennisEvent); 
            } 
        }
		_FilteredEvents.IsReadOnly = true;
		return _FilteredEvents; 
    }

	public static EventList GetListAll()
	{
		return GetListAll(false);
	}

	public static EventList GetListAll(bool forceReload)
    { 
        if (forceReload) 
            _AllEvents = null; 
        if (_AllEvents == null) 
		{ 
            //when refreshing _AllEvents, _CurrentEvents should also be refreshed 
            _AllEvents = (EventList)DataPortal.Fetch(new Criteria(forceReload)); 
        } 
        return _AllEvents; 
    }

	public static EventList GetDropdownList()
	{
		EventList list = GetList();
		list.IsReadOnly = false;
		list.Insert(0, TennisEvent.Create());
		list.IsReadOnly = true;
		return list;
	}
    #endregion 
    
    #region Constructors 
    private EventList() 
    { 
        //AllowSort = true; 
        AddHandlers(); 
    } 
    
    private void AddHandlers() 
    { 
        TennisEvent.Created += NewTennisEvent; 
        TennisEvent.Updated += UpdatedTennisEvent; 
        TennisEvent.Deleted += DeletedTennisEvent; 
    } 
    
    //todo: re-do this the new way
	/*protected override void Deserialized() 
    { 
        base.Deserialized(); 
        //when an object is deserialized, such as happens with the Clone method, 
        //the event handlers need to be re-hooked 
        AddHandlers(); 
    } */
    
    /// <summary> 
    /// Whenever a new event is created, automatically add it to the list. 
    /// </summary> 
    /// <param name="TennisEvent"></param> 
    /// <remarks></remarks> 
    private void NewTennisEvent(TennisEvent TennisEvent) 
    {
		IsReadOnly = false;
		this.Add(TennisEvent);
		IsReadOnly = true;
		base.OnListChanged(new System.ComponentModel.ListChangedEventArgs(System.ComponentModel.ListChangedType.ItemAdded, this.Count - 1));
        //base.OnInsertComplete(i, this[i]); 
    } 
    
    private void UpdatedTennisEvent(TennisEvent TennisEvent) 
    { 
        int i = IndexOf(TennisEvent.ID); 
        TennisEvent OldTennisEvent = this[i]; 
        IsReadOnly = false; 
        this[i] = TennisEvent; 
        IsReadOnly = true; 
		base.OnListChanged(new System.ComponentModel.ListChangedEventArgs(System.ComponentModel.ListChangedType.ItemChanged, i));
        //base.OnSetComplete(i, OldTennisEvent, TennisEvent); 
    } 
    
    private void DeletedTennisEvent(int ID) 
    { 
        //Dim BindingList As System.ComponentModel.IBindingList = Me 
        //Dim i As Integer = BindingList.Find("ID", ID) 
        int i = IndexOf(ID); 
        if (i == -1) 
            return; 
        IsReadOnly = false; 
        RemoveAt(i); 
        IsReadOnly = true; 
    } 
    #endregion 
    
    #region Criteria 
    [Serializable()] 
    private class Criteria 
    { 
        public bool ForceReload; 
        public Criteria(bool forceReload)
        { 
            this.ForceReload = forceReload; 
        } 
    } 
    #endregion 
    
    #region Data Access 
    const string spFetch = "csla_get_eventlist"; 
    
    protected override void DataPortal_Fetch(object Criteria) 
    { 
        Criteria crit = (Criteria)Criteria; 
        if (_AllEvents == null | crit.ForceReload) 
		{ 
            using (SafeDataReader dr = DbHelper.ExecuteReader(spFetch))
			{ 
                IsReadOnly = false; 
                while (dr.Read()) 
                    this.Add(TennisEvent.Fetch(dr));
				IsReadOnly = true;
			} 
        } 
        else 
		{
			IsReadOnly = false;
			foreach (TennisEvent item in _AllEvents)
				this.Add(item);
			IsReadOnly = true;
        } 
    } 
    #endregion 
} 

}
