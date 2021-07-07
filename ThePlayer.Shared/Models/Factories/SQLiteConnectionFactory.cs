using ThePlayer.Shared.Settings;
using ThePlayer.Shared.Packaging;
//using System.Data.SQLite;
using SQLite;
using System;
using System.IO;

namespace ThePlayer.Shared.Models.Factories
{
    public class SQLiteConnectionFactory : ISQLiteConnectionFactory
    {
        public string DatabaseFile => Path.Combine(SettingsClient.ApplicationFolder(), ProductInformation.ApplicationName + ".db");
        public SQLiteConnection GetConnection()
        {
            return new SQLiteConnection(this.DatabaseFile) { BusyTimeout = new TimeSpan(0, 0, 0, 10) };

        }
    }
}
