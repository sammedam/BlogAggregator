using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel.Syndication;
using System.Threading;
using System.Threading.Tasks;
using System.Xml;
using AggregatorContext;
using BlogDataModel;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace AggregatorService
{
    public class Worker : BackgroundService
    {
        private readonly ILogger<Worker> _logger;

        public Worker(ILogger<Worker> logger)
        {
            _logger = logger;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            Blogreader();
            while (!stoppingToken.IsCancellationRequested)
            {
                _logger.LogInformation("Worker running at: {time}", DateTimeOffset.Now);
                await Task.Delay(1000, stoppingToken);
            }
        }
        private void Blogreader()
        {
            ContextFactory cfact = new ContextFactory();
            AggregatorDBContext adbcont = cfact.CreateDbContext(new string[] {"",""});
            ICollection<Author> authors = new List<Author>();
            ICollection<Category> cats = new List<Category>();
            string blogURL = "https://www.loveandlemons.com/feed";
            var reader = XmlReader.Create(blogURL);
            var feed = SyndicationFeed.Load(reader);
            Blog blog = new Blog();
            blog.BlogURL = "https://www.loveandlemons.com/feed";
            blog.BlogName = "Love and Lemons";
            adbcont.Blogs.Add(blog);
            adbcont.SaveChanges();
            
            foreach (SyndicationItem article in feed.Items)
            {
                Post post = new Post();
                post.Lastupdated = article.LastUpdatedTime.UtcDateTime;
                post.PostDateCreated = article.PublishDate.UtcDateTime;
                post.PostTitle = article.Title.Text;
                post.BlogID = blog.BlogID;
                if(article.Summary.Text.Length>999)
                {
                    post.Summary = article.Summary.Text.Substring(1,999);
                   
                } else
                {
                    post.Summary = article.Summary.Text;
                }

                foreach (SyndicationPerson author in article.Authors)
                {
                    Author poster = new Author();
                    poster.AuthorEmail = author.Email;
                    poster.AuthorName = author.Name;
                    poster.AuthorURI = author.Uri;
                    adbcont.Authors.Add(poster);

                }
                foreach (SyndicationCategory cat in article.Categories)
                {
                    Category category = new Category();
                    category.CategoryName = cat.Name;
                    category.Label = cat.Label;
                    // cats.Add(category);
                    adbcont.Categories.Add(category);

                }
                adbcont.Posts.Add(post);
                adbcont.SaveChanges();
             }
        }
    }
}
