using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ReadFeed.Kernel.Feeds;
using ReadFeed.Kernel.Reader;

namespace ReadFeed
{
    public partial class _default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                Stopwatch stopWatch = new Stopwatch();
                stopWatch.Start();
                RegisterAsyncTask(new PageAsyncTask(SetDesktop));
                SetDesktop();
                stopWatch.Stop();
                lblElapsedTime.Text = String.Format("Elapsed time: {0}",
                    stopWatch.Elapsed.Milliseconds / 1000.0);
                var feeds = FeedHelper.GetFeeds();  

            }
        }

        private async Task SetDesktop()
        {

            var feedEntries = new List<FeedEntry>();
            var getFeedEntries = FeedReader.GetFeedEntriesAsync();
            await Task.WhenAll(getFeedEntries);
            feedEntries = getFeedEntries.Result;
            feedEntries.Sort((entry1, entry2) => entry2.Published.CompareTo(entry1.Published));
            rptFeedEntries.DataSource = feedEntries;
            rptFeedEntries.DataBind();
        }
    }
}