
using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArabWaha.Core.DBAccess.Employer
{
    public class MyServices
    {
        [PrimaryKey, AutoIncrement]
        public Int32 Id { get; set; }
        public Int32 ServiceId { get; set; }
        public string JSON { get; set; }
    }

    public class AllServices
    {
        [PrimaryKey, AutoIncrement]
        public Int32 Id { get; set; }
        public Int32 ServiceId { get; set; }
        public string JSON { get; set; }
    }

}
