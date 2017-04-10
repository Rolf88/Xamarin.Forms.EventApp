using System;
using System.IO;
using SQLite;

namespace Zmart.EventApp.Models
{
    public class DBConnection : SQLiteConnection
    {

        public DBConnection(string databasePath) : base(Path.Combine(databasePath, "beacons_140.db")) {
            this.CreateTable<BeaconPing>();
            this.BeaconPings = this.Table<BeaconPing>();
        }


        public TableQuery<BeaconPing> BeaconPings { get; }
    }
}
