using SQLite;
using System;

namespace Zmart.EventApp.Models
{
    public class BeaconPing
    {

        [AutoIncrement]
        [PrimaryKey]
        public int Id { get; set; }
        public string Identifier { get; set; }
        public string Uuid { get; set; }
        public ushort Major { get; set; }
        public ushort Minor { get; set; }
        public BeaconPingType Type { get; set; }
        public DateTime DateCreated { get; set; }
    }
}
