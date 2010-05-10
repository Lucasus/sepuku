﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Seppuku.Core;

namespace Seppuku.Domain
{
    public class User
    {
        public int UserId { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public DateTime CreateDate { get; set; }
        public string PasswordHash { get; set; }
        public Guid AuthorizatonKey { get; set; }

        public string Password
        {
            set
            {
                PasswordHash = DNMembershipProvider.CreatePasswordHash(value);
            }
        }

        public User()
        {
        }
    }
}