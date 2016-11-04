using PersistentStorage.Data;
using PersistentStorage.Models;
using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using Xamarin.Forms;
using System.Linq;

namespace PersistentStorage.ViewModels
{
    public class SampleRecordsList : INotifyPropertyChanged
    {
        private ObservableCollection<SampleRecord> items;

        public SampleRecordsList()
        {
            items = new ObservableCollection<SampleRecord>();
            SelectAll = new Command(() =>
            {
                using (var database = new SampleDatabase())
                {
                    Items = new ObservableCollection<SampleRecord>(database.GetItems());
                }
            });
            InsertNew = new Command(() =>
            {
                var random = new Random();
                var randomBytes = new byte[10];
                random.NextBytes(randomBytes);

                using (var database = new SampleDatabase())
                {
                    database.SaveItem(new SampleRecord
                    {
                        SampleBinary = randomBytes,
                        SampleDateTime = DateTime.Now,
                        SampleFloat = (float)random.NextDouble(),
                        SampleString = "A string with number " + random.Next().ToString()
                    });
                }
            });
            DeleteAll = new Command(() =>
            {
                using (var database = new SampleDatabase())
                {
                    var ids = database.GetItems().Select(i => i.Id);
                    foreach(var id in ids)
                    {
                        database.DeleteItem(id);
                    }
                }
            });
        }

        public ObservableCollection<SampleRecord> Items
        {
            get { return this.items; }
            set
            {
                if(items != value)
                {
                    items = value;
                    OnPropertyChanged();
                }
            }
        }

        public ICommand SelectAll { get; private set; }

        public ICommand InsertNew { get; private set; }

        public ICommand DeleteAll { get; private set; }

        public void OnPropertyChanged([CallerMemberName]string name = null)
        {
            PropertyChanged(this, new PropertyChangedEventArgs(name));
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
