using System.ComponentModel.DataAnnotations.Schema;

namespace ShareHere.Database.Models
{
    public class Comment
    {
        public Guid Id { get; set; }
        public string Content { get; set; } = null!;
        public Guid BlogId { get; set; }
        public CommentableBlog Blog { get; set; }
    }
    // SOLID -> O: open-close principal. Here CommentableBlog class extended Blog class without modifing it.
    public class CommentableBlog : Blog
    {
        public List<Comment> Comments { get; set; } = new List<Comment>();
    }
}
