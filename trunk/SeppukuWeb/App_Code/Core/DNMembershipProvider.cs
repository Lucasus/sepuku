using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Security;
using System.Security.Cryptography;
using System.Web;
using DN.DAO;
using DN.Domain;

namespace DN.Core
{
    public class DNMembershipProvider : SqlMembershipProvider
    {
        public override bool EnablePasswordReset        {  get { return true;  }  }
        public override bool RequiresQuestionAndAnswer  {  get { return false; }  }
        public override int  MaxInvalidPasswordAttempts {  get { return 50;    }  }
        public override bool EnablePasswordRetrieval    {  get { return false; }  }
        public override int  MinRequiredPasswordLength  {  get { return 6;     }  }

        public override MembershipPasswordFormat PasswordFormat
        {
            get { return MembershipPasswordFormat.Hashed; }
        }


        public override MembershipUser CreateUser(string username,
                     string password,
                     string email,
                     string passwordQuestion,
                     string passwordAnswer,
                     bool isApproved,
                     object providerUserKey,
                     out MembershipCreateStatus status)
        {
            ValidatePasswordEventArgs args = new ValidatePasswordEventArgs(username, password, true);
            OnValidatingPassword(args);
            if (args.Cancel)
            {
                status = MembershipCreateStatus.InvalidPassword;
                return null;
            }

            if (RequiresUniqueEmail && !String.IsNullOrEmpty(GetUserNameByEmail(email)))
            {
                status = MembershipCreateStatus.DuplicateEmail;
                return null;
            }

            MembershipUser u = GetUser(username, false);

            if (u == null)
            {
                DateTime createDate = DateTime.Now;

                if (providerUserKey == null)
                    providerUserKey = Guid.NewGuid();
                else if (!(providerUserKey is Guid))
                {
                    status = MembershipCreateStatus.InvalidProviderUserKey;
                    return null;
                }

                User user = new User()
                {
                    UserId = 0,
                    CreateDate = DateTime.Now,
                    Email = email,
                    UserName = username,
                    PasswordHash = CreatePasswordHash(password),
                    AuthorizatonKey = (Guid)providerUserKey
                };

                int userId = new UserDAO().Add(user);
                MembershipUser mUser = getMembershipUserFromDnUser(user);

                if (userId > 0)
                    status = MembershipCreateStatus.Success;
                else
                   status = MembershipCreateStatus.UserRejected;

                return mUser;
            }
            else
            {
                status = MembershipCreateStatus.DuplicateUserName;
            }
            return null;
        }



        public override MembershipUser  GetUser(string username, bool userIsOnline)
        {
            UserDAO userDao = new UserDAO();
            CommandStatus status = new CommandStatus();

            User user = userDao.GetByUserName(username, status);
            MembershipUser mUser =null;
            if(user.UserId != 0)
            {
                mUser = getMembershipUserFromDnUser(user);
            }
 	        return mUser;
        }

        public override MembershipUserCollection GetAllUsers(int pageIndex, int pageSize, out int totalRecords)
        {
            MembershipUserCollection membershipUsers = new MembershipUserCollection();
            totalRecords = new UserDAO().GetUsersCount();

            if (totalRecords <= 0) { return membershipUsers; }

            IList<User> users = new UserDAO().GetAll();
            
            int startIndex = pageSize * pageIndex;
            int endIndex = startIndex + pageSize - 1;

            for (int i = startIndex; i < users.Count && i < endIndex; ++i)
            {
                MembershipUser u = getMembershipUserFromDnUser(users[i]);
                membershipUsers.Add(u);
            }

            return membershipUsers;
        }

        public override string GetUserNameByEmail(string email)
        {
            return new UserDAO().GetByUserEmail(email).UserName;
        }

        public override bool ValidateUser(string username, string password)
        {
            string passwordHash = CreatePasswordHash(password);
            return new UserDAO().ValidateUser(username, passwordHash);
        }

        private string CreatePasswordHash(string password)
        {
            if (String.IsNullOrEmpty(password))
                return String.Empty;

            byte[] data = new byte[password.Length];
            byte[] result;
            data = Encoding.UTF8.GetBytes("lkjfsd8908fu9p5aoekvfjsd94wpochf" + password);
            SHA1 sha = new SHA1CryptoServiceProvider();
            result = sha.ComputeHash(data);
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < result.Length; i++)
            {
                sb.Append(result[i].ToString("X2"));
            }
            return sb.ToString();
        }

        private MembershipUser getMembershipUserFromDnUser(User user)
        {
            MembershipUser mUser = new MembershipUser("DNMembershipProvider",
                                    user.UserName,
                                    user.AuthorizatonKey,
                                    user.Email,
                                    null,                       // passwordAnswer
                                    null,                       // passwordQuestion
                                    true,                       // isAproved 
                                    false,
                                    user.CreateDate,
                                    new DateTime(2009, 01, 01),
                                    new DateTime(2009, 01, 01),
                                    new DateTime(2009, 01, 01),
                                    new DateTime(2009, 01, 01));
            return mUser;
        }
    }
}
