using System;
using System.IO;
using Diccionario.Droid;
using Diccionario.Services;
using SQLite;
using Xamarin.Forms;

[assembly: Dependency(typeof(SQLiteService))]
namespace Diccionario.Droid
{
    public class SQLiteService : ISQLite
    {
        #region ISQLite implementation

        public SQLiteConnection GetConnection()
        {
            var sqliteFileName = "SQLiteEx.db3";
            string documentsPath = Environment.GetFolderPath(Environment.SpecialFolder.Personal); //Documents Folder
            var path = Path.Combine(documentsPath, sqliteFileName);
            if (!File.Exists(path)) File.Create(path);

            var conn = new SQLiteConnection(path);

            // Return the database connection 
            return conn;
        }

        #endregion
    }
}
