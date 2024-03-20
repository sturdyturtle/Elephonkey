using Elephonkey.Models.Entities;
using SQLite;


namespace Elephonkey.Models.DataAccess
{
    public interface DataAccessSQLite
    {
        SQLiteConnection InitializeDatabase();

        List<EntityLogin> GetLogin();

        bool SaveLogin(EntityLogin Login);

        bool UpdateLogin(EntityLogin Login);
    }
}