using DemoMinimalAPI.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

#region "Mapeando ConnectionString"
builder.Services.AddDbContext<MinimalContextDb>(options =>
        options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

#endregion

//Requests
var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

//Rota=>Ação
app.MapGet("/fornecedor", async (
    MinimalContextDb context) =>
    await context.Fornecedores.ToListAsync())
    .WithName("GetFornecedores")
    .WithTags("Fornecedores");

app.Run();

