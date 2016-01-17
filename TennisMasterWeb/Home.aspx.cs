using System;
using System.Collections;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
//using System.Data.OleDb;
using System.Drawing;
using System.Web;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using System.Web.Security;

namespace Tennis
{
	/// <summary>
	/// Summary description for WebForm1.
	/// </summary>

	/*
	Provider=SQLOLEDB;Server=BAHNSSERVER;Initial Catalog=Tennis;Trusted_Connection=Yes
	Server=BAHNSSERVER;Initial Catalog=Tennis;Trusted_Connection=Yes
	workstation id=GREG;packet size=4096;integrated security=SSPI;data source=BAHNSSERVER;persist security info=False;initial catalog=Tennis
	workstation id=GREG;packet size=4096;integrated security=SSPI;data source=192.168.1.2;persist security info=False;initial catalog=Tennis
	*/
	public partial class Home : System.Web.UI.Page //TennisPage
	{
		protected System.Web.UI.HtmlControls.HtmlGenericControl spnAuthenticated;
		protected System.Web.UI.WebControls.Button btnLogOut;
		/*
		protected System.Data.SqlClient.SqlCommand sqlSelectCommand1;
		protected System.Data.SqlClient.SqlCommand sqlInsertCommand1;
		protected System.Data.SqlClient.SqlConnection sqlConnection1;
		protected System.Data.SqlClient.SqlDataAdapter sqlDataAdapter1;
		protected Tennis.DataSet1 dataSet11;
		*/

		/*
		protected Tennis.DataSet1 dsUsers;
		protected System.Web.UI.WebControls.DataGrid DataGrid1;
		protected System.Web.UI.HtmlControls.HtmlForm Form1;
		protected System.Web.UI.WebControls.DataGrid dataGrid;
		*/
		protected System.Web.UI.HtmlControls.HtmlGenericControl spnUserName;

		public Home()
		{
			//sql = "select * from Users";
		}

		/*private void Page_Load(object sender, System.EventArgs e)
		{
			try
			{
				Trace.Write("attempting database connection");
				SqlConnection db = new SqlConnection(ConfigurationSettings.AppSettings["dbConnectionString"]);
				SqlDataAdapter dbAdapter = new SqlDataAdapter("select * from Users",db);
				dsUsers = new DataSet1();
				dbAdapter.Fill(dsUsers,"Users");

				DataGrid2.DataSource = dsUsers.Tables["Users"].DefaultView;
				DataGrid2.DataBind();
				//DataGrid1.DataSource = dsUsers.Tables["Contacts"].DefaultView;
				//DataGrid1.DataBind();
			}
			catch (Exception ex)
			{
				//throw ex; //for debugging
				//Trace.Warn(ex.Message);
				Trace.Warn("error","",ex);
				//Trace.Write(ex.StackTrace);
			}
			//spnAuthenticated.InnerText = "connected!";
		}*/

		#region Web Form Designer generated code
		override protected void OnInit(EventArgs e)
		{
			//
			// CODEGEN: This call is required by the ASP.NET Web Form Designer.
			//
			InitializeComponent();
			base.OnInit(e);
		}
		
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{    

		}
		#endregion

		private void btnLogOut_Click(object sender, System.EventArgs e)
		{
			FormsAuthentication.SignOut();
			Response.Redirect("login.aspx");
		}

		private void sqlConnection1_InfoMessage(object sender, System.Data.SqlClient.SqlInfoMessageEventArgs e)
		{
		
		}
	}
}
