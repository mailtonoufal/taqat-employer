using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArabWaha.Core.DBAccess
{
    public class Branches
    {
        [PrimaryKey, AutoIncrement]
        public Int32 id { get; set; }
        public Int32 BranchId { get; set; }
        public string BranchName { get; set; }
        public string BranchAddress { get; set; }
	    public double Longitude { get; set; }
        public double Latitude { get; set; }
        public string Image { get; set; }
    }
}
