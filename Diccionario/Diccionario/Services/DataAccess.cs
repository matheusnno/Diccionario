using System.Collections.ObjectModel;
using System.Linq;
using Diccionario.Models;
using SQLite;
using Xamarin.Forms;

namespace Diccionario.Services
{
    public class DataAccess
    {
        SQLiteConnection dbConn;

        public DataAccess()
        {
            dbConn = DependencyService.Get<ISQLite>().GetConnection();
            dbConn.CreateTable<Dicionario>();
        }

        public ObservableCollection<Dicionario> GetSomeData(string search)
        {
            return new ObservableCollection<Dicionario>(dbConn.Query<Dicionario>($"select * from [Dicionario] where (lower(palavra) like lower('%{search}%')) or (lower(significado) like lower('%{search}%')) order by palavra desc"));
        }

        public ObservableCollection<Dicionario> GetAllData()
        {
            return new ObservableCollection<Dicionario>(dbConn.Query<Dicionario>("select * from [Dicionario]"));
        }

        public Dicionario GetDataFromId(int id)
        {
            try
            {
                return new ObservableCollection<Dicionario>(dbConn.Query<Dicionario>($"select * from [Dicionario] where id = {id}")).ElementAt(0);
            }
            catch
            {
                return new Dicionario();
            }
        }

        public int SaveData(Dicionario dicionario)
        {
            return dbConn.Insert(dicionario);
        }

        public int DeleteData(Dicionario dicionario)
        {
            return dbConn.Delete(dicionario);
        }

        public int UpdateData(Dicionario dicionario)
        {
            return dbConn.Update(dicionario);
        }
    }
}
