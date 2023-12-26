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
        public DbSet<CommentableBlog> CommentableBlogs { get; set; }
    }
}
