using LibraryApi.Data;
using LibraryApi.Services.Author;
using LibraryApi.Services.Book;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Aqui abaixo defino os servi�os (services) e suas respectivas interfaces
// (onde estar�o os m�todos que elas implementam).
// Basicamente, estou dizendo ao builder que, ao construir essas depend�ncias,
// ele poder� injetar essas implementa��es (AuthorService e BookService) sempre que
// precisar das interfaces (IAuthorInterface e IBookInterface).

builder.Services.AddScoped<IAuthorInterface, AuthorService>();
builder.Services.AddScoped<IBookInterface, BookService>();

// AddScoped define que a mesma inst�ncia do servi�o ser� usada durante uma �nica requisi��o,
// mas uma nova inst�ncia ser� criada para cada nova requisi��o.

builder.Services.AddDbContext<AppDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
    // Estou usando SQL server e utilizando builder configuration construo
    // a configura��o da conex�o, utilizando GetConnectionString vou direto para
    // o campo "ConnectionStrings" e pego a "DefaultConnection" em appsettings.json

    // Quando rodamos o comando 'add-migration CreatingDataBase'
    // (CreatingDataBase � o nome que escolhi para a primeira migra��o)
    // Ele at� \AppDbContext.cs e pega as tabelas que n�s setamos e as constroi automaticamente

    // Note que o comando para criar a migration vai mostrar um arquivo com o que ser� criado
    // Para efetivamente criar uma Database utilize o comando 'update-database'
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
