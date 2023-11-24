using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Data;
using System.Transactions;
using TimeBlockData.Models;
using System.Data.SqlClient;
using System.Data;

namespace UserData.SQL
{
    public class SqlUserRepository : IUserRepository
    {
        private readonly string connectionString;

        public SqlUserRepository(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public User CreateUser(string firstName, string lastName, string email, string username, string passwordHash, bool isDeleted)
        {
            // Verify parameters.
            if (string.IsNullOrWhiteSpace(firstName))
                throw new ArgumentException("The parameter cannot be null or empty.", nameof(firstName));

            if (string.IsNullOrWhiteSpace(lastName))
                throw new ArgumentException("The parameter cannot be null or empty.", nameof(lastName));

            if (string.IsNullOrWhiteSpace(email))
                throw new ArgumentException("The parameter cannot be null or empty.", nameof(email));

            if (string.IsNullOrWhiteSpace(username))
                throw new ArgumentException("The parameter cannot be null or empty.", nameof(username));

            if (string.IsNullOrWhiteSpace(passwordHash))
                throw new ArgumentException("The parameter cannot be null or empty.", nameof(passwordHash));


            // Save to database.
            using (var transaction = new TransactionScope())
            {
                using (var connection = new SqlConnection(connectionString))
                {
                    using (var command = new SqlCommand("User.CreateUser", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;

                        command.Parameters.AddWithValue("FirstName", firstName);
                        command.Parameters.AddWithValue("LastName", lastName);
                        command.Parameters.AddWithValue("Email", email);
                        command.Parameters.AddWithValue("Username", username);
                        command.Parameters.AddWithValue("Password Hash", passwordHash);
                        command.Parameters.AddWithValue("IsDeleted", isDeleted);

                        var u = command.Parameters.Add("UserId", SqlDbType.Int);
                        u.Direction = ParameterDirection.Output;

                        connection.Open();

                        command.ExecuteNonQuery();

                        transaction.Complete();

                        var userId = (int)command.Parameters["UserId"].Value;

                        return new User(firstName, lastName, email, username, passwordHash, isDeleted);
                    }
                }
            }
        }

        public User GetUserById(int userId)
        {
            using (var connection = new SqlConnection(connectionString))
            {
                using (var command = new SqlCommand("User.GetUserById", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.AddWithValue("UserId", userId);

                    connection.Open();

                    using (var reader = command.ExecuteReader())
                    {
                        var user = TranslateUser(reader);

                        if (user == null)
                            throw new RecordNotFoundException(userId.ToString());

                        return user;
                    }
                }
            }
        }

        public User GetUserByEmail(string email)
        {
            using (var connection = new SqlConnection(connectionString))
            {
                using (var command = new SqlCommand("User.GetUserByEmail", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.AddWithValue("Email", email);

                    connection.Open();

                    using (var reader = command.ExecuteReader())
                        return TranslateUser(reader);
                }
            }
        }


        public User GetUserByUsername(string username)
        {
            using (var connection = new SqlConnection(connectionString))
            {
                using (var command = new SqlCommand("User.GetUserByUsername", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.AddWithValue("Username", username);

                    connection.Open();

                    using (var reader = command.ExecuteReader())
                        return TranslateUser(reader);
                }
            }
        }

        public IReadOnlyList<User> RetrieveUsers()
        {
            using (var connection = new SqlConnection(connectionString))
            {
                using (var command = new SqlCommand("User.RetrieveUsers", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    connection.Open();

                    using (var reader = command.ExecuteReader())
                        return TranslateUsers(reader);
                }
            }
        }

        private User TranslateUser(SqlDataReader reader)
        {
            var userIdOrdinal = reader.GetOrdinal("UserId");
            var firstNameOrdinal = reader.GetOrdinal("FirstName");
            var lastNameOrdinal = reader.GetOrdinal("LastName");
            var emailOrdinal = reader.GetOrdinal("Email");
            var usernameOrdinal = reader.GetOrdinal("Username");
            var passwordHashOrdinal = reader.GetOrdinal("PasswordHash");
            var isDeletedOrdinal = reader.GetOrdinal("IsDeleted");

            if (!reader.Read())
                return null;

            return new User(
               reader.GetInt32(userIdOrdinal),
               reader.GetString(firstNameOrdinal),
               reader.GetString(lastNameOrdinal),
               reader.GetString(emailOrdinal),
               reader.GetString(usernameOrdinal),
               reader.GetString(passwordHashOrdinal),
               reader.GetBool(isDeletedOrdinal));
        }

        private IReadOnlyList<User> TranslateUsers(SqlDataReader reader)
        {
            var users = new List<User>();

            var userIdOrdinal = reader.GetOrdinal("UserId");
            var firstNameOrdinal = reader.GetOrdinal("FirstName");
            var lastNameOrdinal = reader.GetOrdinal("LastName");
            var emailOrdinal = reader.GetOrdinal("Email");
            var usernameOrdinal = reader.GetOrdinal("Username");
            var passwordHashOrdinal = reader.GetOrdinal("PasswordHash");
            var isDeletedOrdinal = reader.GetOrdinal("IsDeleted");

            while (reader.Read())
            {
                users.Add(new User(
                   reader.GetInt32(userIdOrdinal),
                   reader.GetString(firstNameOrdinal),
                   reader.GetString(lastNameOrdinal),
                   reader.GetString(emailOrdinal),
                   reader.GetString(usernameOrdinal),
                   reader.GetString(passwordHashOrdinal),
                   reader.GetBool(isDeletedOrdinal)));
            }

            return users;
        }
    }
}