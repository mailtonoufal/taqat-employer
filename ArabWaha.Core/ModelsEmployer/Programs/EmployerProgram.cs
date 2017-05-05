using ArabWaha.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArabWaha.Core.ModelsEmployer.Programs
{
    public class EmployerProgram : Program
    {
        [JsonProperty("ProgramUrl")]
        public string ProgramUrl { get; set; }

        [JsonIgnore]
        public string StatusLabelText { get; set; }

        [JsonIgnore]
        public string GetStatusText
        {
            get
            {
                return $"{StatusLabelText} {Status} ";
            }
        }
    }
}
