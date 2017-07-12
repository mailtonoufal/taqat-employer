using System;
namespace ArabWaha.Employer.StaticData
{
    public class SortByEntryCMS:EntryBaseCMS
    {
        private string _Title;
        public string TextTitle
		{
			get { return _Title; }
			set { SetProperty(ref _Title, value); }
		}
		private string _Value;
		public string Value
		{
			get { return _Value; }
			set { SetProperty(ref _Value, value); }
		}

        protected override string Key => string.Format("{0}",_Title);
    }
}
