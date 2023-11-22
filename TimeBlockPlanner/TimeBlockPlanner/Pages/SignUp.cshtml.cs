using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;

namespace TimeBlockPlanner.Pages
{
    public class SignUpModel : PageModel
    {
        [BindProperty]
        public CreateUser CreateUser { get; set; }

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
            if (ModelState.IsValid){}
            else{}

            // Insert into database
        }
    }
}
