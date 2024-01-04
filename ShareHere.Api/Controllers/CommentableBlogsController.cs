using Microsoft.AspNetCore.Mvc;
using ShareHere.Database.Models;
using ShareHere.Service.Interfaces;

namespace ShareHere.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommentableBlogsController : Controller
    {
        private readonly ICommentableBlogService blogService;
        public CommentableBlogsController(ICommentableBlogService blogService)
        {
            this.blogService = blogService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<CommentableBlog>>> GetAllAsync()
        {
            return Ok(await blogService.GetAllBlogs());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<CommentableBlog>> GetBlogByIdAsync(Guid id)
        {
            return Ok(await blogService.GetBlogById(id));
        }

        [HttpPost]
        public async Task<ActionResult<CommentableBlog>> AddBlogAsync(CommentableBlog blog)
        {
            return Ok(await blogService.AddBlog(blog));
        }

        [HttpPut]
        public async Task<ActionResult<CommentableBlog>> UpdateBlog(CommentableBlog blog)
        {
            return Ok(await blogService.UpdateBlog(blog));
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<bool>> DeleteBlogByIdAsync(Guid id)
        {
            return Ok(await blogService.DeleteBlogById(id));
        }

        [HttpPost("{id}/comments")]
        public async Task<ActionResult<List<string>>> AddCommentAsync(Guid id, string comment)
        {
            return Ok(await blogService.AddComment(id, comment));
        }

        [HttpGet("{id}/comments")]
        public async Task<ActionResult<List<string>>> GetCommentAsync(Guid id)
        {
            return Ok(await blogService.GetAllComments(id));
        }
    }
}