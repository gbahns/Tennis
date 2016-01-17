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
	public class TennisDataPage : TennisPage
	{
		public TennisDataPage()
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

		private void BindData (String SortExpression)
		{
			//try
			{
				//Trace.Write("attempting database connection");
				//Trace.Write(sql);
				//SqlConnection db = new SqlConnection(ConfigurationSettings.AppSettings["dbConnectionString"]);
				//SqlDataAdapter dbAdapter = new SqlDataAdapter(sql,db);
				//DataSet dataSet = new DataSet();
				//dbAdapter.Fill(dataSet,"results");

				//if (SortExpression != null)
				//    dataGrid.DataSource = new DataView(dataSet.Tables["results"],"",SortExpression,DataViewRowState.CurrentRows);
				//else
				//    dataGrid.DataSource = dataSet.Tables["results"].DefaultView;

				//dataGrid.DataBind();
			}
			/*catch (Exception ex)
			{
				Trace.Warn("error","",ex);
				throw ex; //for debugging
			}*/
		}

		protected String sql = "";

	}
}
