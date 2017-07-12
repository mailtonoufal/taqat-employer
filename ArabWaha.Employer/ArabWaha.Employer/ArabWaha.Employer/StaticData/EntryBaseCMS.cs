using System;
using ArabWaha.Core.BaseClasses;
using ArabWaha.Employer.Helpers;

namespace ArabWaha.Employer.StaticData
{
    public class EntryBaseCMS : MVVMBase
    {
		private bool _selected;
        CMSTranslateExtension tran = new CMSTranslateExtension();
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

                _text = tran.GetProviderValueString(Key);
				return _text;

			}
			set { SetProperty(ref _text, value); }
		}
	}
}
