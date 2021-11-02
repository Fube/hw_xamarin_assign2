using SQLite;
using SQLiteNetExtensions.Attributes;
using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace Assign2
{
    public class User
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Phone { get; set; }
        [ManyToMany(typeof(UserRole), CascadeOperations = CascadeOperation.All)]
        public List<Role> Roles { get; set; }

        public bool IsAdmin => Roles?.Any(n => n.Name.Equals("ADMIN", StringComparison.OrdinalIgnoreCase)) ?? false;
        public bool IsInternal => Roles?.Any(n => n.Name.Equals("INTERNAL", StringComparison.OrdinalIgnoreCase)) ?? false;
        public bool IsViewer => Roles?.Any(n => n.Name.Equals("VIEWER", StringComparison.OrdinalIgnoreCase)) ?? false;


        public bool IsValid(out string message)
        {
            message = default;
            if(Password.Length >= 10)return true;

            message = "Password length must be greater than or equal to 10 characters";

            return false;
        }

        public void Deconstruct(out int id, out string username, out string email, out string password, out string phone)
        {
            id = ID;
            username = Username;
            email = Email;
            password = Password;
            phone = Phone;
        }
    }
}
