using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;

namespace HELLs_FrontEnd.Web
{
    public partial class WebClient : HttpClient
    {
        public async Task<String> DownloadString(string Path)
        {
            HttpResponseMessage response = await this.GetAsync(Path);
            string responseStr = null;

            if (response.IsSuccessStatusCode)
            {
                responseStr = await response.Content.ReadAsStringAsync();
            }

            return responseStr;
        }

    }
}
