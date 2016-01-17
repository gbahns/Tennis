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
using System.Collections.Generic;
using System.Net.Mail;

namespace Tennis.Account
{
	public partial class NewUser : System.Web.UI.Page
	{
		protected void Page_Load(object sender, EventArgs e)
		{
			CreateUserWizard1.Focus();
		}

		protected void CreateUserWizard1_CreatedUser(object sender, EventArgs e)
		{
			
		}

		protected void CreateUserWizard1_SendingMail(object sender, MailMessageEventArgs e)
		{
			Dictionary<string, string> values = new Dictionary<string, string>(2);
			values.Add("<%UserName%>", CreateUserWizard1.UserName);
			//values.Add("<%Password%>", CreateUserWizard1.Password);
			values.Add("<%email%>", CreateUserWizard1.Email);
			values.Add("<%id%>", Membership.GetUser(CreateUserWizard1.UserName).ProviderUserKey.ToString());

			MailMessage msg = CreateUserWizard1.MailDefinition.CreateMailMessage(
				CreateUserWizard1.Email,
				values,
				CreateUserWizard1);

			e.Message.Body = msg.Body;
		}
	}
}
