using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArabWaha.Core.ModelsEmployer
{
    public class ApplicationProfile
    {
        public int ApplicationId { get; set; }
        public int JobPostId { get; set; }
        public int ProfileId { get; set; }
        // Aplicant Detials - probably in Model - based on ProfileId
        public string Name { get; set; }
        public string Occupation { get; set; }
        public string Gender { get; set; }
        public string Location { get; set; }
        public int MatchScore { get; set;  }

        public string Availability { get; set;  }
        public DateTime ApplicationDate { get; set; } = DateTime.Now;

        // Use JobDetailAttachments from Model (Individual as will be the same data)
        public ObservableCollection<JobDetailAttachments> Attachments { get; set; }
        //ApplcationID
        //List of Attachments
        //    Filename
        //    Icon
        //    UlrLink

    }
}
