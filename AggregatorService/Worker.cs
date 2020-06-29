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
            AggregatorDBContext adbcont = cfact.CreateDbContext(new string[] { "", "" });
            ICollection<Author> authors = new List<Author>();
            ICollection<Category> cats = new List<Category>();

            List<Blog> blogs = new List<Blog>();
            blogs = adbcont.Blogs.ToList();
            foreach (Blog b in blogs)
            {
                string blogURL = b.BlogURL;
                var reader = XmlReader.Create(blogURL);
                var feed = SyndicationFeed.Load(reader);

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
                        if (article.Title.Text.Length >= 60)
                        {
                            post1.PostTitle = article.Title.Text.Substring(0, 59);
                        }
                        else
                        {
                            post1.PostTitle = article.Title.Text;
                        }
                        post1.BlogID = b.BlogID;

                        if (article.Summary.Text.Length > 999)
                        {
                            post1.Summary = article.Summary.Text.Substring(0, 998);

                        }
                        else
                        {
                            post1.Summary = article.Summary.Text;
                        }


                        foreach (SyndicationPerson author in article.Authors)
                        {
                            Author author1 = (Author)adbcont.Authors.FirstOrDefault(a => a.AuthorName == author.Name && a.AuthorEmail == author.Email);
                            ArticleAuthor aaa = new ArticleAuthor();

                            if (author1 == null)
                            {
                                author1 = new Author();
                                author1.AuthorEmail = author.Email;
                                author1.AuthorName = author.Name;
                                author1.AuthorURI = author.Uri;
                                adbcont.Authors.Add(author1);
                            }

                            aaa.Posts = post;
                            aaa.Authors = author1;
                            post1.ArticleAuthors.Add(aaa);


                        }
                        foreach (SyndicationCategory cat in article.Categories)
                        {
                            if (cat != null && !string.IsNullOrEmpty(cat.Name) && cat.Name != "NULL")
                            {
                                Category category1 = adbcont.Categories.FirstOrDefault(a => a.CategoryName == cat.Name && a.Label == cat.Label);
                                ArticleCategory acc = new ArticleCategory();

                                if (category1 == null)
                                {
                                    Category category = new Category();
                                    category.CategoryName = cat.Name;
                                    category.Label = cat.Label;
                                    adbcont.Categories.Add(category);
                                    acc.Categories = category;
                                    acc.Posts = post1;
                                    post1.ArticleCategories.Add(acc);
                                }

                            }
                        }
                        adbcont.Posts.Add(post1);
                        adbcont.SaveChanges();
                    }

                }
            }
        }
    }
    private void Commentreader()
    {
        ContextFactory cfact = new ContextFactory();
        AggregatorDBContext adbcont = cfact.CreateDbContext(new string[] { "", "" });
        ICollection<Comments> comments = new List<Comments>();
        ICollection<Commentator> commentator = new List<Commentator>();
        List<Blog> commentstore = adbcont.Blogs.ToList();
        foreach (Blog b in commentstore) {
            string commentURL = b.CommentURL;
            var reader = XmlReader.Create(commentURL);
            var feed = SyndicationFeed.Load(reader);

        }
           
        }
    }

