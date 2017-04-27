using ArabWaha.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArabWaha.Core.ModelsIndividual.Programs
{
    public class MyProgramItem
    {
        public string ProgramID { get; set; }
        public string Title { get; set; }
        public string programStatus { get; set; }

        public Program  ProgramDetails { get; set; }
    }
}
