
using System.Security.Principal;
public static class Set
{
	static public bool In<T>(T s, T[] set)
	{
		foreach (T v in set)
			if (s.Equals(v)) return true;
		return false;
	}
}

public static class IdentityHelper
{
	/// <summary>
	/// Thread.CurrentPrincipal.Identity is the user on whose behalf the code
	/// is running.  This is the identity that is returned if it has a meaningful
	/// value.  For a web application, ASP.NET sees to it that this value is
	/// equivalent to HttpContext.Current.User.Identity (i.e. it represents the
	/// user of the web application).  For other applications, if the application
	/// uses a role-based security mechanism, this value should be set correctly.
	/// If not, the application must set the application domain's principal policy,
	/// for example by calling AppDomain.Pricipal.SetPolicy(WindowsPolicy), or
	/// else it must manually set Thread.CurrentPrincipal to an appropriate value.
	/// 
	/// When called by an application that has not set Thread.CurrentPrincipal
	/// to a meaningful value, it defaults to WindowsIdentity.GetCurrent(),
	/// which gives the identity of the current windows user (i.e. the security
	/// context that the thread is running under).
	/// </summary>
	public static string CurrentIdentityName
	{
		get
		{
			IPrincipal principal = System.Threading.Thread.CurrentPrincipal;
			if (principal != null)
			{
				IIdentity identity = principal.Identity;
				if (identity != null && identity.Name != "")
					return identity.Name;
			}
			return WindowsIdentity.GetCurrent().Name;
		}
	}
}

