using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArabWaha.Core.ModelsEmployer
{
    public class ApplicantProfile
    {
        public int ApplicantId { get; set; }
        public string Name { get; set; }
        public string Occupation { get; set; }
        public string Gender { get; set; }
        public string Location { get; set; }
        public int Score { get; set;  }
    }
}
