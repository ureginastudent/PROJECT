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
        
        private static async Task<List<Software.Request>> RetrieveSoftwareRequests(WebClient webClient, string Path)
        {
            string softwareRequestsJSON = await webClient.DownloadString(Path);
            List<Software.Request> software = null;

            if (softwareRequestsJSON != null)
            {
                software = JsonConvert.DeserializeObject<List<Software.Request>>(softwareRequestsJSON);
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

        public static async Task<List<Software.Request>> RetrieveSoftwareRequests(string userId)
        {
            HttpClientFactory Factory = new HttpClientFactory();
            WebClient webClient = Factory.CreateClient();

            List<Software.Request> softwareRequestList = null;

            try
            {
                softwareRequestList = await RetrieveSoftwareRequests(webClient, string.Format("retrieverequests.php?user_id={0}", userId));
            }
            catch (Exception)
            {
                softwareRequestList = null;
            }

            return softwareRequestList;
        }
       
    }
}
