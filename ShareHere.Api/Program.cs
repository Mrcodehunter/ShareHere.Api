using Microsoft.EntityFrameworkCore;
using ShareHere.Database.Context;
using ShareHere.Database.Models;
using ShareHere.Repository;
using ShareHere.Repository.Interfaces;
using ShareHere.Repository.Repositories;
using ShareHere.Service.Interfaces;
using ShareHere.Service.Services;
using System.Reflection.Metadata;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddControllers();
builder.Services.AddDbContext<ShareHereContext>(options =>
{
    options.UseInMemoryDatabase("InMemoryDatabase");
});


builder.Services.AddEndpointsApiExplorer();
builder.Services.AddHttpContextAccessor();

builder.Services.AddScoped<IBlogRepository<Blog>, BlogRepository>();
builder.Services.AddScoped<IBlogRepository<CommentableBlog>, CommentableBlogRepository>();
builder.Services.AddScoped<ICommentableBlogRepository, CommentableBlogRepository>();

builder.Services.AddScoped<IBlogService<Blog>, BlogService>();
builder.Services.AddScoped<IBlogService<CommentableBlog>, CommentableBlogService>();
builder.Services.AddScoped<ICommentableBlogService, CommentableBlogService>();

// Add services to the container.
builder.Services.AddRazorPages();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();

app.Run();