using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess;
using UserData.Models;

namespace UserData.DataDelegates
{
    internal class RetrieveUsersDataDelegate : DataReaderDelegate<IReadOnlyList<User>>
    {
        public RetrieveUsersDataDelegate()
           : base("User.RetrieveUsers")
        {
        }

        public override IReadOnlyList<User> Translate(Command command, IDataRowReader reader)
        {
            var users = new List<User>();

            while (reader.Read())
            {
                users.Add(new User(
               reader.GetInt32("UserId"),
               reader.GetString("Username"),
               reader.GetString("Email"),
               reader.GetString("FirstName"),
               reader.GetString("LastName"),
               reader.GetString("PasswordHash"),
               reader.GetBoolean("IsDeleted")));
            }
            return users;
        }
    }
}