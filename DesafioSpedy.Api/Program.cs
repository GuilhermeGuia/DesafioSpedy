using DesafioSpedy.Api.Filters;
using DesafioSpedy.Application;
using DesafioSpedy.Domain.Crypto;
using DesafioSpedy.Infrastructure;
using DesafioSpedy.Infrastructure.DataAccess;
using DesafioSpedy.Infrastructure.Poco;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddMvc(options =>
{
    options.Filters.Add<ResponseFilter>();
    options.Filters.Add<ExceptionGlobalFilter>();
});

builder.Services.Configure<JwtSettings>(
    builder.Configuration.GetSection("JwtSettings"));

builder.Services.AddInfrastructure(builder.Configuration);
builder.Services.AddApplication();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

MigrateAndSeedDatabaseAsync();

app.Run();

void MigrateAndSeedDatabaseAsync()
{
    using var scope = app.Services.CreateScope();
    var services = scope.ServiceProvider;

    var db = services.GetRequiredService<DesafioSpedyDbContext>();
    var passwordEncryptor = services.GetRequiredService<IPasswordEncryptor>();

    db.Database.MigrateAsync();
    DbInitializer.Seed(db, passwordEncryptor);
}