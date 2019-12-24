using Ionic.Zip;
using Ionic.Zlib;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DataFeed.ImageDownloader
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            for(int i = 31; i <= 301; i++)
            {
                using(HttpClient httpClient =new HttpClient())
                {
                    string url = $"http://testnewsfeed.huanyingzq.com/api/syncnews/history?columnid={i}";

                    try
                    {
                        var res = httpClient.GetStringAsync(url).Result;
                        Console.WriteLine($"url[{url}],result[{res}]");
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"url[{url}],result[{ex.Message}]");
                    }
                }
              
            }
            
        }


        public void DownloadImage(string url,string imageName)
        {
           
            WebRequest webRequest = WebRequest.Create(url);
            HttpWebResponse res;
            try
            {
                res = (HttpWebResponse)webRequest.GetResponse();
            }
            catch (WebException ex)
            {
                res = (HttpWebResponse)ex.Response;
            }
            if (res.StatusCode.ToString() == "OK")
            {
                Image image = System.Drawing.Image.FromStream(res.GetResponseStream());
                string dir = @"D:\img\";
                string fileName = $"{imageName}.png";
                if (!System.IO.Directory.Exists(dir))
                {
                    System.IO.Directory.CreateDirectory(dir);
                }
                image.Save(dir + fileName);
                image.Dispose();
            }
        }       
    }
}

