using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArabWaha.Core.DBAccess.Employer
{
    public class CompanyUser
    {
        [PrimaryKey, AutoIncrement]
        public Int32 id { get; set; }
        public int UserId { get; set; }
        public string UserRole { get; set; }
        public string JSON { get; set; }
    }
}
