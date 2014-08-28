using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace Ch06.Controllers
{
    public class TestAsyncController : AsyncController
    {
        //[AsyncTimeout(10000)]
        //[NoAsyncTimeout]
        public void DownloadAsync(string url)
        {
            // 計數器 + 1
            AsyncManager.OutstandingOperations.Increment();
            WebClient client = new WebClient();
            client.DownloadStringCompleted += (sender, e) =>
            {
                AsyncManager.Parameters["Content"] = e.Result;
                // 計數器 - 1
                // 當計數器為 0 時，會呼叫 DownloadCompleted
                AsyncManager.OutstandingOperations.Decrement();
            };
            client.DownloadStringAsync(new Uri(url));
        }

        public ActionResult DownloadCompleted(string content)
        {
            return Content(content);
        }

	}
}