using ArabWaha.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArabWaha.Employer.StaticData
{
    public class WorkTypeEntry : EntryBase
    {
        // Their version should say Type..
        private WorkTimeEnum _workType;
        public WorkTimeEnum WorkType
        {
            get { return _workType; }
            set { SetProperty(ref _workType, value); }
        }

        protected override string Key => string.Format("{0}", Enum.GetName(typeof(WorkTimeEnum), _workType));

    }
}
