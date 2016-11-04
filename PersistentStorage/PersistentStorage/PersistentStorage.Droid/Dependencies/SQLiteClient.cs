using System;
using PersistentStorage.Dependencies;
using SQLite;
using PersistentStorage.Droid.Dependencies;
using Xamarin.Forms;
using System.IO;

[assembly: Dependency(typeof(SQLiteClient))]
namespace PersistentStorage.Droid.Dependencies
{
    public class SQLiteClient : ISQLite
    {
        public SQLiteConnection GetConnection()
        {
            var sqliteFilename = "SampleSQLite.db3";
            string documentsPath = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal); // Documents folder
            var path = Path.Combine(documentsPath, sqliteFilename);
            // Create the connection
            var conn = new SQLite.SQLiteConnection(path);
            // Return the database connection
            return conn;
        }
    }
}