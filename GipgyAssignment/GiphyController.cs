using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace GipgyAssignment
{
    public class GiphyController : ApiController
    {
        // GET api/<controller>

        private GiphyItem[] giphyItems;
        public async Task FetchGiphy(int limit = 25)
        {// Initializing giphyItems with trend gifs
            string baseUrl = $"http://api.giphy.com/v1/gifs/trending?api_key=5z4NjMkoqyWgEYxoCNgrjjEx1KComVa7&limit={limit}";
            using (HttpClient client = new HttpClient())
            {
                HttpResponseMessage res = await client.GetAsync(baseUrl);
                Console.WriteLine(res);
                using (HttpContent content = res.Content)
                {
                    var data = await content.ReadAsStringAsync();
                    giphyItems = new GiphyItem[limit];
                    if (content != null)
                    {
                        for (int i = 0; i < limit; i++)
                        {
                            string title = JObject.Parse(data)["data"][i]["title"].ToString();
                            string url = JObject.Parse(data)["data"][i]["images"]["original"]["url"].ToString();
                            giphyItems[i] = new GiphyItem(title, url);
                        }
                    }
                }
            }
        }
        public async Task FetchGiphyByQuery(string query, int limit = 25)
        {// Initializing giphyItems with the results of the query.
            try
            {
                string baseUrl = $"http://api.giphy.com/v1/gifs/search?api_key=5z4NjMkoqyWgEYxoCNgrjjEx1KComVa7&limit={limit}&q={query}";
                using (HttpClient client = new HttpClient())
                {
                    HttpResponseMessage res = await client.GetAsync(baseUrl);
                    Console.WriteLine(res);
                    using (HttpContent content = res.Content)
                    {
                        var data = await content.ReadAsStringAsync();
                        
                        if (content != null)
                        {
                            JObject jObject = JObject.Parse(data);
                            int itemsLength = jObject["data"].Count();
                            giphyItems = new GiphyItem[itemsLength];
                            for (int i = 0; i < itemsLength; i++)
                            {
                                string title = jObject["data"][i]["title"].ToString();
                                string url = jObject["data"][i]["images"]["original"]["url"].ToString();
                                giphyItems[i] = new GiphyItem(title, url);
                            }
                        }
                    }
                }
            }
            catch (Exception) { }
        }
        public GiphyItem[] GiphyItems { get { return giphyItems; } }

    }
}