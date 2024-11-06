using Microsoft.EntityFrameworkCore;
using LibraryApi.Models;

namespace LibraryApi.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        // Aqui estamos criando as tabelas dando um set no nosso banco DB
        // e definindo o nome delas (Authors & Books).

        // Quando rodamos o comando 'add-migration CreatingDataBase'
        // (CreatingDataBase é o nome que escolhi para a primeira migração)
        // Ele até aqui e pega estas tabelas que nós setamos abaixo e as constroi automaticamente

        // Note que o comando para criar a migration vai mostrar um arquivo com o que será criado
        // Para efetivamente criar uma Database utilize o comando 'update-database'
        public DbSet<AuthorModel> Authors { get; set; }
        public DbSet<BookModel> Books { get; set; }

    }
}
