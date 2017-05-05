using ArabWaha.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArabWaha.Employer.StaticData
{
    public class JobTypeEntry : EntryBase
    {
        
        private JobTypeEnum _jobTypeEnum;
        public JobTypeEnum JobType
        {
            get { return _jobTypeEnum; }
            private set { SetProperty(ref _jobTypeEnum, value); }
        }

        // it looks like We only get the string Values from the API - so convert the string to Enum 
        private string _jobTypeText;
        public string JobTypeText
        {
            get {
                    return _jobTypeText;
                }
            set {
                    SetProperty(ref _jobTypeText, value);
                    // Set the Value based on the text
                    JobType = JobType.FromString(_jobTypeText);
                }
        }

        protected override string Key => JobType.TranslateKey();


    }
}
