using PersistentStorage.Dependencies;
using SQLite;
using PersistentStorage.UWP.Dependencies;
using Xamarin.Forms;
using Windows.Storage;
using System.IO;

[assembly: Dependency(typeof(SQLiteClient))]
namespace PersistentStorage.UWP.Dependencies
{
    public class SQLiteClient : ISQLite
    {
        public SQLiteConnection GetConnection()
        {
            var sqliteFilename = "SampleSQLite.db3";
            string path = Path.Combine(ApplicationData.Current.LocalFolder.Path, sqliteFilename);
            var conn = new SQLite.SQLiteConnection(path);
            return conn;
        }
    }
}
