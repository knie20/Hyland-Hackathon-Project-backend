using CCTSBackend.DataTransfer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Threading.Tasks;

namespace CCTSBackend.Service
{
    public class HttpService
    {

        static HttpClient client = new HttpClient();
        public static async Task<String> GetHttpJson(string path)
        {
            string str = "";
            HttpResponseMessage response = await client.GetAsync(path);
            if (response.IsSuccessStatusCode)
            {
                str = await response.Content.ReadAsStringAsync();
            }
            return str;
        }

        public static async Task<Uri> PostHttpJson(Object obj, string path)
        {
            HttpResponseMessage response = await client.PostAsJsonAsync(path, obj);
            response.EnsureSuccessStatusCode();

            //return URI of the created resource.
            return response.Headers.Location;
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
