using System;
using System.Collections.Generic;

namespace ReadFeed.Kernel.Reader
{
    public class FeedEntry
    {
        public string Title { get; set; }
        public string FeedName { get; set; }
        public int FeedID { get; set; }
        public string Description { get; set; }
        public DateTime Published { get; set; }
        public string Url { get; set; }
        public List<string> Tags { get; set; } 
    }
}
