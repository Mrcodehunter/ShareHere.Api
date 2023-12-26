namespace ShareHere.Database.Models
{
    // SOLID -> O: open-close principal. Here CommentableBlog class extended Blog class without modifing it.
    public class CommentableBlog : Blog
    {
        public List<string> Commemnts { get; set; } = null!;
    }
}
