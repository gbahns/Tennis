using System;
using TennisObjects.Security;
using System.Web;
using System.Web.Security;

namespace Tennis
{
	public class TennisMembershipProvider : MembershipProvider
	{
		private MembershipUser GetMembershipUser(UserIdentity user)
		{
			return new MembershipUser("TennisMembershipProvider", user.Name, user.Id, user.Email, null, null, false, false, DateTime.MinValue, DateTime.MinValue, DateTime.MinValue, DateTime.MinValue, DateTime.MinValue);
		}

		public override bool ValidateUser(string username, string password)
		{
			bool result = UserPrincipal.Login(username, password);
			HttpContext.Current.Session["CslaPrincipal"] = Csla.ApplicationContext.User;
			return result;
		}

		public override MembershipUser GetUser(string username, bool userIsOnline)
		{
			return GetMembershipUser(UserIdentity.GetIdentity(username));
		}

		public override bool ChangePassword(string username, string oldPassword, string newPassword)
		{
			try
			{
				TennisObjects.ChangePassword.Execute(username, oldPassword, newPassword);
				return true;
			}
			catch (ApplicationException)
			{
				return false;
			}
		}

		public override bool RequiresQuestionAndAnswer
		{
			get { return false; }
		}

		public override bool EnablePasswordRetrieval
		{
			get { return true; }
		}

		public override bool EnablePasswordReset
		{
			get { return true; }
		}

		public override string GetPassword(string username, string answer)
		{
			return UserPassword.GetPassword(username);
		}

		public override MembershipUser CreateUser(string username, string password, string email, string passwordQuestion, string passwordAnswer, bool isApproved, 
			object providerUserKey, out MembershipCreateStatus status)
		{
			UserIdentity user =  UserIdentity.Create(username, password, email, isApproved);
			status = MembershipCreateStatus.Success;
			return GetMembershipUser(user);
		}

		public override int MinRequiredNonAlphanumericCharacters
		{
			get { return 0; }
		}

		public override int MinRequiredPasswordLength
		{
			get { return 6; }
		}

		#region Non-Implemented Members

		// the following members must be implemented due to the abstract class MembershipProvider,
		// but not required to be functional for using the Login control.
		public override bool ChangePasswordQuestionAndAnswer(string username, string password, string newPasswordQuestion, string newPasswordAnswer)
		{
			throw new NotSupportedException("The method or operation is not implemented.");
		}

		public override bool DeleteUser(string username, bool deleteAllRelatedData)
		{
			throw new NotSupportedException("The method or operation is not implemented.");
		}

		public override MembershipUserCollection FindUsersByEmail(string emailToMatch, int pageIndex, int pageSize, out int totalRecords)
		{
			throw new NotSupportedException("The method or operation is not implemented.");
		}

		public override MembershipUserCollection FindUsersByName(string usernameToMatch, int pageIndex, int pageSize, out int totalRecords)
		{
			throw new NotSupportedException("The method or operation is not implemented.");
		}

		public override MembershipUserCollection GetAllUsers(int pageIndex, int pageSize, out int totalRecords)
		{
			throw new NotSupportedException("The method or operation is not implemented.");
		}

		public override int GetNumberOfUsersOnline()
		{
			throw new NotSupportedException("The method or operation is not implemented.");
		}

		public override MembershipUser GetUser(object providerUserKey, bool userIsOnline)
		{
			throw new NotSupportedException("The method or operation is not implemented.");
		}

		public override string GetUserNameByEmail(string email)
		{
			throw new NotSupportedException("The method or operation is not implemented.");
		}

		public override int MaxInvalidPasswordAttempts
		{
			get { throw new NotSupportedException("The method or operation is not implemented."); }
		}

		public override int PasswordAttemptWindow
		{
			get { throw new NotSupportedException("The method or operation is not implemented."); }
		}

		public override MembershipPasswordFormat PasswordFormat
		{
			get { throw new NotSupportedException("The method or operation is not implemented."); }
		}

		public override string PasswordStrengthRegularExpression
		{
			get { throw new NotSupportedException("The method or operation is not implemented."); }
		}

		public override bool RequiresUniqueEmail
		{
			get { throw new NotSupportedException("The method or operation is not implemented."); }
		}

		public override string ResetPassword(string username, string answer)
		{
			throw new NotSupportedException("The method or operation is not implemented.");
		}

		public override bool UnlockUser(string userName)
		{
			throw new NotSupportedException("The method or operation is not implemented.");
		}

		public override void UpdateUser(MembershipUser user)
		{
			throw new NotSupportedException("The method or operation is not implemented.");
		}

		public override string ApplicationName
		{
			get
			{
				throw new NotSupportedException("The method or operation is not implemented.");
			}
			set
			{
				throw new NotSupportedException("The method or operation is not implemented.");
			}
		}

		#endregion

	}
}
