using Microsoft.EntityFrameworkCore;
using ShareHere.Database.Context;
using ShareHere.Database.Models;
using ShareHere.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShareHere.Repository.Repositories
{
    public class CommentableBlogRepository : ICommentableBlogRepository
    {
        private readonly ShareHereContext shareHereContext = null!;
        public CommentableBlogRepository(ShareHereContext shareHereContext)
        {
            shareHereContext = shareHereContext ?? throw new ArgumentNullException(nameof(shareHereContext));
        }

        public async Task<List<CommentableBlog>> GetAll()
        {
            return await shareHereContext.CommentableBlogs.ToListAsync();
        }

        public async Task<CommentableBlog> Get(Guid id)
        {
            CommentableBlog? blog = await shareHereContext.CommentableBlogs.FindAsync(id);
            return blog;
        }

        public async Task<CommentableBlog> Add(CommentableBlog blog)
        {
            shareHereContext.CommentableBlogs.Add(blog);
            await shareHereContext.SaveChangesAsync();
            return blog;
        }

        public async Task<CommentableBlog> Update(CommentableBlog blog, Guid id)
        {
            CommentableBlog? currentBlog = await shareHereContext.CommentableBlogs.FindAsync(id);
            currentBlog.Title = blog.Title;
            currentBlog.Content = blog.Content;
            currentBlog.Commemnts = blog.Commemnts;
            await shareHereContext.SaveChangesAsync();
            return currentBlog;
        }

        public async Task<bool> Delete(Guid id)
        {
            CommentableBlog? blog = await shareHereContext.CommentableBlogs.FindAsync(id);
            shareHereContext.CommentableBlogs.Remove(blog);
            await shareHereContext.SaveChangesAsync();
            return true;
        }

        public async Task<List<string>> AddComment(Guid id, string comment)
        {
            CommentableBlog? currentBlog = await shareHereContext.CommentableBlogs.FindAsync(id);
            currentBlog.Commemnts.Add(comment);
            await shareHereContext.SaveChangesAsync();
            return currentBlog.Commemnts;
        }

        public async Task<List<string>> GetComments(Guid id)
        {
            CommentableBlog? currentBlog = await shareHereContext.CommentableBlogs.FindAsync(id);
            return currentBlog.Commemnts;
        }
    }
}
