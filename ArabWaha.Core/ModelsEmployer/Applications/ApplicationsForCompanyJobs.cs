using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArabWaha.Core.ModelsEmployer
{
    // For a company we get the List of Jobs and its applications
    public class ApplicationsForCompanyJobs
    {
        public int CompanyId { get; set; }
        public ObservableCollection<ApplicationsForJob> Jobs;
    }
}
