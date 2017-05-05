using ArabWaha.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArabWaha.Employer.StaticData
{
    public class SpecializationEntry : EntryBase
    {
        private SpecilizationEnum _specialization;
        public SpecilizationEnum Specialization
        {
            get { return _specialization; }
            set { SetProperty(ref _specialization, value); }
        }

        protected override string Key => string.Format("{0}", Enum.GetName(typeof(SpecilizationEnum), Specialization));

    }
}
