using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfApplication2
{
    /// <summary>
    /// MainWindow.xaml 的互動邏輯
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Start_Click(object sender, RoutedEventArgs e)
        {
            // AccessUrls();
            
            // 多執行緒
            Task<int> task = Task.Run(() =>
            {
                string url = "http://www.microsoft.com/zh-tw";
                var webRequest = (HttpWebRequest)WebRequest.Create(url);
                var response = webRequest.GetResponse();
                var stream = response.GetResponseStream();
                using (StreamReader reader = new StreamReader(stream))
                {
                    var content = reader.ReadLine();
                    return content.Length;
                }
            });

            results.Text = String.Format("下載URL字串長度： {0}.\r\n\r\n", task.Result);
        }

        private void AccessUrls()
        {
            // 注意，此行程式碼未進行安全性處理。
            string[] urls = InputUrl.Text.Split(',');

            foreach (var url in urls)
            {

                //byte[] content = GetUrl(url);
                //results.Text +=
                //String.Format("下載URL " + url + " 字串長度： {0}.\r\n\r\n", content.Length);


            }
        }

        private byte[] GetUrl(string url)
        {
            // 下載的資源將放置於MemoryStream的變數內
            var content = new MemoryStream();

            // 初始化 HttpWebRequest
            var webRequest = (HttpWebRequest)WebRequest.Create(url);

            // 進行其他的工作
            DoOtherWork(url);

            // 送出請求，等待網路資源回應
            using (WebResponse response = webRequest.GetResponse())
            {
                // 取得回應的stream
                using (Stream responseStream = response.GetResponseStream())
                {
                    // 將回應的資料流複製到content
                    responseStream.CopyTo(content);
                }
            }

            // 回應byte array
            return content.ToArray();
        }

        private byte[] GetUrlTask(string url)
        {
            var content = new MemoryStream();
            Task<byte[]> task = Task.Run(() =>
            {
                var webRequest = (HttpWebRequest)WebRequest.Create(url);
                using (WebResponse response = webRequest.GetResponse())
                {
                    using (Stream responseStream = response.GetResponseStream())
                    {
                        responseStream.CopyTo(content);
                        return content.ToArray();
                    }
                }
            });
            DoOtherWork(url);
            return task.Result;
        }

        private void DoOtherWork(string url)
        {
            results.Text += "下載 " + url + " 中 . . . . . . .\r\n";
        }
    }
}
