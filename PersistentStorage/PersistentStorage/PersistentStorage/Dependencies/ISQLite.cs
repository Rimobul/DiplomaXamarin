using SQLite;

namespace PersistentStorage.Dependencies
{
    public interface ISQLite
    {
        SQLiteConnection GetConnection();
    }
}
