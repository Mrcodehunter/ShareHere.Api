using Microsoft.EntityFrameworkCore;
using ShareHere.Database.Models;
using System;

namespace ShareHere.Database.Context
{
    public class ShareHereContext : DbContext
    {
        public ShareHereContext(DbContextOptions<ShareHereContext> options) : base(options)
        {
        }

        // Define your entities as DbSet properties
        public DbSet<Blog> Blogs { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<CommentableBlog> CommentableBlogs { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Configure your entities here
            modelBuilder.Entity<Blog>()
                .HasKey(b => b.Id);

            modelBuilder.Entity<Comment>()
                .HasOne(comment => comment.Blog)
                .WithMany(blog => blog.Comments)
                .HasForeignKey(comment => comment.BlogId);

            // Add any additional configurations for relationships, indexes, etc.

            // Call the base implementation to apply any additional configurations
            base.OnModelCreating(modelBuilder);
        }
    }
}
