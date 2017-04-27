using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArabWaha.Core.DBAccess
{
    public class ComplaintRaised
    {
        [PrimaryKey, AutoIncrement]
        public Int32 id { get; set; }
        public Int32 ComplaintId { get; set; }
        public string Subject { get; set; }
        public string Status { get; set; }
        public string CreatedOn { get; set; }
        public string ClosedOn { get; set; }
        public string ComplaintText { get; set; }
    }
}
