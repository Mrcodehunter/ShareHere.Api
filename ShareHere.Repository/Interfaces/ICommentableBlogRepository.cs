using ShareHere.Database.Models;

namespace ShareHere.Repository.Interfaces
{
    public interface ICommentableBlogRepository : IBlogRepository<CommentableBlog>
    {
        Task<List<Comment>> AddComment(Comment comment);
        Task<List<Comment>> GetComments(Guid id);
    }
}
