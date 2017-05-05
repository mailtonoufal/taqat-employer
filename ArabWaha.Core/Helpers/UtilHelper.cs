using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Net;
using System.Threading.Tasks;

namespace ArabWaha.Core.Helpers
{
    public static class UtilHelper
    {
        #region date helpers
        // date functions
        //public static string GetDateStringFromString(string datein,
        //                                             string format = "{0:ddd, MMM d, yyyy}")
        //{
        //    // form in data YYYY-MM-DD HH:MM:SS
        //    DateTime convertedDate = GetDateFromString(datein);
        //    var str = String.Format(format, convertedDate);
        //    return str;
        //}

        public static DateTime GetDateFromString(string datein)
        {
            int year = int.Parse(datein.Substring(0, 4));
            int month = int.Parse(datein.Substring(5, 2));
            int day = int.Parse(datein.Substring(8, 2));
            return new DateTime(year, month, day);
        }

        // format YYYY-MM-DD
        public static DateTime GetDateFormatFromString(string YMD)
        {
            if (string.IsNullOrEmpty(YMD)) return DateTime.Now;

            int year = int.Parse(YMD.Split('-')[0]);
            int month = int.Parse(YMD.Split('-')[1]);
            int day = int.Parse(YMD.Split('-')[2]);
            return new DateTime(year, month, day);
        }

        public static string GetStringFormatFromDate(DateTime YMD)
        {
            return $"{YMD.Year}-{YMD.Month}-{YMD.Day}";
        }


        // sql date format YYYY-DD-MMTHH:MM:SS
        public static DateTime GetDatefromSqlDate(string datein)
        {
            string YMD = datein.Split('T')[0];
            string HHMMSS = datein.Split('T')[1];

            string year = YMD.Split('-')[0];
            string month = YMD.Split('-')[1];
            string day = YMD.Split('-')[2];
            string hour = HHMMSS.Split(':')[0];
            string minute = HHMMSS.Split(':')[1];

            DateTime date1 = new DateTime(int.Parse(year), int.Parse(month), int.Parse(day), int.Parse(hour), int.Parse(minute), 0);

            return date1;
        }

        public static String GetDateOnlyfromSqlDate(string datein)
        {
            string YMD = datein.Split('T')[0];        
            return YMD;
        }

        public static String GetTimeOnlyfromSqlDate(string datein)
        {
            try {
                // remove seconds
                string timer = datein.Split('T')[1];
                string hour = timer.Split(':')[0];
                string minute = timer.Split(':')[1];

                return $"{hour.ToString()}:{minute.ToString()}";
            }
            catch
            {
                return "";
            }
        }


        public static string ConvertDateToSqlDate(DateTime dateIn)
        {
            return dateIn.ToString("s");
        }

        public static string GetTimeFromString(string startin, string endin)
        {
            // start and end times
            string retTime = startin.Substring(11, 5) + " - " + endin.Substring(11, 5);
            return retTime;
        }

        #endregion

        #region conversion helpers

        public static ObservableCollection<T> ConvertToObservable<T>(List<T> dataIn) where T : new()
        {
            ObservableCollection<T> retvals = new ObservableCollection<T>();
            foreach (var x in dataIn) retvals.Add(x);
            return retvals;
        }


        #endregion

        #region dummyids

        public static int getRandomIdInt()
        {
            Random rand = new Random();
            int val = rand.Next(10000, 32000);
            return val;            
        }

        public static string getRandomId()
        {
            return getRandomIdInt().ToString();
        }


        #endregion


    }
}
