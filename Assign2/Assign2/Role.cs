using SQLite;
using SQLiteNetExtensions.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace Assign2
{
    public class Role
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }

        public string Name { get; set; }

        [ManyToMany(typeof(UserRole))]
        public IList<User> Users { get; set; }
    }
}
