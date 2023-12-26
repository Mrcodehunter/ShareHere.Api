using ShareHere.Database.Models;

namespace ShareHere.Service.Interfaces
{
    public interface ICommentableBlogService : IBlogService<CommentableBlog>
    {
        Task<List<string>> AddComment(Guid id, string comment);

        Task<List<string>> GetAllComments(Guid id);
    }
}
