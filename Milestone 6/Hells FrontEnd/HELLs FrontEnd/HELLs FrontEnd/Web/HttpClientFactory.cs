using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using System.Net.Http.Headers;

namespace HELLs_FrontEnd.Web
{
    public class HttpClientFactory : IHttpClientFactory
    {
        public WebClient CreateClient()
        {
            HttpClientHandler Handler = new HttpClientHandler();

            Handler.CookieContainer = new System.Net.CookieContainer(); //cookies for sessions
            Handler.UseCookies = true;

            var client = new WebClient(Handler);

            SetupClientDefaults(client);
            return client;
        }
    
        protected virtual void SetupClientDefaults(HttpClient client)
        {
            client.Timeout = TimeSpan.FromSeconds(30);
            client.BaseAddress = new Uri(WebConfig.webHost);
           
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

        }
    }
}
