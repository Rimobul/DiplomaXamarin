using SQLite;
using System;

namespace PersistentStorage.Models
{
    public class SampleForeignRecord
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }

        public Guid UniqueId { get; set; }
        
        public int SampleRecordId { get; set; }
    }
}
