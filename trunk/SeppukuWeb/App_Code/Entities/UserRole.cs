using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DN.Domain
{
    public class UserRole
    {
        public int UserRoleId { get; set; }
        public int UserId { get; set; }
        public int RoleId { get; set; }
    }
}