using LibraryApi.Models;

namespace LibraryApi.Services.Author
{
    public interface IAuthorInterface
    {
        Task<ResponseModel<List<AuthorModel>>> GetAuthors();
        // Por ele ser um método asincrono ele retorna um Task
        // Basicamente o retorno dele é uma lista de Authors (<List<AuthorModel>>)
        // Que vem do método asincrono Task do tipo ResponseModel.

        Task<ResponseModel<AuthorModel>> GetAuthorById(int idAuthor);
        Task<ResponseModel<AuthorModel>> GetAuthorByBookId (int idBook);
    }
}
