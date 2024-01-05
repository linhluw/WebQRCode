using Newtonsoft.Json;
using System.IO;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace MyWeb.Common
{
    public class CallAPI
    {
        public static ApiResponse Get(string url)
        {
            ApiResponse res;

            var requestapi = (HttpWebRequest)WebRequest.Create(url);
            requestapi.Accept = "application/octet-stream";
            requestapi.Method = "GET";
            requestapi.ContentType = "application/json";

            using (WebResponse response = requestapi.GetResponse())
            {
                using (StreamReader reader = new StreamReader(response.GetResponseStream()))
                {
                    res = JsonConvert.DeserializeObject<ApiResponse>(reader.ReadToEnd());
                }
            }
            return res;
        }

        public static async Task<ApiResponse> GetAsync(string url)
        {
            ApiResponse res;

            var requestapi = (HttpWebRequest)WebRequest.Create(url);
            requestapi.Accept = "application/octet-stream";
            requestapi.Method = "GET";
            requestapi.ContentType = "application/json";

            using (WebResponse response = await requestapi.GetResponseAsync())
            {
                using (StreamReader reader = new StreamReader(response.GetResponseStream()))
                {
                    res = JsonConvert.DeserializeObject<ApiResponse>(reader.ReadToEnd());
                }
            }
            return res;
        }

        public static ApiResponse Post<T>(string url, T inputdata)
        {
            ApiResponse res;

            var requestapi = (HttpWebRequest)WebRequest.Create(url);
            requestapi.Accept = "application/octet-stream";
            requestapi.Method = "POST";
            requestapi.ContentType = "application/json";

            var dataRequest = JsonConvert.SerializeObject(inputdata);
            byte[] dataBuffer = Encoding.UTF8.GetBytes(dataRequest);

            using (Stream requestStream = requestapi.GetRequestStream())
            {
                requestStream.Write(dataBuffer, 0, dataBuffer.Length);
            }

            using (WebResponse response = requestapi.GetResponse())
            {
                using (StreamReader reader = new StreamReader(response.GetResponseStream()))
                {
                    res = JsonConvert.DeserializeObject<ApiResponse>(reader.ReadToEnd());
                }
            }
            return res;
        }

        public static async Task<ApiResponse> PostAsync<T>(string url, T inputdata)
        {
            ApiResponse res;

            var requestapi = (HttpWebRequest)WebRequest.Create(url);
            requestapi.Accept = "application/octet-stream";
            requestapi.Method = "POST";
            requestapi.ContentType = "application/json";

            var dataRequest = JsonConvert.SerializeObject(inputdata);
            byte[] dataBuffer = Encoding.UTF8.GetBytes(dataRequest);

            using (Stream requestStream = requestapi.GetRequestStream())
            {
                requestStream.Write(dataBuffer, 0, dataBuffer.Length);
            }

            using (WebResponse response = await requestapi.GetResponseAsync())
            {
                using (StreamReader reader = new StreamReader(response.GetResponseStream()))
                {
                    res = JsonConvert.DeserializeObject<ApiResponse>(reader.ReadToEnd());
                }
            }
            return res;
        }
    }
}