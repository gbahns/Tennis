using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Security.Principal;
using Csla;
using Bahns.Data;
using System.Collections;

namespace TennisObjects.Security
{
	[Serializable()]
	public class UserIdentity : BusinessBase<UserIdentity>, IIdentity
	{

		#region Private Data
		private int _id; //database primary key; this way the user can change their login id
		private bool _isAuthenticated;
		private string _name = "";
		private string _email = "";
		private List<string> _roles = new List<string>();
		#endregion

		#region IIdentity
		public string AuthenticationType
		{
			get { return "Csla"; }
		}

		public bool IsAuthenticated
		{
			get { return _isAuthenticated; }
		}

		public string Name
		{
			get { return _name; }
		}
		#endregion

		#region Properties
		public int Id { get { return _id; } }
		public string Email { get { return _email; } }
		#endregion

		#region Business Methods
		protected override object GetIdValue()
		{
			return _name;
		}

		internal bool IsInRole(string role)
		{
			return _roles.Contains(role);
		}
		#endregion

		#region Factory Methods

		internal static UserIdentity UnauthenticatedIdentity()
		{
			return new UserIdentity();
		}

		internal static UserIdentity GetIdentity(string username, string password)
		{
			return DataPortal.Fetch<UserIdentity>(new Criteria(username, password));
		}

		public static UserIdentity GetIdentity(string username)
		{
			return DataPortal.Fetch<UserIdentity>(new LoadOnlyCriteria(username));
		}

		public static UserIdentity Create(string username, string password, string email, bool isApproved)
		{
			return DataPortal.Create<UserIdentity>(new CreationCriteria(username, password, email, isApproved));
		}

		//public static void ChangePassword(string username, string password, string newpassword)
		//{
		//    //return DataPortal.Update<UserIdentity>(new ChangePasswordCriteria(username, password, newpassword));
		//    //DataPortal.Execute<UserIdentity>(new ChangePasswordCriteria(username, password, newpassword));
		//    DataPortal.Fetch<UserIdentity>(new ChangePasswordCriteria(username, password, newpassword));
		//}

		private UserIdentity()
		{ /* require use of factory methods */ }

		#endregion

		#region Data Access

		[Serializable()]
		private class Criteria
		{
			private string _username;
			public string Username
			{
				get { return _username; }
			}

			private string _password;
			public string Password
			{
				get { return _password; }
			}

			public Criteria(string username, string password)
			{
				_username = username;
				_password = password;
			}
		}

		[Serializable()]
		private class LoadOnlyCriteria
		{
			private string _username;
			public string Username
			{
				get { return _username; }
			}

			public LoadOnlyCriteria(string username)
			{
				_username = username;
			}
		}

		//[Serializable()]
		//private class ChangePasswordCriteria
		//{
		//    private string _username;
		//    public string Username
		//    {
		//        get { return _username; }
		//    }

		//    private string _password;
		//    public string Password
		//    {
		//        get { return _password; }
		//    }

		//    private string _newpassword;
		//    public string NewPassword
		//    {
		//        get { return _newpassword; }
		//    }

		//    public ChangePasswordCriteria(string username, string password, string newpassword)
		//    {
		//        _username = username;
		//        _password = password;
		//        _newpassword = newpassword;
		//    }
		//}

		[Serializable()]
		private class CreationCriteria
		{
			private string _username;
			public string Username
			{
				get { return _username; }
			}

			private string _password;
			public string Password
			{
				get { return _password; }
			}

			private string _email;
			public string Email
			{
				get { return _email; }
			}

			private bool _isApproved;
			public bool IsApproved
			{
				get { return _isApproved; }
			}

			public CreationCriteria(string username, string password, string email, bool isApproved)
			{
				_username = username;
				_password = password;
				_email = email;
				_isApproved = isApproved;
			}
		}

		private void DataPortal_Fetch(Criteria criteria)
		{
			Criteria crit = (Criteria)criteria;

			_roles.Clear();

			//using (SafeDataReader dr = new SafeDataReader(DbHelper.ExecuteReader("csla_login", crit.Username, crit.Password)))
			using (SafeDataReader dr = Bahns.Data.Manual.DbHelper.ExecuteReader("csla_login", Param.In("@uid", crit.Username), Param.In("@pwd", crit.Password)))
			{
				if (dr.Read())
				{
					_name = crit.Username;
					_isAuthenticated = true;
					if (dr.NextResult())
					{
						while (dr.Read())
						{
							_roles.Add(dr.GetString(0));
						}
					}
				}
				else
				{
					_name = "";
					_isAuthenticated = false;
				}
			}
		}

		private void DataPortal_Fetch(LoadOnlyCriteria crit)
		{
			using (SafeDataReader dr = DbHelper.ExecuteReader("csla_get_user", crit.Username))
			{
				//Fetch(dr);
				_name = crit.Username;
				_isAuthenticated = false;
				if (dr.Read())
				{
					_id = dr.GetInt32();
					_email = dr.GetString();
				}
			}
		}

		private void DataPortal_Create(CreationCriteria crit)
		{
			DbResultsDictionary result = DbHelper.ExecuteNonQuery("csla_create_user", crit.Username, crit.Password, crit.Email, crit.IsApproved);
			this._id = (int)result["@ID"];
			this._name = crit.Username;
			this._email = crit.Email;
		}


		//private void Fetch(SafeDataReader dr)
		//{
		//    if (dr.Read())
		//    {
		//        _name = dr.GetString(0);
		//        _isAuthenticated = true;
		//        if (dr.NextResult())
		//        {
		//            while (dr.Read())
		//            {
		//                _roles.Add(dr.GetString(0));
		//            }
		//        }
		//    }
		//    else
		//    {
		//        _name = string.Empty;
		//        _isAuthenticated = false;
		//        _roles.Clear();
		//    }
		//}

		#endregion
	}
}
