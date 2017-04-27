using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArabWaha.Core.DBAccess
{
    public class Notifications
    {

        [PrimaryKey, AutoIncrement]
        public Int32 id { get; set; }
        public Int32 NotificationId { get; set; }
        public string Title { get; set; }
        public string Body { get; set; }
        public string Image { get; set; }
        public string Status { get; set; }
        public string Received { get; set; } // needs to be format yyyy-mm-ddTTHH:mm:ss

        [Ignore]
        public string ReceivedFormatted
        {
            // convert to a time span
            get
            {
                string output = "*";

                try
                {
                    // format YYYY-MM-DDTHH:mm:ss
                    string YMD = Received.Split('T')[0];
                    string HHMMSS = Received.Split('T')[1];

                    string year = YMD.Split('-')[0];
                    string month = YMD.Split('-')[1];
                    string day = YMD.Split('-')[2];
                    string hour = HHMMSS.Split(':')[0];
                    string minute = HHMMSS.Split(':')[1];

                    // create a datetime here 


                    // extract date first
                    DateTime date1 = new DateTime(int.Parse(year), int.Parse(month), int.Parse(day), int.Parse(hour), int.Parse(minute), 0);

                    // DateTime dt1 = new DateTime(2009, 6, 1);
                    DateTime dt2 = DateTime.Now;
                    double totalminutes = (dt2 - date1).TotalMinutes;

                        // convert to 
                        // mins < 60
                        // hours < 24 hours but > 59mins
                        // days > 24 hours
                        if (totalminutes < 60)
                        {
                            output = $"{(int)totalminutes}m";
                        }
                        else
                        {
                            // convert to hours
                            int hours = (int)totalminutes / 60;
                            if (hours < 24)
                            {
                                output = $"{hours}h";
                            }
                            else
                            {
                                output = $"{hours / 24}d";
                            }
                        }
 
                }
                catch(Exception ex)
                {

                }


                return output;
            }
        }
        
    }
}
