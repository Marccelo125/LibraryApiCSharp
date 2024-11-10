using LibraryApi.Dto.Book;
using LibraryApi.Models;

namespace LibraryApi.Services.Book
{
    public interface IBookInterface
    {
        Task<ResponseModel<List<BookModel>>> GetBooks();
        Task<ResponseModel<BookModel>> GetBookById(int idBook);
        Task<ResponseModel<List<BookModel>>> GetBooksByAuthorId(int idAuthor);
        Task<ResponseModel<List<BookModel>>> CreateBook(BookCreateDto bookCreateDto);
        Task<ResponseModel<List<BookModel>>> EditBook(BookEditDto bookEditDto);
        Task<ResponseModel<List<BookModel>>> DeleteBook(int idBook);
    }
}
