using ArabWaha.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArabWaha.Employer.StaticData
{
    public class ShiftTypeEntry : EntryBase
    {
        private ShiftTypeEnum _shiftType;
        public ShiftTypeEnum ShiftType
        {
            get { return _shiftType; }
            set { SetProperty(ref _shiftType, value); }
        }

        protected override string Key => string.Format("{0}", Enum.GetName(typeof(ShiftTypeEnum), _shiftType));

    }
}
