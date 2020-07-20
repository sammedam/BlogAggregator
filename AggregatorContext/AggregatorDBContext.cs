using BlogDataModel;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
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

        public DbSet<Commentator> commentators { get; set; }
        public DbSet<Review> Reviews { get; set; }
        public DbSet<ArticleAuthor> ArticleAuthors { get; set; }
        public DbSet<ArticleCategory> ArticleCategories { get; set; }
        public DbSet<CommentatorComment> CommentatorComments { get; set; }

        protected override void OnModelCreating(ModelBuilder modelbuilder)
        {
            modelbuilder.Entity<Author>();
            modelbuilder.Entity<Blog>();
            modelbuilder.Entity<Category>();
            modelbuilder.Entity<Comments>();
            modelbuilder.Entity<Commentator>();
            modelbuilder.Entity<Review>();
            modelbuilder.Entity<Post>();
            modelbuilder.Entity<ArticleCategory>()
                .HasKey(x => new { x.PostID, x.CategoryID });
            modelbuilder.Entity<ArticleAuthor>()
                .HasKey(x => new { x.PostID, x.AuthorID });
            modelbuilder.Entity<CommentatorComment>()
                .HasKey(x => new { x.CommentatorID, x.CommentID });
        }

    }
}
