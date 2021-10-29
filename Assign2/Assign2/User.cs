using SQLite;
using SQLiteNetExtensions.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

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
        [ManyToMany(typeof(UserRole))]
        public IList<Role> Roles { get; set; }
        

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
