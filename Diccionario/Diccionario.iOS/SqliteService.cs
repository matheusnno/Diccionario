using Diccionario.iOS;
using Xamarin.Forms;
using Diccionario.Services;
using System.IO;
using SQLite;
using System;

[assembly: Dependency(typeof(SqliteService))]
namespace Diccionario.iOS
{
    public class SqliteService : ISQLite
    {
        #region ISQlite Implementation

        public SQLiteConnection GetConnection()
        {
            var sqliteFilename = "SQLiteEx.db3";
            string documentsPath = Environment.GetFolderPath(Environment.SpecialFolder.Personal); //Documents Folder
            string libraryPath = Path.Combine(documentsPath, "..", "Library"); //Library Folder
            var path = Path.Combine(libraryPath, sqliteFilename);

            //This is where we copy in the prepopulated database
            if (!File.Exists(path))
            {
                File.Create(path);
            }

            var conn = new SQLiteConnection(path);

            //Return the database connection
            return conn;
        }

        #endregion
    }
}
