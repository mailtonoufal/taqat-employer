using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArabWaha.Core.DBAccess
{
    public class ApplicationSettings
    {
        public List<AppSettings> GetAllSettings()
        {
            DbAccessor conn = new DbAccessor();
            return conn.GetTableItems<AppSettings>();
        }

        public AppSettings GetKeyByName(string keyname)
        {
            var setting = GetAllSettings().Where(x => x.Key.ToLower() == keyname.ToLower()).FirstOrDefault();

            return setting;
        }

        public void UpdateSettings(AppSettings setting)
        {
            DbAccessor conn = new DbAccessor();

            var item = GetKeyByName(setting.Key);
            if (item == null)
                conn.InsertRecord<AppSettings>(setting);
            else
                conn.UpdateRecord<AppSettings>(setting);

        }

        public void DeleteSetting(AppSettings setting)
        {
            DbAccessor conn = new DbAccessor();
            conn.DeleteRecord <AppSettings>(setting);
        }


    }
}
