using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.SessionState;

namespace Tennis
{
	public class Global : System.Web.HttpApplication
	{

		protected void Application_Start(object sender, EventArgs e)
		{

		}

		protected void Application_End(object sender, EventArgs e)
		{

		}

		protected void Application_AcquireRequestState(object sender, EventArgs e)
		{
			if (Csla.ApplicationContext.AuthenticationType == "Windows")
				return;

			System.Security.Principal.IPrincipal principal;
			try
			{
				principal = (System.Security.Principal.IPrincipal)HttpContext.Current.Session["CslaPrincipal"];
			}
			catch
			{
				principal = null;
			}

			if (principal == null)
			{
				// didn't get a principal from Session, so
				// set it to an unauthenticted PTPrincipal
				TennisObjects.Security.UserPrincipal.Logout();
			}
			else
			{
				// use the principal from Session
				Csla.ApplicationContext.User = principal;
			}
		}
	}
}