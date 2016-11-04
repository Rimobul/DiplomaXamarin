using SQLite;
using System.Collections.Generic;
using System.Linq;
using Xamarin.Forms;
using PersistentStorage.Dependencies;
using PersistentStorage.Models;
using System;

namespace PersistentStorage.Data
{
    public class SampleDatabase : IDisposable
    {
        private static object locker = new object();

        private SQLiteConnection connection;

        /// <summary>
        /// Initializes a new instance of the <see cref="Tasky.DL.TaskDatabase"/> TaskDatabase. 
        /// if the database doesn't exist, it will create the database and all the tables.
        /// </summary>
        /// <param name='path'>
        /// Path.
        /// </param>
        public SampleDatabase()
        {
            connection = DependencyService.Get<ISQLite>().GetConnection();
            // create the tables
            connection.CreateTable<SampleRecord>();
        }

        public IEnumerable<SampleRecord> GetItems()
        {
            lock (locker)
            {
                return connection.Table<SampleRecord>().ToList();                
            }
        }

        public int SaveItem(SampleRecord item)
        {
            lock (locker)
            {
                return connection.Insert(item);
            }
        }

        public int DeleteItem(int id)
        {
            lock (locker)
            {
                return connection.Delete<SampleRecord>(id);
            }
        }

        public void Dispose()
        {
            lock(locker)
            {
                connection.Dispose();
            }
        }
    }
}
