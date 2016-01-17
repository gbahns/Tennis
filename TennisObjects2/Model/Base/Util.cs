using System;
namespace TennisObjects
{
	static public class Util
	{
		public static object IDParam(int ID, bool IsNew)
		{
			if (IsNew)
			{
				return DBNull.Value;
			}
			else
			{
				return ID;
			}
		}

		static internal String NullString(Object s)
		{
			return s == null ? "null" : s.ToString();
		}

		static internal object BlankToNull(String s)
		{
			return s == "" ? (object)DBNull.Value : s;
		}

		#region Authorization Rules
		public static bool CanGet
		{
			get { return true; }
		}

		public static bool CanAdd
		{
			//get { return (Csla.ApplicationContext.User.IsInRole("Admin")); }
			get { return true; }
		}

		public static bool CanEdit
		{
			//get { return (Csla.ApplicationContext.User.IsInRole("Admin")); }
			get { return true; }
		}

		public static bool CanDelete
		{
			get
			{
				//if (Csla.ApplicationContext.User.IsInRole("Admin"))
				//    return true;

				//return false;
				return true;
			}
		}

		public static void CheckReadAccess()
		{
			if (!CanGet)
				throw new System.Security.SecurityException("You do not have read access.");
		}

		public static void CheckAddAccess()
		{
			if (!CanAdd)
				throw new System.Security.SecurityException("You do not have add access.");
		}

		public static void CheckEditAccess()
		{
			if (!CanEdit)
				throw new System.Security.SecurityException("You do not have update access.");
		}

		public static void CheckDeleteAccess()
		{
			if (!CanDelete)
				throw new System.Security.SecurityException("You do not have delete access.");
		}
		#endregion

	}
}
