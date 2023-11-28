using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Caching.Memory;
using UserData.Models;


namespace TimeBlockPlanner.Pages
{
    public class TimeBlockModel : PageModel
    {
        /// <summary>
        /// The timeblocks being displayed from the server to the user
        /// </summary>
        public IEnumerable<TimeBlock> TimeBlocks { get; set; }

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

            // This is where a call to the server will be made to get the information to display the data to the frontend user
            // new list<int> will be replaced with a call to the server for data.
            this.TimeBlocks = new List<TimeBlock>();


           // 
        }

        /// <summary>
        /// Method to handle post requests on the page
        /// </summary>
        public void OnPost(int? TimeBlockId, TimeSpan time, string name, string description) 
        {
            // When a post is made, we are either updating a current row
            // or we are inserting a new row into the database.
            // A row is to be updated if there is a TimeBlockId, otherwise it should be inserted

            Console.WriteLine($"{TimeBlockId.ToString()}, {time.ToString()}, {name}, {description}");

            // A return query will be required to display the back to the user and update the table
            if(TimeBlockId != null)
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
