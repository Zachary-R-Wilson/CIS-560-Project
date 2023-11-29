using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;
using UserData;
using System.Security.Cryptography;
using System.Text;

namespace TimeBlockPlanner.Pages
{
    public class SignUpModel : PageModel
    {
        [BindProperty]
        public CreateUser CreateUser { get; set; }

        private const string connectionString = @"Server=(localdb)\reaganlocal;Database=rphazell;Integrated Security=SSPI;";
        private IUserRepository repo = new SqlUserRepository(connectionString);

        public void OnGet()
        {
             
        }

        public void OnPost() 
        {

            // Check that passwords match
            if(CreateUser.password != CreateUser.passwordConfirm)
            {
                ModelState.AddModelError("CreateUser.password", "Passwords do not match.");
                ModelState.AddModelError("CreateUser.passwordConfirm", "Passwords do not match.");
            }

            // Check that username/email is not already in use

            // Check all are filled out
            if (ModelState.IsValid)
            {
                using (var md5Hash = MD5.Create())
                {
                    var sourceBytes = Encoding.UTF8.GetBytes(CreateUser.password);
                    var hashBytes = md5Hash.ComputeHash(sourceBytes);
                    var hash = BitConverter.ToString(hashBytes).Replace("-", string.Empty);
                    repo.CreateUser(CreateUser.firstName, CreateUser.lastName, CreateUser.email, CreateUser.username, hash, 1);
                }
            }
        }
    }
}
