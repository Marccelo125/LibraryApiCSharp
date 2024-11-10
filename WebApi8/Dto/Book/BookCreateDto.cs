using LibraryApi.Models;

namespace LibraryApi.Dto.Book
{
    public class BookCreateDto
    {
        public string Title { get; set; }

        public AuthorModel Author { get; set; }
    }
}
