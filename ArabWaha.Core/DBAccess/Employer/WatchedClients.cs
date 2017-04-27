using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArabWaha.Core.DBAccess.Employer
{
    public class WatchedClients
    {
        [PrimaryKey, AutoIncrement]
        public Int32 id { get; set; }
        public string JobPostId { get; set; }
        public string ProfileId { get; set; }
        public string JSON { get; set; }

        public string AddedById { get; set; }
        public string AddedWhen { get; set; }
    }
}
