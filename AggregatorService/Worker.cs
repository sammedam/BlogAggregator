using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel.Syndication;
using System.Threading;
using System.Threading.Tasks;
using System.Xml;
using BlogDataModel;
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
            string blogURL = "https://www.loveandlemons.com/feed";
            var reader = XmlReader.Create(blogURL);
            var feed = SyndicationFeed.Load(reader);
            foreach(SyndicationItem article in feed.Items)
            {
               foreach(SyndicationPerson author in article.Authors)
                {
                    foreach(SyndicationCategory cat in article.Categories)
                    {
                        
                    }
                }  
               
             }
        }
    }
}
