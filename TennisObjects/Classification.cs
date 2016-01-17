using System;
using System.Collections.Generic;
using System.Text;
using Csla;
using log4net;
using Bahns.Data;

namespace TennisObjects
{
	[Serializable()]
	public class Classification : BusinessBase<Classification>
	{

		private static ILog log = LogManager.GetLogger(typeof(Classification).ToString());

		#region Private Data
		private Int32 _ID;
		private string _Name;
		private string _USTAEquivalent;
		#endregion

		#region Validation
		protected override void AddBusinessRules()
		{
			//BrokenRules.Assert("NameReq", "Name is required", _Name.Length == 0);

		}

		protected override void AddInstanceBusinessRules()
		{

		}
		#endregion

		#region Properties
		public Int32 ID
		{
			get { return _ID; }
		}

		public string Name
		{
			get { return _Name; }
			set { SetProperty(ref _Name, value); }
		}

		public string USTAEquivalent
		{
			get { return _USTAEquivalent; }
			set { SetProperty(ref _USTAEquivalent, value); }
		}
		#endregion

		#region System.Object Overrides
		public override string ToString()
		{
			return Name;
		}

		protected override object GetIdValue()
		{
			return _ID;
		}
		#endregion

		#region Shared Methods
		public static Classification NewClassification()
		{
			return new Classification();
		}

		public static Classification NewClassification(string Name, string USTAEquivalent)
		{
			return new Classification(Name, USTAEquivalent);
		}

		public static Classification GetClassification(SafeDataReader dr)
		{
			Classification Classification = new Classification();
			Classification.Fetch(dr);
			return Classification;
		}
		#endregion

		#region Constructors
		private Classification(string Name, string USTAEquivalent)
		{
			MarkAsChild();
			_Name = Name;
			_USTAEquivalent = USTAEquivalent;
		}

		private Classification()
		{
			//Prevent direction creation 
			MarkAsChild();
		}
		#endregion

		#region Data Access
		private void Fetch(SafeDataReader dr)
		{
			_ID = dr.GetInt32();
			_Name = dr.GetString();
			_USTAEquivalent = dr.GetString();
			MarkOld();
		}

		internal void Update()
		{
			if (this.IsDeleted)
			{
				if (!this.IsNew)
				{
					DbHelper.ExecuteNonQuery("csla_delete_classification", Param.In("@ID", _ID));
					//DbHelper.ExecuteNonQuery("csla_delete_classification", ID);
				}
				MarkNew();
			}
			else
			{
				DbHelper.ExecuteNonQuery("csla_save_classification", Param.ID("@ID", _ID, IsNew), Param.In("", _Name), Param.In("", _USTAEquivalent));
				//DbHelper.ExecuteNonQuery("csla_save_classification", Util.IDParam(_ID, IsNew), _Name, _USTAEquivalent);
				MarkOld();
			}
		}
		#endregion

	}

}
