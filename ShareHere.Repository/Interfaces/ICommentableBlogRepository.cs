using ShareHere.Database.Models;

namespace ShareHere.Repository.Interfaces
{
    public interface ICommentableBlogRepository : IBlogRepository<CommentableBlog>
    {
        Task<List<string>> AddComment(Guid id, string comment);
        Task<List<string>> GetComments(Guid id);
    }
}
