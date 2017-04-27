using ArabWaha.Models.Search;
using System.Collections.Generic;

namespace ArabWaha.Models.Dummy
{
    public static class DummyComplainList
    {
        public static ComplaintsListRoot complainsStaticList => new ComplaintsListRoot
        {
            complaintsList = new ComplaintsList
            {
                complaints = new List<Complaints>
                {
                    new Complaints
                    {
                        AppealId = "Developer",
                        Complaint_Id = "2 months ago",
                        ClosedOn = "Xamarin",
                        CreatedOn = "London",
                        Description = "50"
                    },
                    new Complaints
                    {
                        AppealId = "Developer",
                        Complaint_Id = "2 months ago",
                        ClosedOn = "Xamarin",
                        CreatedOn = "London",
                        Description = "50"
                    },
                }
            }
        };
    }
}