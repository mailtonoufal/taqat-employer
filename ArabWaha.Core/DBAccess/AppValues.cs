﻿using SQLite;
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
        public string Value { get; set; }
        public string LabelValue { get; set; }
        public string LabelValueArabic { get; set; }
    }
}
