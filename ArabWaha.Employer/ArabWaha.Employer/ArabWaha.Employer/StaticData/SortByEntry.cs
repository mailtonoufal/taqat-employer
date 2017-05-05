using ArabWaha.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArabWaha.Employer.StaticData
{
    public class SortByEntry : EntryBase
    {


       private SortByEnum _sortBy;
        public SortByEnum SortBy
        {
            get { return _sortBy; }
            set { SetProperty(ref _sortBy, value); }
        }

        protected override string Key => string.Format("SORTBY_{0}", Enum.GetName(typeof(SortByEnum), _sortBy));
 
    }
}
