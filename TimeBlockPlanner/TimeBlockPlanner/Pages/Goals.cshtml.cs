using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Caching.Memory;
using UserData;
using UserData.Models;

namespace TimeBlockPlanner.Pages
{
    public class GoalsModel : PageModel
    {
        private const string connectionString = @"Server=(localdb)\reaganlocal;Database=rphazell;Integrated Security=SSPI;";
        private IGoalRepository repo = new SqlGoalRepository(connectionString);

        /// <summary>
        /// The timeblocks being displayed from the server to the user
        /// </summary>
        public IEnumerable<Goal> Goals { get { return repo.RetrieveGoals(UserId); } }

        /// <summary>
        /// Cache Storage to retrieve the userId
        /// </summary>
        private readonly IMemoryCache _cache;

        public int UserId
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
        }

        /// <summary>
        /// Method to handle post requests on the page
        /// </summary>
        public void OnPost(int GoalsId, string name, string description, DateTime startDate, DateTime endDate, bool isCompleted)
        {
            Console.WriteLine($"{GoalsId.ToString()}, {name}, {description}, {startDate.ToString()}, {endDate.ToString()}, {isCompleted}");

            if(isCompleted)
            {
                repo.SaveGoal(GoalsId, UserId, name, description, startDate, endDate, 0, "");
            }
            else
            {
                repo.SaveGoal(GoalsId, UserId, name, description, startDate, endDate, 1, "");
            }
        }
    }
}
