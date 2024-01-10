using Microsoft.EntityFrameworkCore;
using ShareHere.Database.Context;
using ShareHere.Database.Models;
using ShareHere.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace ShareHere.Repository.Repositories
{
    public class CommentableBlogRepository : ICommentableBlogRepository
    {
        private readonly ShareHereContext context;
        public CommentableBlogRepository(ShareHereContext shareHereContext)
        {
            this.context = shareHereContext ?? throw new ArgumentNullException(nameof(shareHereContext));
        }

        public async Task<List<CommentableBlog>> GetAll()
        {
            return await context.CommentableBlogs.ToListAsync();
        }

        public async Task<CommentableBlog> Get(Guid id)
        {
            CommentableBlog? blog = await context.CommentableBlogs.FindAsync(id);
            return blog;
        }

        public async Task<CommentableBlog> Add(CommentableBlog blog)
        {
            context.CommentableBlogs.Add(blog);
            await context.SaveChangesAsync();
            return blog;
        }

        public async Task<CommentableBlog> Update(CommentableBlog blog, Guid id)
        {
            CommentableBlog? currentBlog = await context.CommentableBlogs.FindAsync(id);
            currentBlog.Title = blog.Title;
            currentBlog.Content = blog.Content;
            currentBlog.Comments = blog.Comments;
            await context.SaveChangesAsync();
            return currentBlog;
        }

        public async Task<bool> Delete(Guid id)
        {
            CommentableBlog? blog = await context.CommentableBlogs.FindAsync(id);
            context.CommentableBlogs.Remove(blog);
            await context.SaveChangesAsync();
            return true;
        }

        public async Task<List<Comment>> AddComment(Comment comment)
        {
            context.Comments.Add(comment);
            await context.SaveChangesAsync();
            var currentBlogComments = await context.Comments.Where(cmnt => cmnt.BlogId == comment.BlogId).ToListAsync();
            return currentBlogComments;
        }

        public async Task<List<Comment>> GetComments(Guid id)
        {
            var currentBlogComments = await context.Comments.Where(cmnt => cmnt.BlogId == id).ToListAsync();
            return currentBlogComments;
        }
    }
}
