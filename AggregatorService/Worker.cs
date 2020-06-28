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
            string blogURL = "https://www.adventurouskate.com/feed/";
            var reader = XmlReader.Create(blogURL);
            var feed = SyndicationFeed.Load(reader);
            Blog blog = new Blog();
            blog.BlogURL = "https://www.adventurouskate.com/feed/";
            blog.BlogName = "Adventurous Kate";
            adbcont.Blogs.Add(blog);
            adbcont.SaveChanges();

            foreach (SyndicationItem article in feed.Items)
            {
                Post post = adbcont.Posts.FirstOrDefault(a => a.PostTitle == article.Title.Text && a.Lastupdated == article.LastUpdatedTime);

                if (post == null)
                {
                    Post post1 = new Post();
                    List<ArticleAuthor> aa = new List<ArticleAuthor>();
                    List<ArticleCategory> ac = new List<ArticleCategory>();
                    post1.ArticleAuthors = aa;
                    post1.ArticleCategories = ac;

                    post1.Lastupdated = article.LastUpdatedTime.UtcDateTime;
                    post1.PostDateCreated = article.PublishDate.UtcDateTime;
                    post1.PostTitle = article.Title.Text;
                    post1.BlogID = blog.BlogID;

                    if (article.Summary.Text.Length > 999)
                    {
                        post1.Summary = article.Summary.Text.Substring(1, 999);

                    }
                    else
                    {
                        post1.Summary = article.Summary.Text;
                    }

                    foreach (SyndicationPerson author in article.Authors)
                    {
                        Author author1 = adbcont.Authors.FirstOrDefault(a => a.AuthorName == author.Name && a.AuthorEmail == author.Email);
                        ArticleAuthor aaa = new ArticleAuthor();
                        if (author1 == null)
                        {
                            Author poster = new Author();
                            poster.AuthorEmail = author.Email;
                            poster.AuthorName = author.Name;
                            poster.AuthorURI = author.Uri;
                            adbcont.Authors.Add(poster);

                        }

                        aaa.Posts = post1;
                        aaa.Authors = author1;
                        post.ArticleAuthors.Add(aaa);


                    }
                    foreach (SyndicationCategory cat in article.Categories)
                    {
                        Category category1 = adbcont.Categories.FirstOrDefault(a => a.CategoryName == cat.Name && a.Label == cat.Label);
                        ArticleCategory acc = new ArticleCategory();
                        Category category = new Category();
                        if (category1 == null)
                        {
                            category.CategoryName = cat.Name;
                            category.Label = cat.Label;
                            adbcont.Categories.Add(category);
                        }
                        acc.Categories = category;
                        acc.Posts = post1;
                        post1.ArticleCategories.Add(acc);
                    }
                    adbcont.Posts.Add(post1);
                    adbcont.SaveChanges();
                }
            }
        }
    }
}
