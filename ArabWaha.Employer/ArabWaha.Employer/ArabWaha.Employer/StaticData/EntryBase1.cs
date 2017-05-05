using ArabWaha.Core.BaseClasses;
using ArabWaha.Employer.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// Used to build up lists of options based on the static data/enums within the system
namespace ArabWaha.Employer.StaticData
{

    public class EntryBase1<TEnum> : MVVMBase
    {


        private TEnum _enumVal;
        public TEnum EnumVal
        {
            get { return _enumVal; }
            set { SetProperty(ref _enumVal, value); }
        }

        private bool _selected;
        public bool Selected
        {
            get { return _selected; }
            set { SetProperty(ref _selected, value); }
        }

        protected virtual string Key { get; }

        // need to get the text data from the Resource file based on the Enum name
        // eg. "JOBTYPE_"  "PERM"  returns the local string for JOBTYPEENUM_PERM so we can use resouce from existing....

        protected string _text;
        public virtual string Text
        {
            get
            {
                if (string.IsNullOrEmpty(Key))
                    return _text;

                _text = TranslateExtension.GetString(Key);
                return _text;

            }
            set { SetProperty(ref _text, value); }
        }

        protected string _description;
        public virtual string Description
        {
            get
            {
                if (string.IsNullOrEmpty(Key))
                    return _description;

                _description = TranslateExtension.GetString($"{Key}_DESC");
                return _description;

            }
            set { SetProperty(ref _description, value); }
        }


    }
}
