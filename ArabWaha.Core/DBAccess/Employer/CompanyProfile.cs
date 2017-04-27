using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArabWaha.Core.DBAccess.Employer
{
    public class CompanyProfile
    {
        [PrimaryKey, AutoIncrement]
        public Int32 id { get; set; }
        public int ProfileId { get; set; }
        public string JSON { get; set; }
    }
}
