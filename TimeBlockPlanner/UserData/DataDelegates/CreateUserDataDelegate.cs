using UserData.Models;
using DataAccess;
using System.Data;
using System.Data.SqlClient;    // not sure why its not using this reference

namespace UserData.DataDelegates
{
    internal class CreateUserDataDelegate : NonQueryDataDelegate<User>
    {
       
        public readonly string userName;
        private readonly string email;
        public readonly string firstName;
        public readonly string lastName;
        public readonly string passwordHash;
        public readonly int isDeleted;


        public CreateUserDataDelegate(string userName, string email, string firstName, string lastName, string passwordHash, int isDeleted)
           : base("Person.CreateUser")
        {
            this.userName = userName;
            this.email = email;
            this.firstName = firstName;
            this.lastName = lastName;
            this.passwordHash = passwordHash;
            this.isDeleted = isDeleted;

        }

        public override void PrepareCommand(Command command)
        {
            base.PrepareCommand(command);

            command.Parameters.AddWithValue("UserName", userName);
            command.Parameters.AddWithValue("Email", email);
            command.Parameters.AddWithValue("FirstName", firstName);
            command.Parameters.AddWithValue("LastName", lastName);
            command.Parameters.AddWithValue("PasswordHash", passwordHash);
            command.Parameters.AddWithValue("IsDeleted", isDeleted);


            var p = command.Parameters.Add("UserId", SqlDbType.Int);     // addsing a person to the command 
            p.Direction = ParameterDirection.Output;                       // declaring the command as output for the store procedure 
        }

        public override User Translate(Command command)
        {
            return new User(command.GetParameterValue<int>("UserId"), userName, email, firstName, lastName, passwordHash, isDeleted);
        }
    }
}