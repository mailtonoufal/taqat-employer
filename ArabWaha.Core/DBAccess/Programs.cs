using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;

namespace ArabWaha.Core.DBAccess
{
    public class Programs
    {
        [PrimaryKey, AutoIncrement]
        public Int32 Id { get; set; }
        public Int32 ProgramId { get; set; }
        public string JSON { get; set; }
    }
}
