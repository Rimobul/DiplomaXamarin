using SQLite;
using System;

namespace PersistentStorage.Models
{
    public class SampleRecord
    {

        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }

        [MaxLength(256)]
        public string SampleString { get; set; }

        public float SampleFloat { get; set; }

        public byte[] SampleBinary { get; set; }

        public DateTime SampleDateTime { get; set; }
    }
}
