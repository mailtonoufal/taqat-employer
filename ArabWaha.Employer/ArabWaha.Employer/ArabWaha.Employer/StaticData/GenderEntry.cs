using ArabWaha.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArabWaha.Employer.StaticData
{
    public class GenderEntry : EntryBase
    {
        private GenderEnum _gender;
        public GenderEnum Gender
        {
            get { return _gender; }
            set { SetProperty(ref _gender, value); }
        }
        protected override string Key => string.Format("GENDER_{0}", Enum.GetName(typeof(GenderEnum), _gender));

    }
}
