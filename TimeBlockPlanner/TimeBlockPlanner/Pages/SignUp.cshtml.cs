using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;

namespace TimeBlockPlanner.Pages
{
    public class SignUpModel : PageModel
    {
        public void OnGet()
        {
        }

        public void OnPost() 
        {

            // Check that passwords match

            // Check that username/email is not already in use

            // Insert into database
        }
    }
}
