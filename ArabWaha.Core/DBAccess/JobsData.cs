using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArabWaha.Core.DBAccess
{
    public class JobsData
    {
        [PrimaryKey, AutoIncrement]
        public Int32 Id { get; set; }
        public string JobPostId { get; set; }
        public string JSON { get; set; }
    }
}
