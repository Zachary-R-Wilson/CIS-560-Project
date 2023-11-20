using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserData.Models
{
    public class User
    {
        public int UserID { get; }

        public string Username { get; }

        public string Email { get; }

        public string FirstName { get; }

        public string LastName { get; }

        public string PasswordHash { get; }

        public bool IsDeleted = false;

        public User(int userID, string un, string email, string fn, string ln, string passhash, bool isDeleted)
        {
            UserID = userID;
            Username = un;
            Email = email;
            FirstName = fn;
            LastName = ln;
            PasswordHash = passhash;
            IsDeleted = isDeleted;
        }
    }
}
