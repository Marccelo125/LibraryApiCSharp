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
        public async Task<ResponseModel<List<BookModel>>> CreateBook(BookCreateDto bookCreateDto)
        {
            ResponseModel<List<BookModel>> response = new ResponseModel<List<BookModel>>();
            try
            {
                var author = await _context.Authors.FirstOrDefaultAsync(authorDb => authorDb.Id == bookCreateDto.Author.Id);
                // Verifica se o Author que foi passado nos parametros de criação existe no banco de dados

                if (author == null)
                {
                    response.Message = "Nenhum registro localizado";
                    return response;
                }

                var book = new BookModel()
                {
                    Title = bookCreateDto.Title,
                    Author = author,
                };

                _context.Add(book);
                await _context.SaveChangesAsync();

                response.Data = await _context.Books.Include(author => author.Author).ToListAsync();
                response.Message = "Livro criado com sucesso";
                return response;
            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
                response.Status = false;
                return response;
            }
        }
        public async Task<ResponseModel<List<BookModel>>> EditBook(BookEditDto bookEditDto)
        {
            ResponseModel<List<BookModel>> response = new ResponseModel<List<BookModel>>();
            try
            {
                var author = await _context.Authors.FirstOrDefaultAsync(authorDb => authorDb.Id == bookEditDto.Author.Id);
                var book = await _context.Books.Include(author => author.Author).FirstOrDefaultAsync(bookDb => bookDb.Id == bookEditDto.Id);

                if (book == null)
                {
                    response.Message = "Nenhum registro de livro localizado";
                    return response;
                }

                if (author == null)
                {
                    response.Message = "Nenhum registro de autor localizado";
                    return response;
                }

                book.Title = bookEditDto.Title;
                book.Author = author;

                _context.Books.Update(book);
                await context.SaveChangesAsync();

                response.Data = await _context.Books.Include(author => author.Author).ToListAsync();
                response.Message = "Livro editado com sucesso";

                return response;
            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
                response.Status = false;
                return response;
            }
        }
        public async Task<ResponseModel<List<BookModel>>> DeleteBook(int idBook)
        {
            ResponseModel<List<BookModel>> response = new ResponseModel<List<BookModel>>();
            try
            {
                var book = await _context.Books.FirstOrDefaultAsync(bookDb => bookDb.Id == idBook);

                if (book == null)
                {
                    response.Message = "Nenhum registro localizado";
                    return response;
                }

                _context.Books.Remove(book);
                await _context.SaveChangesAsync();

                response.Data = await _context.Books.Include(author => author.Author).ToListAsync();
                response.Message = "Livro removido com sucesso";

                return response;
            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
                response.Status = false;
                return response;
            }
        }
    }
}
