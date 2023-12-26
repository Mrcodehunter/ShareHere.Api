using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ShareHere.Database.Models;
using ShareHere.Service.Interfaces;

namespace ShareHere.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BlogController : Controller
    {
        private readonly IBlogService<Blog> blogService;
        public BlogController(IBlogService<Blog> blogService)
        {
            this.blogService = blogService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Blog>>> GetAllAsync()
        {
            return Ok(await blogService.GetAllBlogs());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Blog>> GetBlogByIdAsync(Guid id)
        {
            return Ok(await blogService.GetBlogById(id));
        }

        [HttpPost]
        public async Task<ActionResult<Blog>> AddBlogAsync(Blog blog)
        {
            return Ok(await blogService.AddBlog(blog));
        }

        [HttpPut]
        public async Task<ActionResult<Blog>> UpdateBlog(Blog blog)
        {
            return Ok(await blogService.UpdateBlog(blog));
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Boolean>> DeleteBlogByIdAsync(Guid id)
        {
            return Ok(await blogService.DeleteBlogById(id));
        }
    }
}
