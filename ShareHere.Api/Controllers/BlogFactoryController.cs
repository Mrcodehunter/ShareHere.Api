using Microsoft.AspNetCore.Mvc;
using ShareHere.Database.Models;
using ShareHere.Repository.Interfaces;
using ShareHere.Service.Services;
using static ShareHere.Database.Models.Enums;

namespace ShareHere.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BlogFactoryController : ControllerBase
    {
        private readonly IBlogFactoryRepository blogFactoryRepository;
        public BlogFactoryController(IBlogFactoryRepository blogFactoryRepository)
        {
            this.blogFactoryRepository = blogFactoryRepository;
        }

        [HttpPost]
        public async Task<ActionResult<IEnumerable<string>>> AddBlogAsync(BlogTypes blogType)
        {
            return Ok(await blogFactoryRepository.AddBlog(blogType));
        }

        [HttpGet("/techblogs")]
        public async Task<ActionResult<IEnumerable<TechBlog>>> GetTechBlogsAsync()
        {
            return Ok(await blogFactoryRepository.GetTechBlogs());
        }

        [HttpGet("/politicalblogs")]
        public async Task<ActionResult<IEnumerable<TechBlog>>> GetPoliticalBlogsAsync()
        {
            return Ok(await blogFactoryRepository.GetPoliticalBlogs());
        }

        [HttpGet("/foodblogs")]
        public async Task<ActionResult<IEnumerable<TechBlog>>> GetFoodBlogsAsync()
        {
            return Ok(await blogFactoryRepository.GetFoodBlogs());
        }
    }
}
