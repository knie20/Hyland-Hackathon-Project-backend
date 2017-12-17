using CCTSBackend.DataTransfer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using Newtonsoft.Json;
using System.Threading.Tasks;
using System.IO;

namespace CCTSBackend.Http
{
    public static class HttpService
    {

        static HttpClient client = new HttpClient();
        private static byte[] byteArray;

        public static async Task<String> GetHttpJson(string path)
        {
            string str = "";
            HttpResponseMessage response = await client.GetAsync(path);
            if (response.IsSuccessStatusCode)
            {
                str = await @response.Content.ReadAsStringAsync();
            }
            return JsonConvert.DeserializeObject<string>(str);
        }

        public static async Task<string> PostHttpJson(Object obj, string path)
        {
            HttpResponseMessage response = await client.PostAsJsonAsync(" ", path);
            response.EnsureSuccessStatusCode();

            //return URI of the created resource.
            return response.Content.ToString();
        }

        public static async Task<String> PutHttpJson(Object obj, string path)
        {
            HttpResponseMessage response = await client.PutAsJsonAsync(path, obj);
            response.EnsureSuccessStatusCode();

            return await response.Content.ReadAsAsync<String>();
        }

        static async Task<HttpStatusCode> DeleteProductAsync(string path)
        {
            HttpResponseMessage response = await client.DeleteAsync(path);
            return response.StatusCode;
        }


    }
}
