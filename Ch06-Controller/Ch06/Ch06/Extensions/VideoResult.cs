using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Policy;
using System.Web;
using System.Web.Hosting;
using System.Web.Mvc;
using System.Web.UI.WebControls;

namespace Ch06.Extensions
{
    public class VideoResult : FileResult
    {
        public string FileName { get; private set; }
        // 開放使用的影片格式
        private readonly string[] _videoTypes = {".mp4",".webm",".ogg"};

        public VideoResult(string fileName, string contentType)
            : base(contentType)
        {
            if (String.IsNullOrEmpty(fileName))
            {
                throw new ArgumentException("忘了檔案名稱？", "fileName");
            }
            // 副檔名確認
            // HostingEnvironment（System.Web.Hosting）
            string filePath = HostingEnvironment.MapPath("~/Videos/" + fileName);
            string fileExtension = Path.GetExtension(filePath).ToLower();
            foreach (string videoType in _videoTypes)
            {
                if (String.Equals(videoType,fileExtension))
                {
                    FileName =  fileName;
                }
            }
            
        }

        protected override void WriteFile(HttpResponseBase response)
        {
            // 
            string filePath = HostingEnvironment.MapPath("~/Videos/" + FileName);
            FileInfo file = new FileInfo(filePath);
            if (file.Exists)
            {
                FileStream stream = file.OpenRead();
                byte[] videostream = new byte[stream.Length];
                stream.Read(videostream, 0, (int)file.Length);
                response.BinaryWrite(videostream);
            }
            else
            {
                throw new ArgumentException("檔案不存在。", "fileName");
            }
        }
    }
}