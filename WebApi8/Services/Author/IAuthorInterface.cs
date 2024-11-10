using LibraryApi.Dto.Author;
using LibraryApi.Models;

namespace LibraryApi.Services.Author
{
    public interface IAuthorInterface
    {
        Task<ResponseModel<List<AuthorModel>>> GetAuthors();
        // Por ele ser um método asincrono ele retorna um Task
        // Basicamente o retorno dele é uma lista de Authors (<List<AuthorModel>>)
        // Que vem do método asincrono Task do tipo ResponseModel
        Task<ResponseModel<AuthorModel>> GetAuthorById(int idAuthor);
        Task<ResponseModel<AuthorModel>> GetAuthorByBookId(int idBook);

        Task<ResponseModel<List<AuthorModel>>> CreateAuthor(AuthorCreateDto authorCreateDto);
        // Utilizando DTO (Data transfer object)
        // que basicamente utiliza as propriedades que o usuário irá mandar
        // depois disso o DTO é transformado em um AuthorModel e inserido no banco
        
        Task<ResponseModel<List<AuthorModel>>> EditAuthor(AuthorEditDto authorEditDto);
        Task<ResponseModel<List<AuthorModel>>> DeleteAuthor(int idAuthor);
    }
}
