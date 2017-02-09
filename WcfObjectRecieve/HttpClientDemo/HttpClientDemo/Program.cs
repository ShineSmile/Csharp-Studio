using System;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;

namespace HttpClientDemo
{
    class Program
    {
        private static string _postString = "{\"Age\":30,\"Name\":\"Jim\"}";
        static void Main()
        {
            TestHttpClientGet("http://heavensfeel.net:8080/", "GetStudent");
            TestHttpClientGet("https://heavensfeel.net/", "GetStudent");
            Console.WriteLine();

            HttpWebRequestGet("http://heavensfeel.net:8080/GetStudent");
            HttpWebRequestGet("https://heavensfeel.net/GetStudent");
            Console.WriteLine();

            TestHttpClientPost("http://heavensfeel.net:8080/", "GrowUpByObject");
            TestHttpClientPost("https://heavensfeel.net/", "GrowUpByObject");
            Console.WriteLine();

            HttpWebRequestPost("http://heavensfeel.net:8080/GrowUpByObject");
            HttpWebRequestPost("https://heavensfeel.net/GrowUpByObject");
            Console.Read();
        }

        private static void TestHttpClientGet(string baseAddress, string path)
        {
            HttpClient httpClient = new HttpClient()
            {
                BaseAddress = new Uri(baseAddress)
            };
            var responseMessage = httpClient.GetAsync(path).Result;
            string contentString = responseMessage.Content.ReadAsStringAsync().Result;
            Console.WriteLine("Http Client GET:\t{0}", contentString);
        }

        private static void TestHttpClientPost(string baseAddress, string path)
        {
            HttpClient httpClient = new HttpClient()
            {
                BaseAddress = new Uri(baseAddress),
            };
            var requestContent = new StringContent(_postString);
            requestContent.Headers.ContentType = new MediaTypeWithQualityHeaderValue("application/json");
            var responseMessage = httpClient.PostAsync(path, requestContent).Result;
            string contentString = responseMessage.Content.ReadAsStringAsync().Result;
            Console.WriteLine("Http Client POST:\t{0}", contentString);
        }

        private static void HttpWebRequestGet(string uri)
        {
            var request = WebRequest.Create(uri);
            var response = request.GetResponse();
            var stream = response.GetResponseStream();
            if (stream != null)
            {
                StreamReader sr = new StreamReader(stream, Encoding.UTF8);
                var resultString = sr.ReadToEnd();
                Console.WriteLine("Http Web Request GET:\t{0}", resultString);
            }
        }

        private static void HttpWebRequestPost(string uri)
        {
            var request = WebRequest.Create(uri);
            var requestData = Encoding.UTF8.GetBytes(_postString);
            request.Method = "POST";
            request.ContentType = "application/json";
            request.ContentLength = requestData.Length;
            using (var requestStream = request.GetRequestStream())
            {
                requestStream.Write(requestData, 0, requestData.Length);
            }
            var response = (HttpWebResponse)request.GetResponse();
            var responseStream = response.GetResponseStream();
            if (responseStream != null)
            {
                var responseString = new StreamReader(responseStream).ReadToEnd();
                Console.WriteLine("Http Web Request POST:\t{0}", responseString);
            }
        }
    }
}
