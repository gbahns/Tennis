using System;
using System.Collections.Generic;
using System.Text;
using Csla;
using Bahns.Data;

namespace TennisObjects
{
	public class ChangePassword : CommandBase
	{
		string _username = "";
		string _password = "";
		string _newpassword = "";

		int _rowsAffected;

		private ChangePassword() {}

		public static void Execute(string username, string password, string newpassword)
		{
			ChangePassword obj = new ChangePassword();
			obj._username = username;
			obj._password = password;
			obj._newpassword = newpassword;
			obj = DataPortal.Execute<ChangePassword>(obj);

			if (obj._rowsAffected == 0)
				throw new ApplicationException("Failed to change password");
		}

		protected override void DataPortal_Execute()
		{
			using (SafeDataReader dr = DbHelper.ExecuteReader("csla_changepassword", _username, _password, _newpassword))
			{
				//int rowsAffected = (int)result[0]
				dr.Read();
				_rowsAffected = dr.GetInt32();
			}
		}
	}
}
