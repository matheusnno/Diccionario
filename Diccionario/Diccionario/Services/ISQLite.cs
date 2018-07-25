using SQLite;

namespace Diccionario.Services
{
    public interface ISQLite
    {
        SQLiteConnection GetConnection();
    }
}
