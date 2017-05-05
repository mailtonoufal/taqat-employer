using ArabWaha.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArabWaha.Employer.StaticData
{
    public class TeleWorkingEntry : EntryBase
    {
        private TeleWorkingEnum _teleworking;
        public TeleWorkingEnum TeleWorking
        {
            get { return _teleworking; }
            set { SetProperty(ref _teleworking, value); }
        }

        protected override string Key => string.Format("{0}", Enum.GetName(typeof(TeleWorkingEnum), _teleworking));

    }
}
