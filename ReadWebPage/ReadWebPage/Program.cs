using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ReadWebPage
{
    class Program
    {
        static async Task Main(string[] args)
        {
            ////  => Reading a web page in C#

            //// ***** C# read web page with HttpClient ********
            //using var client = new HttpClient;
            //client.DefaultRequestHeaders.Add("User-Agent", "C# console program");
            //var content = await client.GetStringAsync("http://webcode.me");
            //Console.WriteLine(content);


            //------------------------------------------------------------------------------------------------------

            //// ***** C# reading web page with WebClient ****** (This method blocks while downloading the resource) "synchronous"
            //using var client = new WebClient();
            //client.Headers.Add("User-Agent", "c# console program");

            //string url = "http://webcode.me";
            //string content = client.DownloadString(url);
            //Console.WriteLine(content);


            //// 可以參考這篇 Url : https://stackoverflow.com/questions/1585985/how-to-use-the-webclient-downloaddataasync-method-in-this-context
            //// **** same as the above but this time do "Asynchronous"
            //using var client = new WebClient();
            //client.Headers.Add("User-Agent", "c# console program");

            //client.DownloadDataCompleted += (Sender, e) =>
            //{
            //    byte[] bytes = e.Result;
            //    string  ans = System.Text.Encoding.UTF8.GetString(bytes);

            //    Console.WriteLine($"{ Sender.GetType() }, { ans }");
            //};

            //Uri uri = new Uri("http://webcode.me");
            //client.DownloadDataAsync(uri);

            //Console.ReadLine();

            //------------------------------------------------------------------------------------------------------ 

            //// **** C# read web page with HttpWebRequest *****
            //string html = string.Empty;
            //string url = "http://webcode.me";

            //HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            //request.UserAgent = "C# console client";

            //using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
            //using (Stream stream = response.GetResponseStream())
            //using (StreamReader reader = new StreamReader(stream))
            //{
            //    var keys = response.Headers.Get("Server");
            //    html = reader.ReadToEnd();
            //}

            //Console.WriteLine(html);

            //// ****  or Using MemoryStream

            //HttpWebRequest http = (HttpWebRequest)WebRequest.Create(url);
            //WebResponse response = http.GetResponse();
            //MemoryStream memory = null;

            //// ******  把取回來的值放到內存 方便之後取出  -> 參考文章 https://blog.csdn.net/phker/article/details/51690664 *******
            //using (Stream stream = response.GetResponseStream())
            //{
            //    byte[] buffer = new byte[response.ContentLength];
            //    int offset = 0, actuallyRead = 0;
            //    do
            //    {
            //        actuallyRead = stream.Read(buffer, offset, buffer.Length - offset);
            //        offset += actuallyRead;
            //    }
            //    while (actuallyRead > 0);
            //    memory = new MemoryStream(buffer);
            //}

            //StreamReader streamReader = new StreamReader(memory);
            //string data = streamReader.ReadToEnd();
            //Console.WriteLine(data);


            //------------------------------------------------------------------------------------------------------
            //// ****** 使用HttpRequestMessage 自己創造一個 Request 的訊息 搭配 HttpClient ******* 
            //HttpRequestMessage message = new HttpRequestMessage(HttpMethod.Get, "https://localhost:44348/Api");
            //message.Headers.Add("User-Agent", "console applicationsssss"); // 給header 一些參數
            ////message.Headers.UserAgent = "console application";

            //// 打開httpclient
            //using var client = new HttpClient();
            ////client.DefaultRequestHeaders.Add("User-Agent", "console application");

            //foreach (var item in message.Headers)
            //{
            //    Console.WriteLine($"{item.Key} => {item.Value}");
            //}

            ////用 httpclient去網路上抓資料
            //HttpResponseMessage response = await client.SendAsync(message);
            //string str = response.Content.ReadAsStringAsync().Result;


            //Console.WriteLine(str);


            //------------------------------------------------------------------------------------------------------

            //// => C# HttpClient

            //// ***** C# HttpClient HEAD request ******
            //var url = "http://webcode.me";
            //using var client = new HttpClient();

            ////This header is response header.
            //var result = await client.SendAsync(new HttpRequestMessage(HttpMethod.Head, url));

            //Console.WriteLine(result);


            //------------------------------------------------------------------------------------------------------
            // ***** C# HttpClient multiple GET requests *****
            var urls = new string[] { "http://webcode.me", "http://example.com", "http://httpbin.org" };

            using var client = new HttpClient();
            var tasks = new List<Task<string>>();

            foreach (var url in urls)
            {
                tasks.Add(client.GetStringAsync(url));
            }

            Task.WaitAll(tasks.ToArray());

            var data = new List<string> { await tasks[0], await tasks[1], await tasks[2] };
            var rx = new Regex(@"<title>\s*(.+?)\s*</title>", RegexOptions.Compiled);

            foreach (var content in data)
            {
                var matches = rx.Matches(content);

                foreach (var match in matches)
                {
                    Console.WriteLine(match);
                }
            }


            //------------------------------------------------------------------------------------------------------
            //// ***** C# HttpClient POST request ******

            //var person = new Person("John Doe", "gardener");

            //var json = JsonConvert.SerializeObject(person);
            //var data = new StringContent(json, Encoding.UTF8, "application/json");

            //var url = "https://httpbin.org/post";
            //using (var client = new HttpClient())
            //{
            //    var response = await client.PostAsync(url, data);
            //    string result = response.Content.ReadAsStringAsync().Result;
            //    Console.WriteLine(result);
            //}



            //------------------------------------------------------------------------------------------------------
            //// ***** C# HttpClient JSON request ********
            //using (var client = new HttpClient())
            //{
            //    client.BaseAddress = new Uri("https://api.github.com");
            //    client.DefaultRequestHeaders.Add("User-Agent", "C# console program");
            //    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            //    var url = "repos/symfony/symfony/contributors";
            //    HttpResponseMessage response = await client.GetAsync(url);

            //    response.EnsureSuccessStatusCode();
            //    var resp = await response.Content.ReadAsStringAsync();

            //    List<Contributor> contributors = JsonConvert.DeserializeObject<List<Contributor>>(resp);
            //    contributors.ForEach(x => Console.WriteLine(x.GetContributions()));

            //    // 不知為什麼 不能使用record type, 所以只好用最陽春的方式, record type 要C# 9 才能用
            //}


            //------------------------------------------------------------------------------------------------------
            //// ***** C# HttpClient download image ********
            //using (var client = new HttpClient())
            //{
            //    var url = "https://upload.wikimedia.org/wikipedia/commons/thumb/b/b6/Image_created_with_a_mobile_phone.png/1200px-Image_created_with_a_mobile_phone.png";
            //    byte[] imageByte = await client.GetByteArrayAsync(url);

            //    string documentsPath = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);

            //    string localFileName = "favicon.ico";
            //    string localPath = Path.Combine(documentsPath, localFileName);

            //    Console.WriteLine(localPath);
            //    File.WriteAllBytes(localPath, imageByte);
            //}


            //------------------------------------------------------------------------------------------------------
            //// ***** C# HttpClient Basic authentication ********
            //var userName = "user7";
            //var passwd = "passwd";
            //var url = "https://httpbin.org/basic-auth/user7/passwd";

            //using var client = new HttpClient();
            //var authToken = Encoding.ASCII.GetBytes($"{userName}:{passwd}");
            //client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", Convert.ToBase64String(authToken));

            //HttpResponseMessage response = await client.GetAsync(url);
            //var content = await response.Content.ReadAsStringAsync();
            //Console.WriteLine(content);
        }
    }



    internal class Person
    {
        private string Name;
        private string Occupation;

        public Person(string name, string occupation)
        {
            Name = name;
            Occupation = occupation;
        }
    }

    internal class Contributor
    {
        private string Login;
        private string Contributions;

        public Contributor(string login, string contributions)
        {
            Login = login;
            Contributions = contributions;
        }

        public string Getlogin()
        {
            return Login;
        }

        public string GetContributions()
        {
            return Contributions;
        }
    }
}
