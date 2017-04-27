using SQLite;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArabWaha.Core.DBAccess
{
    public class DbAccessor
    {
        // needs to be in place due to this being a seperate pcl from xamarin forms so needs explicit init
        public static string ConnectionString { get; set; }
    //    public static SQLite.Net.Interop.ISQLitePlatform SqlPlatform { get; set; }

        private SQLiteConnection GetConnection()
        {
            

            if(string.IsNullOrEmpty(DbAccessor.ConnectionString))
            {
                throw new Exception("Database string not initialised");
            }

            try
            {
                return new SQLiteConnection(DbAccessor.ConnectionString);  // SqlPlatform,DbAccessor.ConnectionString);
            }
            catch (Exception ex)
            {
                var t = ex.Message;
            }

            throw new Exception("No database file present");

        }

        public List<T> GetTableItems<T>() where T : new()
        {
            // open db
            var dbcon = GetConnection();
            List<T> lstret = dbcon.Table<T>().ToList<T>();
            dbcon.Close();
            return lstret;
        }

        public ObservableCollection<T> GetTableItemsObservable<T>() where T : new()
        {
            // open db
            var dbcon = GetConnection();
            List<T> lstret = dbcon.Table<T>().ToList<T>();
            dbcon.Close();

            ObservableCollection<T> retItems = new ObservableCollection<T>();
            foreach (var t in lstret) retItems.Add(t);
            return retItems;
        }

        public bool UpdateRecord<T>(T dataIn) where T : new()
        {
            // open db
            var dbcon = GetConnection();
            int test = dbcon.Update(dataIn);
            dbcon.Close();
            if (test == 0) return false;
            return true;
        }

        public bool InsertRecord<T>(T dataIn) where T : new()
        {
            // open db
            var dbcon = GetConnection();
            int test = dbcon.Insert(dataIn);
            dbcon.Close();
            if (test == 0) return false;
            return true;
        }

        public bool DeleteRecord<T>(T dataIn) where T : new()
        {
            // open db
            var dbcon = GetConnection();
            int test = dbcon.Delete(dataIn);
            dbcon.Close();
            if (test == 0) return false;
            return true;
        }

        public bool ExecuteUpdate(string sql, string[] args)
        {
            try
            {
                var dbcon = GetConnection();
                dbcon.Execute(sql, args);
                dbcon.Close();
            }
            catch { return false; }

            return true;
        }

        public List<T> Query<T>(string query, object[] args) where T : new()
        {
                return GetConnection().Query<T>(query, args);
        }


    }
}
