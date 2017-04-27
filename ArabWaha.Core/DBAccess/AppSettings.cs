using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ArabWaha.Core.DBAccess
{
    public class AppSettings
    {
        [PrimaryKey, AutoIncrement]
        public Int64 id { get; set; }

        [MaxLength(100)]
        public string Key { get; set; }

        [MaxLength(255)]
        public String Value { get; set; }

        [MaxLength(255)]
        public String TextValue { get; set; }
    }
}
