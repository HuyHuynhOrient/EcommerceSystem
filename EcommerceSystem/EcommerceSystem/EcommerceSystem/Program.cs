using EcommerceSystem.BAL.Interfaces;
using EcommerceSystem.BAL.Services;
using EcommerceSystem.DAL;
using EcommerceSystem.DAL.Interfaces;
using EcommerceSystem.DAL.Repositories;
using Microsoft.EntityFrameworkCore;
using System.Configuration;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();

builder.Services.AddDbContext<EcommerceSystemContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("eSystemConnectionString"),
        essembly => essembly.MigrationsAssembly(typeof(EcommerceSystemContext).Assembly.FullName));
});

builder.Services.AddTransient<IProductService, ProductService>();
builder.Services.AddTransient<IProductRepository, ProductRepository>();
builder.Services.AddTransient<IProductSubcategoryService, ProductSubcategoryService>();
builder.Services.AddTransient<IProductSubcategoryRepository, ProductSubcategoryRepository>();
builder.Services.AddTransient<IProductCategoryService, ProductCategoryService>();
builder.Services.AddTransient<IProductCategoryRepository, ProductCategoryRepository>();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

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


