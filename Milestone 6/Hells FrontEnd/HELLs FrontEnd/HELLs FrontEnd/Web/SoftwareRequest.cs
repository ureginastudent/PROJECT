using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Windows.Forms;
using Newtonsoft.Json;

namespace HELLs_FrontEnd.Web
{
    public static class SoftwareRequest
    {
        private static async Task<List<Software.RootObject>> RetrieveSoftware(WebClient webClient, string Path)
        {
            string softwareJSON = await webClient.DownloadString(Path);
            List<Software.RootObject> software = null;

            if (softwareJSON != null)
            {
                software = JsonConvert.DeserializeObject<List<Software.RootObject>>(softwareJSON);
            }
       
            return software;
        }
        
        public static async Task<List<Software.RootObject>> RetrieveSoftwareList()
        {
            HttpClientFactory Factory = new HttpClientFactory();
            WebClient webClient = Factory.CreateClient();

            List<Software.RootObject> softwareList = null;

            try
            {
                softwareList = await RetrieveSoftware(webClient, "retrievesoftware.php");
            }
            catch (Exception)
            {
                softwareList = null;
            }

            return softwareList;
        }
       
    }
}
