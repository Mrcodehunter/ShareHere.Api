namespace ShareHere.Database.Models
{
    public class Blog
    {
        public Guid Id { get; set; }
        public string Title { get; set; } = null!;
        public string Content { get; set; } = null!;
    }
}
