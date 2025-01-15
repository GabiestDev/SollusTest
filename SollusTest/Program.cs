using SollusTest.Data;
using SollusTest.Models.Entities;
using SollusTest.Repositories;
using SollusTest.Repositories.Contracts;
using SollusTest.Routes;
using SollusTest.Services;
using SollusTest.Services.Contracts;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<ProductDbContext>();
builder.Services.AddScoped<IProductService, ProductService>();
builder.Services.AddScoped<IProductRepository, ProductRepository>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

ProductRoute.ProductRoutes(app);

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
