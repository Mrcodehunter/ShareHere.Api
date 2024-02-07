using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using ShareHere.Database.Context;
using ShareHere.Database.Models;
using ShareHere.Repository.Interfaces;
using ShareHere.Repository.Repositories;
using ShareHere.Repository;
using ShareHere.Service.Interfaces;
using ShareHere.Service.Services;
using ShareHere.Repository.FactoryRepositories;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

builder.Services.AddDbContext<ShareHereContext>(options =>
{
    options.UseInMemoryDatabase("InMemoryDatabase");
}, ServiceLifetime.Singleton);  // Singleton pattern for DbContext

builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "YourAPIName", Version = "v1" });
});

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddHttpContextAccessor();

// Singletone objects for classes through dependency injection
builder.Services.AddSingleton<IBlogFactoryRepository, BlogFactoryRepository>();
builder.Services.AddSingleton<IBlogRepository<Blog>, BlogRepository>();
builder.Services.AddSingleton<IBlogRepository<CommentableBlog>, CommentableBlogRepository>();
builder.Services.AddSingleton<ICommentableBlogRepository, CommentableBlogRepository>();

builder.Services.AddSingleton<IBlogService<Blog>, BlogService>();
builder.Services.AddSingleton<IBlogService<CommentableBlog>, CommentableBlogService>();
builder.Services.AddSingleton<ICommentableBlogService, CommentableBlogService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
app.UseSwagger();
app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "YourAPINameV1");
    c.RoutePrefix = string.Empty; // Serve Swagger UI at the app's root
});

app.UseRouting();

if (!app.Environment.IsDevelopment())
{
    app.UseHttpsRedirection();
    app.UseStaticFiles();
    app.UseRouting();
    app.UseAuthorization();
}

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllers();
});

app.Run();
