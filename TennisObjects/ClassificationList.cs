using System;
using System.Collections.Generic;
using System.Text;
using Csla;
using log4net;
using Bahns.Data;

namespace TennisObjects
{
	[Serializable()]
	public class ClassificationList : BusinessListBase<ClassificationList, Classification> // BusinessCollectionBase
	{

		private static ILog log = LogManager.GetLogger(typeof(ClassificationList).ToString());

		#region Private Data

		#endregion

		#region Static Methods
		public static ClassificationList NewList()
		{
			return new ClassificationList();
		}

		public static ClassificationList GetList()
		{
			return (ClassificationList)DataPortal.Fetch(new Criteria());
		}

		public static ClassificationList GetDropdownList()
		{
			ClassificationList list = GetList();
			list.Insert(0, Classification.NewClassification());
			return list;
		}

		public static void DeleteList()
		{
			DataPortal.Delete(new Criteria());
		}
		#endregion

		#region Constructors
		private ClassificationList()
		{
			//Prevent direction creation 
			AllowEdit = true;
			//AllowFind = true;
			AllowNew = true;
			AllowRemove = true;
			//AllowSort = true;
		}
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

		#region OnAddNew
  		protected override void OnAddingNew(System.ComponentModel.AddingNewEventArgs e)
		{
			base.OnAddingNew(e);
			e.NewObject = Classification.NewClassification();
		}

		protected override void OnListChanged(System.ComponentModel.ListChangedEventArgs e)
		{
			base.OnListChanged(e);
			switch (e.ListChangedType)
			{
				case System.ComponentModel.ListChangedType.ItemAdded:
					break;
				default:
					break;
			}
		}
		#endregion

		#region Data Access
		protected override void DataPortal_Fetch(object Criteria)
		{
			using (SafeDataReader dr = DbHelper.ExecuteReader("csla_get_classificationlist"))
			{
				while (dr.Read())
				{
					Add(Classification.GetClassification(dr));
				}
			}
		}

		protected override void DataPortal_Update()
		{
			//loop through each deleted child object and call its update method 
			foreach (Classification Classification in DeletedList)
			{
				Classification.Update();
			}

			//then clear the list of deleted objects because they are truly gone now 
			DeletedList.Clear();

			//loop through each non-deleted child object and call its update method 
			foreach (Classification Classification in this)
			{
				Classification.Update();
			}
		}

		//DataPortal_Delete supports direct object deletion. If we don't want to 
		//support direct delition, delete this method. 
		protected override void DataPortal_Delete(object Criteria)
		{
			Criteria crit = (Criteria)Criteria;
			//delete all Classification data that matches the criteria 
		}
		#endregion

	}

}
