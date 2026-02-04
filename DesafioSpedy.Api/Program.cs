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

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowSpecificOrigin", policy =>
    {
        policy.AllowAnyOrigin()
              .AllowAnyHeader()
              .AllowAnyMethod();
    });
});

var app = builder.Build();
    
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors("AllowSpecificOrigin");

//app.UseAuthentication();
//app.UseAuthorization();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

await MigrateAndSeedDatabaseAsync();

app.Run();

async Task MigrateAndSeedDatabaseAsync()
{
    using var scope = app.Services.CreateScope();
    var services = scope.ServiceProvider;

    var db = services.GetRequiredService<DesafioSpedyDbContext>();
    var passwordEncryptor = services.GetRequiredService<IPasswordEncryptor>();

    await db.Database.MigrateAsync();
    await DbInitializer.Seed(db, passwordEncryptor);
}