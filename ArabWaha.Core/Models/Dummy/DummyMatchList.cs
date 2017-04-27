using ArabWaha.Models.Search;
using System.Collections.Generic;

namespace ArabWaha.Models.Dummy
{
    public static class DummyMatchList
    {
        public static SearchRoot searchStaticList => new SearchRoot
        {
            SearchData = new SearchData
            {
                SearchResults = new List<SearchResults>
                {
                    new SearchResults
                    {
                        JobPostTitle = "Developer",
                        StartDate = "2 months ago",
                        EmployerId = "Xamarin",
                        Location = "London",
                        MatchScore = "50"
                    },
                    new SearchResults
                    {
                        JobPostTitle = "Developer",
                        StartDate = "2 months ago",
                        EmployerId = "Xamarin",
                        Location = "London",
                        MatchScore = "50"
                    },
                }
            }
        };
    }
}