using Diccionario.Models;
using SQLite;
using Xamarin.Forms;

namespace Diccionario.Services
{
    public class TodoItemDatabase
    {
        static SQLiteAsyncConnection database;

        public static SQLiteAsyncConnection Database
        {
            get
            {
                if (database == null)
                {
                    database = new SQLiteAsyncConnection(DependencyService.Get<IFileHelper>()
                                                    .GetLocalFilePath("TodoSQLite.db3"));
                }
                return database;
            }
        }

        public TodoItemDatabase(string dbPath)
        {
            database = new SQLiteAsyncConnection(dbPath);
            database.CreateTableAsync<Dicionario>().Wait();
        }
    }
}
