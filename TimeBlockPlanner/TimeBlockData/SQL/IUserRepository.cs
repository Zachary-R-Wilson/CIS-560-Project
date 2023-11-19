using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TimeBlockData.Models;


namespace UserData.SQL
{
    public class IUserRepository
    {
        /// <summary>
        /// Retrieves all users in the database
        /// </summary>
        /// <returns>IReadOnlyList<User> list containing all users in the database</returns>
        IReadOnlyList<User> RetrieveUser();

        /// <summary>
        /// Fetches the user associated with the given <paramref name="userId"/> if they exist.
        /// </summary>
        /// <param name="userId"></param>
        /// <returns>Returns the user object matching the given userId</returns>
        User GetUserById(int userId);


        /// <summary>
        /// Fetches the user associated with the given <paramref name="userEmail"/> if they exist.
        /// </summary>
        /// <param name="userEmail"></param>
        /// <returns>Returns the user object matching the given userEmail</returns>
        User GetUserByEmail(string email);


        /// <summary>
        /// Fetches the user associated with the given <paramref name="username"/> if they exist.
        /// </summary>
        /// <param name="username"></param>
        /// <returns>Returns the user object matching the given username</returns>
        User GetUserByUsername(string username);


        /// <summary>
        /// Creates a new user. 
        /// </summary>
        /// <param name="firstName">First name of the user</param>
        /// <param name="lastName">Last name of the user</param>
        /// <param name="email">Email of the user</param>
        /// <returns>Returns the resulting new user objecct containing parameter defined attributes</returns>
        User CreateUser(string firstName, string lastName, string email, string username, string passwordHash, bool isDeleted);
    }
}
