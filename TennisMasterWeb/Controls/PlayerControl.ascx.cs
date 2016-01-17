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
using TennisObjects;

namespace Tennis.Controls
{
	public partial class PlayerControl : DataControl<TennisObjects.Player>
	{
		#region Properties
		#endregion

		#region Page Overrides
		protected override void OnLoad(EventArgs e)
		{
			base.OnLoad(e);

			if (!IsPostBack)
			{
				if (base.Object.IsNew)
				{
					Master.StatusText = "Enter new player information";
				}
				else
				{
					Master.StatusText = "Loaded";
				}

				DataBind();
			}
			else
			{
				/*Page.Validate();
				if (Page.IsValid)
				{
					player.FirstName = FirstName.Text;
					player.LastName = LastName.Text;

					if (!player.IsValid)
					{
						Status.Text = player.BrokenRulesCollection.ToString();
						
						foreach (BrokenRule r in player.BrokenRulesCollection)
						{
						}
						return;
					}

					player.Save();
					Status.Text = "Saved";
				}*/
				//Save(player);
			}
			DialogCaption.InnerText = Caption;

			FirstName.Focus();
		}
		#endregion

		protected override Player CreateObject()
		{
			return Player.Create();
		}

		protected override Player GetObject(string id)
		{
			return Player.Fetch(int.Parse(id));
		}

		protected override void GetDataFromForm()
		{
			Object.FirstName = FirstName.Text;
			Object.LastName = LastName.Text;
		}

		protected override void CopyDataToForm()
		{
			FirstName.Text = Object.FirstName;
			LastName.Text = Object.LastName;
		}
		
	}
}