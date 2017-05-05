using ArabWaha.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArabWaha.Employer.StaticData
{
    public class RequiredEducationEntry : EntryBase
    {
        private RequiredEducationEnum _requiredEducation;
        public RequiredEducationEnum RequiredEducation
        {
            get { return _requiredEducation; }
            set { SetProperty(ref _requiredEducation, value); }
        }

        protected override string Key => string.Format("{0}", Enum.GetName(typeof(RequiredEducationEnum), RequiredEducation));

    }
}
