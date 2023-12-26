using ShareHere.Database.Models;
using ShareHere.Repository;
using ShareHere.Service.Interfaces;

namespace ShareHere.Service.Services
{
    public class BlogService : IBlogService<Blog>
    {
        private readonly IBlogRepository<Blog> blogRepository;
        public BlogService(IBlogRepository<Blog> blogRepository)
        {
            this.blogRepository = blogRepository;
        }

        public async Task<List<Blog>> GetAllBlogs()
        {
            return await blogRepository.GetAll();
        }

        public async Task<Blog> GetBlogById(Guid id)
        {
            return await blogRepository.Get(id);
        }

        public async Task<Blog> AddBlog(Blog blog)
        {
            return await blogRepository.Add(blog);
        }

        public async Task<Blog> UpdateBlog(Blog blog)
        {
            return await blogRepository.Update(blog, blog.Id);
        }

        public async Task<bool> DeleteBlogById(Guid id)
        {
            return await blogRepository.Delete(id);
        }
    }
}
