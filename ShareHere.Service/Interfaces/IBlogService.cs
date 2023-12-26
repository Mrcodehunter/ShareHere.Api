using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShareHere.Service.Interfaces
{
    public interface IBlogService<T> where T : class
    {
        Task<T> GetBlogById(Guid id);
        Task<List<T>> GetAllBlogs();
        Task<T> AddBlog(T blog);
        Task<T> UpdateBlog(T blog);
        Task<bool> DeleteBlogById(Guid id);

    }
}
