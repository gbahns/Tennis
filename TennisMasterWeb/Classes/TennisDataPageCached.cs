using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI.WebControls;

namespace Tennis
{
	/// <summary>
	/// Summary description for TennisDataPage.
	/// </summary>
	public abstract class TennisDataPageCached : TennisPage
	{
		protected System.Data.DataView CurrentDataView = null;

		public TennisDataPageCached()
		{
		}

		override protected void OnInit(EventArgs e)
		{
			this.Load += new System.EventHandler(this.Page_Load);
			base.OnInit(e);
		}

		protected void Page_Load(object sender, System.EventArgs e)
		{
			if (!IsPostBack)
			{
				BindData(null);
			}
		}

		protected void Page_Sort(object source, DataGridSortCommandEventArgs e)
		{
			BindData(e.SortExpression);
		}

		protected abstract String TableName {get;}
		//protected abstract String SqlString {get;}
		protected virtual String FilterExpression {get {return null;}}

		protected virtual void BindParameters() {}

		private void BindData (String SortExpression)
		{
			//BindParameters();
			//DataTable Table = GetSessionTable(TableName);
			//CurrentDataView = new DataView(Table,FilterExpression,SortExpression,DataViewRowState.CurrentRows);
			//dataGrid.DataSource = CurrentDataView;
			//dataGrid.DataBind();
		}

	}
}
