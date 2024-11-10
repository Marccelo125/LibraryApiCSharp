using LibraryApi.Data;
using LibraryApi.Dto.Book;
using LibraryApi.Models;
using Microsoft.EntityFrameworkCore;

namespace LibraryApi.Services.Book
{
    public class BookService(AppDbContext context) : IBookInterface
    {
        private readonly AppDbContext _context = context;

        public async Task<ResponseModel<List<BookModel>>> GetBooks()
        {
            ResponseModel<List<BookModel>> response = new ResponseModel<List<BookModel>>();
            try
            {
                var books = await context.Books.Include(book => book.Author).ToListAsync();
                response.Data = books;
                response.Message = "Livros Listados com Sucesso";

                return response;
            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
                response.Status = false;
                return response;
            }
            
        }
        public async Task<ResponseModel<BookModel>> GetBookById(int idBook)
        {
            ResponseModel<BookModel> response = new ResponseModel<BookModel>();
            try
            {
                var book = await context.Books.Include(book => book.Author).FirstOrDefaultAsync(bookDb => bookDb.Id == idBook);

                if (book == null)
                {
                    response.Status = false;
                    response.Message = "Nenhum registro localizado";
                    return response;
                }

                response.Data = book;
                response.Message = "Livro encontrado com sucesso";

                return response;
            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
                response.Status = false;
                return response;
            }
        }
        public async Task<ResponseModel<List<BookModel>>> GetBooksByAuthorId(int idAuthor)
        {
            ResponseModel<List<BookModel>> response = new ResponseModel<List<BookModel>>();
            try
            {
                var book = await _context.Books.Include(book => book.Author)
                .Where(bookDb => bookDb.Author.Id == idAuthor)
                .ToListAsync();

                if (book.Count == 0)
                {
                    response.Status = false;
                    response.Message = "Nenhum registro localizado";
                    return response;
                }

                response.Data = book;
                response.Message = "Livro encontrado com sucesso";
                return response;
            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
                response.Status = false;
                return response;
            }
        }
        public Task<ResponseModel<List<BookModel>>> CreateBook(BookCreateDto bookCreateDto)
        {
            throw new NotImplementedException();
        }
        public Task<ResponseModel<List<BookModel>>> EditBook(BookEditDto bookEditDto)
        {
            throw new NotImplementedException();
        }
        public Task<ResponseModel<List<BookModel>>> DeleteBook(int idBook)
        {
            throw new NotImplementedException();
        }
    }
}
