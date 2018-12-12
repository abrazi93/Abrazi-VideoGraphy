using System;
using System.Threading.Tasks;
using System.Net.Http;
using System.Text;
using Newtonsoft.Json;

namespace Client
{
    public class Filter
    {
        public int kind {get; set; }
        public string att { get; set; }
        public object value { get; set; }
        public Filter a1 { get; set; }
        public Filter a2 { get; set; }

    }

    class Program
    {
        static Filter GetPredicate()
        {
            var e1 = new Filter(){kind=0, att="Title", value="The Temple of Poseidon"};
            var e2 = new Filter(){kind=0, att="Location", value="Cape Sounio"};
            return new Filter(){kind=1, a1 = e1, a2 = e2};
        }

        static async Task GetVideos()
        {
            using (var httpClientHandler = new HttpClientHandler())
            {
                httpClientHandler.ServerCertificateCustomValidationCallback = (message, cert, chain, errors) => { return true; };
                using (var client = new HttpClient(httpClientHandler) { BaseAddress = new Uri("http://localhost:5000")})
                {
                    var j_p = JsonConvert.SerializeObject(GetPredicate(), new JsonSerializerSettings { TypeNameHandling = TypeNameHandling.None});
                    var str = new StringContent(j_p, Encoding.UTF8, "application/json");
                    var response = await client.PostAsync("api/Videos/GetMovies", str);
                    if(response.IsSuccessStatusCode)
                    {
                        Console.WriteLine(response.Content.ReadAsStringAsync().Result);
                    }
                }
                
            }
        }
        static void Main(string[] args)
        {
            GetVideos().Wait();
        }
    }
}
