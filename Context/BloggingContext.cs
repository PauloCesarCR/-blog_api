using Microsoft.EntityFrameworkCore;
using System.Reflection.Metadata;

namespace Api_blog.Context
{
    public class BloggingContext : DbContext
    {

        public BloggingContext(DbContextOptions<BloggingContext> options)
            : base(options)
        {
        }
        public DbSet<Post> Posts { get; set; }
    }
}
