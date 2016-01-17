using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using Csla;
using System.Text;
using Csla.Validation;
using Tennis.Controls;
using TennisObjects.Security;
using TennisObjects;

namespace Tennis
{
	public partial class Master : System.Web.UI.MasterPage
	{

		internal string StatusText
		{
			get { return Status.Text; }
			set { Status.Text = value; }
		}

		void RemoveMenuItem(string valuePath)
		{
			MenuItem item = MainMenu.FindItem(valuePath);
			if (item != null)
			{
				if (item.Parent == null)
					MainMenu.Items.Remove(item);
				else
					item.Parent.ChildItems.Remove(item);
			}
		}

		protected override void OnLoad(EventArgs e)
		{
			base.OnLoad(e);

			Page.Title = "Tennis Master - " + Page.Title;

			//if (Request.QueryString["autologin"] != "")
			//    Response.Cookies["autologin"].Value = Request.QueryString["autologin"];
			//&& Response.Cookies["autologin"].Value == "y"

			if (!Csla.ApplicationContext.User.Identity.IsAuthenticated && Request.IsLocal && ConfigurationManager.AppSettings["LocalAutoLogin"] == "true")
			{
				UserPrincipal.Login("gbb", "spanky");
				HttpContext.Current.Session["CslaPrincipal"] = Csla.ApplicationContext.User;
			}

			if (!Util.CanAdd)
			{
				RemoveMenuItem("Matches/Add Match");
				RemoveMenuItem("Players/Add Player");
				RemoveMenuItem("Events/Add Event");
				RemoveMenuItem("Classifications/Add Classification");
			}

			if (!Csla.ApplicationContext.User.Identity.IsAuthenticated)
			{
				RemoveMenuItem("Account");
			}

			if (!Csla.ApplicationContext.User.IsInRole("Admin"))
			{
				RemoveMenuItem("Admin");
			}

			//MainMenu.FindItem("Players/Add").Enabled = Util.CanAdd;

			//MainMenu.FindItem("Matches").Selected = true;
			//MainMenu.SelectedItem;
			
		}


		MenuItem FindSelectedItem(MenuItemCollection items)
		{
			foreach (MenuItem item in items)
			{
				if (item.NavigateUrl.Length > 0 && Request.Path.Contains(item.NavigateUrl.Replace("~", "")))
				{
					return item;
				}
				MenuItem childSelected = FindSelectedItem(item.ChildItems);
				if (childSelected != null)
					return childSelected;
			}
			return null;
		}

		protected override void OnPreRender(EventArgs e)
		{
			base.OnPreRender(e);

			MenuItem selectedItem = FindSelectedItem(MainMenu.Items);

			if (selectedItem != null)
			{
				selectedItem.Selected = true;
				//selectedItem.Selectable = false;
			}
			
			//MainMenu.FindItem("Matches").Selected = true;
			//MainMenu.FindItem("Players").Selected = true;
			//MainMenu.FindItem("Players/View").Selected = true;
			//MainMenu.FindItem("Players/View").Selectable = false;
			//MainMenu.FindItem("Home").Selectable = true;
		}

		protected void LoginStatus1_LoggingOut(object sender, LoginCancelEventArgs e)
		{
			TennisObjects.Security.UserPrincipal.Logout();
			Session["CslaPrincipal"] = Csla.ApplicationContext.User;
			System.Web.Security.FormsAuthentication.SignOut();
		}

		#region Event Handlers
		//protected void Cancel_Click(object sender, System.EventArgs e)
		//{
		//    StatusText = "Cancelled";
		//    //foreach (Control c in ContentPlaceHolder1.Controls)
		//    //{
		//    //    DataControl dc = c as DataControl;
		//    //    if (dc != null)
		//    //        dc.Cancel_Click(sender, e);
		//    //}
		//}

		//protected void Edit_Click(object sender, EventArgs e)
		//{
		//    StatusText = "Editing";
		//}
		#endregion
	}
}
