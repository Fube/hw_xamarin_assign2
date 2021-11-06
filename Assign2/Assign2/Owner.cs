using SQLite;
using SQLiteNetExtensions.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace Assign2
{
    public class Owner
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }
        
        [ForeignKey(typeof(User))]
        public int UserID { get; set; }
        [OneToOne]
        public User User { get; set; }

        [OneToMany]
        public List<Pet> Pets { get; set; }
    }
}
