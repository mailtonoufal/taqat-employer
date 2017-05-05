using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArabWaha.Core.DBAccess
{
    public class Badges
    {
        [PrimaryKey, AutoIncrement]
        public Int32 id { get; set; }
        public Int32 BadgeId { get; set; }
        public string BadgeName { get; set; }
        public string BadgeDescription { get; set; }
        public string BadgeStatus { get; set; }
        public string BadgeIcon { get; set; }
  
      

        public Int32 Locked { get; set; } // 0 = Locked   1 = unlocked 

    }
}
