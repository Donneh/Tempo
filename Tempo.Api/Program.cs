using Microsoft.EntityFrameworkCore;
using Scalar.AspNetCore;
using Tempo.Core.Repositories;
using Tempo.Core.Services;
using Tempo.Data.Context;
using Tempo.Data.Repositories;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<TempoDbContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection"))
);

builder.Services.AddScoped<ITaskItemRepository, TaskItemRepository>();
builder.Services.AddScoped<ITaskItemService, TaskItemService>();

builder.Services.AddControllers();
builder.Services.AddOpenApi();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.MapScalarApiReference();
}

app.UseHttpsRedirection();

app.MapControllers();

await app.RunAsync();
