using Microsoft.EntityFrameworkCore;
using Tempo.Data.Context;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<TempoDbContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection"))
);

builder.Services.AddControllers();
builder.Services.AddOpenApi();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.MapControllers();

await app.RunAsync();
