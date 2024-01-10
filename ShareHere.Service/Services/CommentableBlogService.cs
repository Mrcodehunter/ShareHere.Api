using ShareHere.Database.Models;
using ShareHere.Repository;
using ShareHere.Repository.Interfaces;
using ShareHere.Repository.Repositories;
using ShareHere.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShareHere.Service.Services
{
    public class CommentableBlogService : ICommentableBlogService
    {
        private readonly ICommentableBlogRepository commentableBlogRepository;
        public CommentableBlogService(ICommentableBlogRepository commentableBlogRepository)
        {
            this.commentableBlogRepository = commentableBlogRepository;
        }

        public async Task<List<CommentableBlog>> GetAllBlogs()
        {
            return await commentableBlogRepository.GetAll();
        }

        public async Task<CommentableBlog> GetBlogById(Guid id)
        {
            return await commentableBlogRepository.Get(id);
        }

        public async Task<CommentableBlog> AddBlog(CommentableBlog blog)
        {
            return await commentableBlogRepository.Add(blog);
        }

        public async Task<CommentableBlog> UpdateBlog(CommentableBlog blog)
        {
            return await commentableBlogRepository.Update(blog, blog.Id);
        }

        public async Task<bool> DeleteBlogById(Guid id)
        {
            return await commentableBlogRepository.Delete(id);
        }

        public async Task<List<Comment>> AddComment(Comment comment)
        {
            return await commentableBlogRepository.AddComment(comment);
        }

        public async Task<List<Comment>> GetAllComments(Guid id)
        {
            return await commentableBlogRepository.GetComments(id);
        }
    }
}
