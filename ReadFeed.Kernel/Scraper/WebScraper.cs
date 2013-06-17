using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using HtmlAgilityPack;

namespace ReadFeed.Kernel.Scraper
{
    public class WebScraper
    {
        public static async Task<string> ScrapeUrl(string url)
        {
            HttpClient client = new HttpClient();
            client.MaxResponseContentBufferSize = Int32.MaxValue;
            HttpResponseMessage resp = await client.GetAsync(new Uri(url));
            string content = await resp.Content.ReadAsStringAsync();
            HtmlDocument doc = new HtmlDocument();
            doc.LoadHtml(content);
            doc.DocumentNode.Descendants().Where(n => n.Name == "script").ToList().ForEach(n => n.Remove());
            //doc.DocumentNode.Descendants().Where(n => n.Attributes["class"].Value.Contains("comments")).ToList().ForEach(n => n.Remove());
            content = doc.DocumentNode.SelectSingleNode("//article | //div[contains(@class, 'post')] | // div[@id='article']").InnerHtml;
            return content;
        }
    }
}
