using SQLiteNetExtensions.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace Assign2
{
    public class UserRole
    {
        [ForeignKey(typeof(User))]
        public int UserId { get; set; }

        [ForeignKey(typeof(Role))]
        public int RoleId { get; set; }
    }
}
