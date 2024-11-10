using LibraryApi.Data;
using LibraryApi.Dto.Author;
using LibraryApi.Models;
using Microsoft.EntityFrameworkCore;

namespace LibraryApi.Services.Author
{
    public class AuthorService(AppDbContext context) : IAuthorInterface
    // AuthorService implements IAuthorInterface

    // Caso de erro de implementar os métodos
    // Clique em cima de IAuthorInterface (onde é o erro)
    // CTRL + .
    // Selecione: Implement Interface
    // Eles serão criados, mas ainda não implementados

    {
        // Constructor
        // Este é o construtor que nos dá acesso ao contexto que consequentemente
        // da acesso ao nosso banco e por fim as nossas tabelas

        public async Task<ResponseModel<List<AuthorModel>>> CreateAuthor(AuthorCreateDto authorCreateDto)
        {
            ResponseModel<List<AuthorModel>> response = new ResponseModel<List<AuthorModel>>();
            try
            {
                var author = new AuthorModel()
                {
                    Name = authorCreateDto.Name,
                    Surname = authorCreateDto.Surname,
                };

                context.Add(author);
                await context.SaveChangesAsync();

                response.Data = await context.Authors.ToListAsync();
                response.Message = "Autor criado com sucesso";
                return response;
            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
                response.Status = false;
                return response;
            }
        }

        public async Task<ResponseModel<List<AuthorModel>>> EditAuthor(AuthorEditDto authorEditDto)
        {
            ResponseModel<List<AuthorModel>> response = new ResponseModel<List<AuthorModel>>();
            try
            {
                var author = await context.Authors.FirstOrDefaultAsync(authorDb => authorDb.Id == authorEditDto.Id);

                if (author == null)
                {
                    response.Message = "Nenhum autor localizado!";
                    return response;
                }

                author.Name = authorEditDto.Name;
                author.Surname = authorEditDto.Surname;

                context.Update(author);
                await context.SaveChangesAsync();

                response.Data = await context.Authors.ToListAsync();
                response.Message = "Autor editado com sucesso";

                return response;
            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
                response.Status = false;
                return response;
            }
        }

        public async Task<ResponseModel<List<AuthorModel>>> DeleteAuthor(int idAuthor)
        {
            ResponseModel<List<AuthorModel>> response = new ResponseModel<List<AuthorModel>>();
            try
            {
                var author = await context.Authors.FirstOrDefaultAsync(authorDb => authorDb.Id == idAuthor);

                if (author == null)
                {
                    response.Message = "Nenhum autor localizado!";
                    return response;
                }

                context.Remove(author);
                await context.SaveChangesAsync();

                response.Data = await context.Authors.ToListAsync();
                response.Message = "Autor removido com sucesso!";

                return response;
            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
                response.Status = false;
                return response;
            }
        }

        public async Task<ResponseModel<AuthorModel>> GetAuthorByBookId(int idBook)
        {
            ResponseModel<AuthorModel> response = new ResponseModel<AuthorModel>();
            try
            {
                var book = await context.Books.Include(a => a.Author)
                .FirstOrDefaultAsync(bookDb => bookDb.Id == idBook);
                // Include basicamente entra em livros e entra no author (relação)
                // ele faz este caminho para encontrar o primeiro author que satisfaça

                if (book == null)
                {
                    response.Status = false;
                    response.Message = "Nenhum registro localizado";
                    return response;
                }

                response.Data = book.Author;
                response.Message = "Autor encontrado com sucesso";
                return response;
            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
                response.Status = false;
                return response;
            }
        }

        public async Task<ResponseModel<AuthorModel>> GetAuthorById(int idAuthor)
        {
            ResponseModel<AuthorModel> response = new ResponseModel<AuthorModel>();
            try
            {
                var author = await context.Authors.FirstOrDefaultAsync(authorDb => authorDb.Id == idAuthor);

                if (author == null)
                {
                    response.Status = false;
                    response.Message = "Nenhum registro localizado";
                    return response;
                }

                response.Data = author;
                response.Message = "Autor encontrado com sucesso";

                return response;
            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
                response.Status = false;
                return response;
            }
        }

        public async Task<ResponseModel<List<AuthorModel>>> GetAuthors()
        {
            ResponseModel<List<AuthorModel>> response = new ResponseModel<List<AuthorModel>>();
            try
            {
                var authors = await context.Authors.ToListAsync();
                // Básicamente oque acontece aqui:

                // Na variável authors eu entro no meu banco ( _context )
                // Entro na tabela de autores ( Authors )
                // Transformei em lista todos os meus autores ( ToListAsync() )

                // ToListAsync é para esperar o processo acontecer, pois não sabemos se tem
                // 10 ou 10.000 authors

                response.Data = authors;
                response.Message = "Autores Listados com Sucesso";

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
