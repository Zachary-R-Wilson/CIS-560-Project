using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Caching.Memory;

namespace TimeBlockPlanner.Pages
{
    public class SignInModel : PageModel
    {
        /// <summary>
        /// Cache Storage to retrieve the userId
        /// </summary>
        private readonly IMemoryCache _cache;

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
            //Check if user is in DB

            //if valid login then create a cache of their userId:
            using (var cacheEntry = _cache.CreateEntry("userId"))
            {
                cacheEntry.Value = 1;
            }
        }

    }
}
