using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
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

namespace WpfApplication1
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

        // 加入 async
        private async void Start_Click(object sender, RoutedEventArgs e)
        {
            //AccessUrlForNet4Async();
            //AccessUrlForNet5Async();

            // 注意，此行程式碼未進行錯誤處理。
            string[] urls = InputUrl.Text.Split(',');
            
            foreach (var url in urls)
            {
                // 以非同步下載url內容，並計算回傳下載的Url長度
                int contentLength = await AccessUrlAsync(url);
                results.Text +=
                String.Format("下載URL " + url + " 字串長度： {0}.\r\n\r\n", contentLength);
            }
            

        }

        public async void AccessUrlForNet5Async()
        {
            var client = new WebClient();

            GetUrlLength(await client.DownloadStringTaskAsync(new Uri("http://msdn.microsoft.com/zh-tw")));
            GetUrlLength(await client.DownloadStringTaskAsync(new Uri("http://www.microsoft.com/zh-tw")));
            GetUrlLength(await client.DownloadStringTaskAsync(new Uri("http://channel9.msdn.com/")));
            GetUrlLength(await client.DownloadStringTaskAsync(new Uri("http://technet.microsoft.com/zh-TW/")));
        }


        public void AccessUrlForNet4Async()
        {
            var client = new WebClient();
            client.DownloadStringCompleted += AccessUrlForNet4AsyncDownloadStringCompleted1;
            client.DownloadStringAsync(new Uri("http://msdn.microsoft.com/zh-tw"));
        }

        void AccessUrlForNet4AsyncDownloadStringCompleted1(object sender, DownloadStringCompletedEventArgs e)
        {
            GetUrlLength(e.Result);

            var client = new WebClient();

            client.DownloadStringCompleted += AccessUrlForNet4AsyncDownloadStringCompleted2;
            client.DownloadStringAsync(new Uri("http://www.microsoft.com/zh-tw"));
        }

        void AccessUrlForNet4AsyncDownloadStringCompleted2(object sender, DownloadStringCompletedEventArgs e)
        {
            GetUrlLength(e.Result);

            var client = new WebClient();
            client.DownloadStringCompleted += AccessUrlForNet4AsyncDownloadStringCompleted3;
            client.DownloadStringAsync(new Uri("http://channel9.msdn.com/"));
        }

        void AccessUrlForNet4AsyncDownloadStringCompleted3(object sender, DownloadStringCompletedEventArgs e)
        {
            GetUrlLength(e.Result);

            var client = new WebClient();
            client.DownloadStringCompleted += AccessUrlForNet4AsyncDownloadStringCompleted4;
            client.DownloadStringAsync(new Uri("http://technet.microsoft.com/zh-TW/"));
        }

        private void AccessUrlForNet4AsyncDownloadStringCompleted4(object sender, DownloadStringCompletedEventArgs e)
        {
            GetUrlLength(e.Result);
        }

        private void GetUrlLength(string result)
        {
            results.Text += "下載 Url 字串長度：" + result.Length + " 。\r\n";
        }


        // 非同步方法有三個重點：
        // 1. 方法必須有async修飾詞。
        // 2. 回傳型別需是Task或Task<T>，此例是Task<int>，表示回傳integer。
        // 3. 名詞以Async結尾。
        async Task<int> AccessUrlAsync(string url)
        {
            // 參考 System.Net.Http 以宣告 client
            HttpClient client = new HttpClient();

            // GetStringAsync 回傳 Task<string>。
            // 這意味著，當你等待Task，你會得到一個字串內容。
            Task<string> getString = client.GetStringAsync(url);
            
            // 進行其他不依賴 GetStringAsync 的工作。
            DoOtherWork(url);

            // await 運算子會暫停 AccessUrlAsync：
            //  1. AccessUrlAsync 不能繼續，直到 getStringTask 完成。
            //  2. 與此同時，控制權會返回給呼叫者（這裡指 AccessUrlAsync）。
            //  3. 當 getString 完成，控制權會返回這裡。
            //  4. await 運算子會行 getString 取得字串結果。
            string urlContents = await getString;

            // 回傳整數結果。
            return urlContents.Length;
    
        }


        private void DoOtherWork(string url)
        {
            results.Text += "下載 " + url + " 中 . . . . . . .\r\n";
        }
    }
}
