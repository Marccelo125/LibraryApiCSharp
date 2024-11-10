using LibraryApi.Models;

namespace LibraryApi.Dto.Book
{
    public class BookEditDto
    {
        public int Id { get; set; }
        public string Title { get; set; }

        public AuthorModel Author { get; set; }
    }
}
