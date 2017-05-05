using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArabWaha
{
    public static class EnumUtils
    {
        public static T ParseEnum<T>(string value, T defaultValue) where T : struct
        {
            if (string.IsNullOrEmpty(value)) return defaultValue;

            foreach (T item in Enum.GetValues(typeof(T)))
            {
                if (item.ToString().ToLower().Equals(value.Trim().ToLower())) return item;
            }
            return defaultValue;
        }

    }
}
