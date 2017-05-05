using ArabWaha.Employer.Helpers;
using ArabWaha.Employer.StaticData;
using ArabWaha.Enums;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ArabWaha.Employer
{
    public static class JobTypeEnumExtensions
    {

        public static string TranslateKey(this JobTypeEnum jt)
        {
            return string.Format("JOBTYPE_{0}", Enum.GetName(typeof(JobTypeEnum), jt));
        }
        public static string TranslateVal(this JobTypeEnum jt)
        {
            return TranslateExtension.GetString(jt.TranslateKey());
        }

        public static string TranslateDesc(this JobTypeEnum jt)
        {
            return TranslateExtension.GetString($"{jt.TranslateKey()}_DESC");
        }

        public static JobTypeEnum FromString(this JobTypeEnum jt, string val)
        {

            jt = (JobTypeEnum)Enum.Parse(typeof(JobTypeEnum), val);
            return jt;
        }
        /// <summary>
        /// Convert the String (which should be string val of the enum) to the display string value
        /// </summary>
        /// <param name="val"></param>
        /// <returns></returns>
        public static string ToJobType(this string val)
        {
            if (string.IsNullOrEmpty(val)) return "";
            string str = val;
            try
            {
                JobTypeEnum je = JobTypeEnum.NULL;
                str = je.FromString(val).TranslateVal();
            }
            catch
            {
                str = val;
            }
            return str;
        }

        public static int FindIndex(this ObservableCollection<JobTypeEntry> lst, string val)
        {
            // find the index matching the string Val of the Enum
            int idx = 0;
            foreach(JobTypeEntry je in lst)
            {
                if (je.JobTypeText == val)
                {
                    return idx;
                }
                idx++;
            }
            return -1;
        }

       // public static int FindIndex(this ObservableCollection<EntryBase> lst, string val)
       // {
       //     // find the index matching the string Val of the Enum
       //     int idx = 0;
       //     foreach (EntryBase je in lst)
       //     {
       //         if (je.Text == val)
       //         {
       //             return idx;
       //         }
       //         idx++;
       //     }
       //     return -1;
       //}
    }
}

