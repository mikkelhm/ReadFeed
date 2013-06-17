using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Xml.Linq;
using ReadFeed.Kernel.Feeds;

namespace ReadFeed.Kernel.Reader
{
    public class FeedReader
    {
        public static IEnumerable<FeedEntry> ReadFeed(string url, string feedName, int feedID)
        {
            XDocument rssFeed = XDocument.Load(url);
            var posts = rssFeed.Descendants("item").Select(item => new FeedEntry
                                                                       {
                                                                           Title = item.Element("title").Value,
                                                                           FeedName = feedName,
                                                                           FeedID = feedID,
                                                                           Published =DateTime.Parse(item.Element("pubDate").Value),
                                                                           Url = item.Element("link").Value,
                                                                           Description = item.Element("description").Value,
                                                                           Tags = (from category in item.Elements("category")
                                                                                       orderby  category.Value 
                                                                                       select category.Value).ToList()
                                                                       }).OrderByDescending(entry => entry.Published);
            

            return posts;
        }

        private static IEnumerable<FeedEntry> ReadFeedFromString(string feedContent, string feedName, int feedID)
        {
            XDocument rssFeed = XDocument.Parse(feedContent);
            var posts = rssFeed.Descendants("item").Select(item => new FeedEntry
            {
                Title = item.Element("title").Value,
                FeedName = feedName,
                FeedID = feedID,
                Published = DateTime.Parse(item.Element("pubDate").Value),
                Url = item.Element("link").Value,
                Description = item.Element("description").Value,
                Tags = (from category in item.Elements("category")
                        orderby category.Value
                        select category.Value).ToList()
            }).OrderByDescending(entry => entry.Published);


            return posts;
        }

        public static async Task<List<FeedEntry>> GetFeedEntriesAsync()
        {
            var feeds = FeedHelper.GetFeeds();
            HttpClient client = new HttpClient();
            client.MaxResponseContentBufferSize = Int32.MaxValue;
            var feedEntries = new List<FeedEntry>();

                foreach(var feed in feeds)
                {
                    HttpResponseMessage resp = await client.GetAsync(new Uri(feed.FeedUrl));
                    string content = await resp.Content.ReadAsStringAsync();
                    var feedContent = ReadFeedFromString(content, feed.FeedName, feed.FeedID);
                    feedEntries.AddRange(feedContent);
                }

            return feedEntries;
        }
    }
}
