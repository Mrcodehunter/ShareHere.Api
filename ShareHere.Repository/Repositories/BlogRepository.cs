using Microsoft.EntityFrameworkCore;
using ShareHere.Database.Context;
using ShareHere.Database.Models;

namespace ShareHere.Repository.Repositories
{
    public class BlogRepository : IBlogRepository<Blog>
    {
        private readonly ShareHereContext context;
        public BlogRepository(ShareHereContext shareHereContext)
        {
            this.context = shareHereContext ?? throw new ArgumentNullException(nameof(shareHereContext));
        }

        public async Task<List<Blog>> GetAll()
        {
            var blogs = await context.Blogs.ToListAsync();
            return blogs;
        }

        public async Task<Blog> Get(Guid id)
        {
            Blog? blog = await context.Blogs.FindAsync(id);
            return blog;
        }

        public async Task<Blog> Add(Blog blog)
        {
            context.Blogs.Add(blog);
            await context.SaveChangesAsync();
            return blog;
        }

        public async Task<Blog> Update(Blog blog, Guid id)
        {
            Blog? currentBlog = await context.Blogs.FindAsync(id);
            currentBlog.Title = blog.Title;
            currentBlog.Content = blog.Content;
            await context.SaveChangesAsync();
            return currentBlog;
        }

        public async Task<bool> Delete(Guid id)
        {
            Blog? blog = await context.Blogs.FindAsync(id);
            context.Blogs.Remove(blog);
            await context.SaveChangesAsync();
            return true;
        }
    }
}
