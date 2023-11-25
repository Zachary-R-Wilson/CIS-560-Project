using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess;
using UserData.Models;

namespace UserData.DataDelegates
{
    internal class GetUserByIdDataDelegate : DataReaderDelegate<User>
    {
        private readonly int userId;

        public GetUserByIdDataDelegate(int userId)
           : base("User.GetUserById")
        {
            this.userId = userId;
        }

        public override void PrepareCommand(Command command)
        {
            base.PrepareCommand(command);

            var p = command.Parameters.Add("UserId", SqlDbType.Int);
            p.Value = userId;
        }

        public override User Translate(Command command, IDataRowReader reader)
        {
            if (!reader.Read())
                throw new RecordNotFoundException(userId.ToString());

            return new User(userId,
               reader.GetString("Username"),
               reader.GetString("Email"),
               reader.GetString("FirstName"),
               reader.GetString("LastName"),
               reader.GetString("PasswordHash"),
               reader.GetBoolean("IsDeleted"));
        }
    }
}
