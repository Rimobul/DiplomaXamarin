using PersistentStorage.Dependencies;
using PersistentStorage.iOS.Dependencies;
using System;
using Xamarin.Forms;
using SQLite;
using System.IO;

[assembly: Dependency(typeof(SQLiteClient))]
namespace PersistentStorage.iOS.Dependencies
{
    public class SQLiteClient : ISQLite
    {
        public SQLiteConnection GetConnection()
        {
            var sqliteFilename = "SampleQLite.db3";
            string documentsPath = Environment.GetFolderPath(Environment.SpecialFolder.Personal); // Documents folder
            string libraryPath = Path.Combine(documentsPath, "..", "Library"); // Library folder
            var path = Path.Combine(libraryPath, sqliteFilename);
            // Create the connection
            var conn = new SQLite.SQLiteConnection(path);
            // Return the database connection
            return conn;
        }
    }
}
