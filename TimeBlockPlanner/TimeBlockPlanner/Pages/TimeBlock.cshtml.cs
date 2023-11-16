using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace TimeBlockPlanner.Pages
{
    public class TimeBlockModel : PageModel
    {
        /// <summary>
        /// The timeblocks being displayed from the server to the user
        /// </summary>
        /// <remarks>The type here is not int but rather the model type.</remarks>
        public IEnumerable<int> TimeBlocks { get; set; }


        /// <summary>
        /// Method to handle get requests on the page
        /// </summary>
        public void OnGet()
        {
            // This is where a call to the server will be made to get the information to display the data to the frontend user
                                // new list<int> will be replaced with a call to the server for data.
            this.TimeBlocks = new List<int>();
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
