using ArabWaha.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArabWaha.Employer.StaticData
{
    public class TravellingRequiredEntry : EntryBase
    {
        private TravellingRequiredEnum _travellingRequired;
        public TravellingRequiredEnum TravellingRequired
        {
            get { return _travellingRequired; }
            set { SetProperty(ref _travellingRequired, value); }
        }

        protected override string Key => string.Format("TRAV_{0}", Enum.GetName(typeof(TravellingRequiredEnum), _travellingRequired));

    }
}
