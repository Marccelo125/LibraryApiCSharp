namespace LibraryApi.Models
{
    public class BookModel
    {
        public int Id { get; set; }
        public string Title { get; set; }

        public AuthorModel Author { get; set; }
        // Estabelecendo relação com 1 Author por livro
    }
}
