﻿using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArabWaha.Core.DBAccess
{
    public class WatchedJobs
    {
        [PrimaryKey, AutoIncrement]
        public Int32 id { get; set; }
        public string JobPostId { get; set; }
    }
}
