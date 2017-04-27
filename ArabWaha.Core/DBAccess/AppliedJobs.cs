using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArabWaha.Core.DBAccess
{
    public class AppliedJobs
    {
        [PrimaryKey, AutoIncrement]
        public Int32 id { get; set; }
        public string JobPostId { get; set; }
        public string ApplicationStatus { get; set; }
        public int NesIndividualID { get; set; }
        public int ApplicationID { get; set; }
        public string ApplicationDate { get; set; }
        public string CoverletterId { get; set; }
    }
}
