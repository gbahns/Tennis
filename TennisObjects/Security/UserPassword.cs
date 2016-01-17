using System;
using System.Collections.Generic;
using System.Text;
using Csla;
using Bahns.Data;

namespace TennisObjects.Security
{
	public class UserPassword : ReadOnlyBase<UserPassword>
	{
		private string _password= "";
		
		public static string GetPassword(string username)
		{
			UserPassword item = DataPortal.Fetch<UserPassword>(new Criteria(username));
			return item._password;
		}

		protected override object GetIdValue()
		{
			throw new Exception("The method or operation is not implemented.");
		}

		[Serializable()]
		private class Criteria
		{
			private string _username;
			public string Username
			{
				get { return _username; }
			}

			public Criteria(string username)
			{
				_username = username;
			}
		}

		private void DataPortal_Fetch(Criteria criteria)
		{
			Criteria crit = (Criteria)criteria;

			using (SafeDataReader dr = DbHelper.ExecuteReader("csla_get_password", crit.Username))
			{
				if (dr.Read())
				{
					_password = dr.GetString();
				}
			}
		}

	}
}
