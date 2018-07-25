using SQLite;

namespace Diccionario.Models
{
    public class Dicionario
    {
        [PrimaryKey, AutoIncrement]
        public int Id
        { get; set; }

        [NotNull]
        public string Palavra
        { get; set; }

        [NotNull]
        public string Significado
        { get; set; }
    }
}
