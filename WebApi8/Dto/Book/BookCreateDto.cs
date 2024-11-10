using LibraryApi.Dto.Link;
using LibraryApi.Models;

namespace LibraryApi.Dto.Book
{
    public class BookCreateDto
    {
        public string Title { get; set; }

        public AuthorLinkDto Author { get; set; }
    }
}
