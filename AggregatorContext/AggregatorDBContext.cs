using BlogDataModel;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
//DB Context class for entity models 
namespace AggregatorContext
{
    public class AggregatorDBContext : DbContext
    {
        public AggregatorDBContext (DbContextOptions<AggregatorDBContext> options):base(options) {} 

        public DbSet<Author> Authors { get; set; }
        public DbSet<Blog> Blogs { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Comments> Comments { get; set; }
        public DbSet<Post> Posts { get; set; }
    }
}
