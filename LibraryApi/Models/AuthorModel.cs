using System.Text.Json.Serialization;

namespace LibraryApi.Models
{
    public class AuthorModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }

        [JsonIgnore]
        // Basicamente deixando A ICollection como opcional na criação de uma Author
        public ICollection<BookModel> Books { get; set; }
        // Uma lista de Objetos do tipo BookModel, chamado de Books
    }
}
