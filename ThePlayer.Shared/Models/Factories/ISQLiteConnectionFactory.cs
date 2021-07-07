//using System.Data.SQLite;
using SQLite;

namespace ThePlayer.Shared.Models.Factories
{
    public interface ISQLiteConnectionFactory
    {
        string DatabaseFile { get; }
        SQLiteConnection GetConnection();
    }
}
