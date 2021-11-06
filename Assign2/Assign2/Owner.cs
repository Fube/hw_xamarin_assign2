using SQLiteNetExtensions.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace Assign2
{
    public class Owner
    {
        public int ID { get; set; }
        [OneToOne]
        public User User { get; set; }
        [OneToMany]
        public List<Pet> Pets { get; set; }
    }
}
