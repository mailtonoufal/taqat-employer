using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArabWaha.Core.DBAccess
{
    // value lists for app
    public class AppValues
    {
        [PrimaryKey, AutoIncrement]
        public Int32 id { get; set; }
        public string Key { get; set; }
        public string ParentKey { get; set; }
        public string Value { get; set; }
        public string CatType { get; set; }
        public string English { get; set; }
        public string Arabic { get; set; }
    }
}
