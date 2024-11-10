using LibraryApi.Dto.Link;

namespace LibraryApi.Dto.Book
{
    public class BookEditDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public AuthorEditLinkDto Author { get; set; }
    }
}
