using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Caching.Memory;
using System.Security.Cryptography;
using System.Text;
using UserData;
using UserData.Models;

namespace TimeBlockPlanner.Pages
{
    public class SignInModel : PageModel
    {
        [BindProperty]
        public SignInUser SignInUser { get; set; }

        /// <summary>
        /// Cache Storage to retrieve the userId
        /// </summary>
        private readonly IMemoryCache _cache;

        private const string connectionString = @"Server=(localdb)\reaganlocal;Database=rphazell;Integrated Security=SSPI;";
        private IUserRepository repo = new SqlUserRepository(connectionString);

        /// <summary>
        /// Initializes the private Cache field
        /// </summary>
        public SignInModel(IMemoryCache cache)
        {
            _cache = cache;
        }

        public void OnGet()
        {
            int uId;
            _cache.TryGetValue("userId", out uId);

            // if user is signed in
            if(uId != default(int))
            {

            }
        }

        public void OnPost()
        {
            User user = repo.GetUserByUsername(SignInUser.username);
            if(user != null) 
            {
                //Check if user is in DB
                using (var md5Hash = MD5.Create())
                {
                    var sourceBytes = Encoding.UTF8.GetBytes(SignInUser.password);
                    var hashBytes = md5Hash.ComputeHash(sourceBytes);
                    var hash = BitConverter.ToString(hashBytes).Replace("-", string.Empty);
                    if (user.PasswordHash != hash)
                    {
                        ModelState.AddModelError("SignInUser.password", "Password is Incorrect");
                    }
                }

                //if valid login then create a cache of their userId:
                using (var cacheEntry = _cache.CreateEntry("userId"))
                {
                    cacheEntry.Value = user.UserId;
                }
            }
            else
            {
                ModelState.AddModelError("SignInUser.username", "Username does not exist");
            }
        }

    }
}
