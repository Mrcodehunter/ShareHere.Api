using Microsoft.EntityFrameworkCore;
using ShareHere.Database.Context;
using ShareHere.Database.Models;
using System.Reflection.Metadata;

namespace ShareHere.Repository.Repositories
{
    public class BlogRepository : IBlogRepository<Blog>
    {
        private readonly ShareHereContext shareHereContext = null!;
        public BlogRepository(ShareHereContext shareHereContext)
        {
            shareHereContext = shareHereContext ?? throw new ArgumentNullException(nameof(shareHereContext));
        }

        public async Task<List<Blog>> GetAll()
        {
            return await shareHereContext.Blogs.ToListAsync();
        }

        public async Task<Blog> Get(Guid id)
        {
            Blog? blog = await shareHereContext.Blogs.FindAsync(id);
            return blog;
        }

        public async Task<Blog> Add(Blog blog)
        {
            shareHereContext.Blogs.Add(blog);
            await shareHereContext.SaveChangesAsync();
            return blog;
        }

        public async Task<Blog> Update(Blog blog, Guid id)
        {
            Blog? currentBlog = await shareHereContext.Blogs.FindAsync(id);
            currentBlog.Title = blog.Title;
            currentBlog.Content = blog.Content;
            await shareHereContext.SaveChangesAsync();
            return currentBlog;
        }

        public async Task<bool> Delete(Guid id)
        {
            Blog? blog = await shareHereContext.Blogs.FindAsync(id);
            shareHereContext.Blogs.Remove(blog);
            await shareHereContext.SaveChangesAsync();
            return true;
        }
    }
}
