using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Caching.Memory;
using TimeBlockData.Models;

namespace TimeBlockPlanner.Pages
{
    public class GoalsModel : PageModel
    {
        /// <summary>
        /// The timeblocks being displayed from the server to the user
        /// </summary>
        public IEnumerable<Goals> Goals { get; set; }

        /// <summary>
        /// Cache Storage to retrieve the userId
        /// </summary>
        private readonly IMemoryCache _cache;

        public int userId
        {
            get
            {
                int uId;
                _cache.TryGetValue("userId", out uId);
                return uId;
            }
        }

        /// <summary>
        /// Initializes the private Cache field
        /// </summary>
        public GoalsModel(IMemoryCache cache)
        {
            _cache = cache;
        }

        /// <summary>
        /// Method to handle get requests on the page
        /// </summary>
        public void OnGet()
        {
            // Check for the userId to see if the user is logged in.
            int uId;
            _cache.TryGetValue("userId", out uId);
            if (uId == default(int))
            {
                Response.Redirect("SignIn");
            }
            _cache.Get("");

            // This is where a call to the server will be made to get the information to display the data to the frontend user
            // new list<int> will be replaced with a call to the server for data.
            this.Goals = new List<Goals>();
        }

        /// <summary>
        /// Method to handle post requests on the page
        /// </summary>
        public void OnPost(int? GoalsId, string name, string description, DateTime startDate, DateTime endDate)
        {
            Console.WriteLine($"{GoalsId.ToString()}, {name}, {description}, {startDate.ToString()}, {endDate.ToString()}");

            // A return query will be required to display the back to the user and update the table
            if (GoalsId != null)
            {
                //update the table
            }
            else
            {
                //insert new row into the table
            }
        }
    }
}
