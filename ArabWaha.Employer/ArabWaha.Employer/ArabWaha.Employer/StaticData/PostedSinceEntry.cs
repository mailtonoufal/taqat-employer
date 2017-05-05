using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArabWaha.Employer.StaticData
{
    public class PostedSinceEntry : EntryBase
    {
        private string _id;
        public string Id
        {
            get { return _id; }
            set { SetProperty(ref _id, value); }
        }

        protected override string Key => string.Format("POSTED_{0}", Id.ToUpper());

    }
}
