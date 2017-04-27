using ArabWaha.Core.Helpers;
using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArabWaha.Core.DBAccess
{
    public class EventDetails
    {
        [PrimaryKey, AutoIncrement]
        public Int32 id { get; set; }
        public Int32 EventId { get; set; }
        public string JobPostId { get; set; }

        public string EventTitle { get; set; }
        public string EventStart { get; set; }
        public string EventEnd { get; set; }
        public string EventLocation { get; set; }

        public string Status { get; set; }

        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public string AdditionalInfo { get; set; }

        [Ignore]
        public string TitleInfo
        {
            get
            {
                var stat = string.IsNullOrEmpty(Status) ? "Pending" : Status;
                return $"{EventTitle} ({stat})";
            }
        }

        [Ignore]
        public string EventDateInfo
        {
            get
            {
                var dateFormat = UtilHelper.GetDateFromString(EventStart);

                string dater = dateFormat.ToString("dd MMM");

                // construct format we need here
                var baseInfo = $"{dater}, {UtilHelper.GetTimeOnlyfromSqlDate(EventStart)} -  {UtilHelper.GetTimeOnlyfromSqlDate(EventEnd)}" ;

                return baseInfo;
            }
        }

        [Ignore]
        public string AddressInfo
        {
            get
            {
                var info = string.IsNullOrEmpty(EventTitle) ? "" : EventTitle;
                info += $" - Job Id: {JobPostId} {EventLocation}";

                return info;
            }
        }


    }
}
