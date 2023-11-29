using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Caching.Memory;
using UserData;
using UserData.Models;


namespace TimeBlockPlanner.Pages
{
    public class TimeBlockModel : PageModel
    {
        private const string connectionString = @"Server=(localdb)\reaganlocal;Database=rphazell;Integrated Security=SSPI;";
        private ITimeBlockRepository repo = new SqlTimeBlockRepository(connectionString);

        /// <summary>
        /// The timeblocks being displayed from the server to the user
        /// </summary>
        public IEnumerable<TimeBlock> TimeBlocks { 
            get
            {
                return repo.RetrieveTimeBlocks(UserId);
            } 
        }

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
        public TimeBlockModel(IMemoryCache cache)
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
        public void OnPost(int TimeBlockId, TimeSpan time, string name, string description) 
        {
            repo.SaveTimeBlock(2, UserId, name, description, DateTime.Now, (new DateTime(2012, 01, 01) + time));
        }
    }
}
