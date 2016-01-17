using System;
using System.Collections.Generic;
using System.Text;
using Csla;
using Bahns.Data;

namespace TennisObjects
{
	public class ConfirmUser : CommandBase
	{
		int _id;
		string _username = "";
		string _email = "";

		int _rowsAffected;

		private ConfirmUser() { }

		public static void Execute(int id, string username, string email)
		{
			ConfirmUser obj = new ConfirmUser();
			obj._id = id;
			obj._username = username;
			obj._email = email;
			obj = DataPortal.Execute<ConfirmUser>(obj);

			if (obj._rowsAffected == 0)
				throw new ApplicationException("Failed to confirm user");
		}

		protected override void DataPortal_Execute()
		{
			using (SafeDataReader dr = DbHelper.ExecuteReader("csla_confirm_new_user", _id, _username, _email))
			{
				dr.Read();
				_rowsAffected = dr.GetInt32();
			}
		}
	}
}
