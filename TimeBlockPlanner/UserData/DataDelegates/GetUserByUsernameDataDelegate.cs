using DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserData.Models;

namespace UserData.DataDelegates
{
    public class GetUserByUsernameDataDelegate : DataReaderDelegate<User>
    {
        private readonly string username;

        public GetUserByUsernameDataDelegate(string username)
           : base("User.GetUserByUsername")
        {
            this.username = username;
        }

        public override void PrepareCommand(Command command)
        {
            base.PrepareCommand(command);

            command.Parameters.AddWithValue("Username", username);
        }

        public override User Translate(Command command, IDataRowReader reader)
        {
            if (!reader.Read())
                return null;

            return new User(
               reader.GetInt32("UserId"),
               username,
               reader.GetString("Email"),
               reader.GetString("FirstName"),
               reader.GetString("LastName"),
               reader.GetString("PasswordHash"),
               reader.GetInt32("IsDeleted"));
        }
    }
}