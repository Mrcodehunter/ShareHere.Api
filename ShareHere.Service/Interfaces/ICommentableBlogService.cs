using ShareHere.Database.Models;

namespace ShareHere.Service.Interfaces
{
    public interface ICommentableBlogService : IBlogService<CommentableBlog>
    {
        Task<List<Comment>> AddComment(Comment comment);

        Task<List<Comment>> GetAllComments(Guid id);
    }
}
