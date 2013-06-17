using System.Collections.Generic;
using System.Linq;
using ReadFeed.Kernel.Model;

namespace ReadFeed.Kernel.Feeds
{
    public class FeedHelper
    {
        public static List<Feed> GetFeeds()
        {
            return new List<Feed>() {new Feed()
                {
                    FeedID=1, 
                    FeedName="ASP.NET Daily Community Spotlight", 
                    FeedUrl="http://www.asp.net/rss/spotlight"
                }};
        }

        //public static Feed GetFeed(int feedID, RssDBEntities entities = null)
        //{
        //    if(entities == null)
        //        entities = new RssDBEntities();
        //    IQueryable<Feed> feedQuery = from feed in entities.Feeds where feed.FeedID == feedID select feed;
        //    return feedQuery.FirstOrDefault();
        //}
        //public static void SaveFeed(int feedID, string name, string url)
        //{
        //    RssDBEntities entities = new RssDBEntities();
        //    var feed = GetFeed(feedID, entities);
        //    if(feed == null)
        //        feed = new Feed();
        //    feed.FeedID = feedID;
        //    feed.FeedName = name;
        //    feed.FeedUrl = url;
        //    entities.Feeds.AddObject(feed);
        //    entities.SaveChanges();
        //}
    }
}
