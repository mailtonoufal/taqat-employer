using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArabWaha.Core.ModelsEmployer.Services
{
    public class EmployerService
    {
        public int ServiceId { get; set; }
        public string ServiceName { get; set; }
        public string  ServiceUrl { get; set; }

        public string Introduction { get; set; }

        public string Benefits { get; set; }

        public string Beneficiaries { get; set; }

        public string HowToRegister { get; set; }
    }
}
