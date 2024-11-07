using LibraryApi.Data;
using LibraryApi.Services.Author;
using LibraryApi.Services.Book;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Aqui abaixo defino os serviços (services) e suas respectivas interfaces
// (onde estarão os métodos que elas implementam).
// Basicamente, estou dizendo ao builder que, ao construir essas dependências,
// ele poderá injetar essas implementações (AuthorService e BookService) sempre que
// precisar das interfaces (IAuthorInterface e IBookInterface).

builder.Services.AddScoped<IAuthorInterface, AuthorService>();
builder.Services.AddScoped<IBookInterface, BookService>();

// AddScoped define que a mesma instância do serviço será usada durante uma única requisição,
// mas uma nova instância será criada para cada nova requisição.

builder.Services.AddDbContext<AppDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
    // Estou usando SQL server e utilizando builder configuration construo
    // a configuração da conexão, utilizando GetConnectionString vou direto para
    // o campo "ConnectionStrings" e pego a "DefaultConnection" em appsettings.json

    // Quando rodamos o comando 'add-migration CreatingDataBase'
    // (CreatingDataBase é o nome que escolhi para a primeira migração)
    // Ele até \AppDbContext.cs e pega as tabelas que nós setamos e as constroi automaticamente

    // Note que o comando para criar a migration vai mostrar um arquivo com o que será criado
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
