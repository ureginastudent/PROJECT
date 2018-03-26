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
        private static async Task<bool> RequestSoftware(WebClient webclient, string Path)
        {
            return await webclient.DownloadString(Path) == "1";
        }

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
        
        private static async Task<bool> RequestApproval(WebClient webClient, string Path)
        {
            return await webClient.DownloadString(Path) == "1";
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
            WebClient webClient = LoginRequest.webClient;

            if (webClient == null)
                return null;

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

        public static async Task<List<Software.RootObject>> RetrieveSoftwareList(string softwareId)
        {
            WebClient webClient = LoginRequest.webClient;

            if (webClient == null)
                return null;

            List<Software.RootObject> softwareList = null;

            try
            {
                softwareList = await RetrieveSoftware(webClient, string.Format("retrievesoftware.php?software_id={0}", softwareId));
            }
            catch (Exception)
            {
                softwareList = null;
            }

            return softwareList;
        }


        public static async Task<List<Software.Request>> RetrieveSoftwareRequests(string optional = "")
        {
            WebClient webClient = LoginRequest.webClient;

            if (webClient == null)
                return null;

            List<Software.Request> softwareRequestList = null;

            try
            {
                softwareRequestList = await RetrieveSoftwareRequests(webClient, string.Format("retrieverequests.php?all={0}", optional));

            }
            catch (Exception)
            {
                softwareRequestList = null;
            }

            return softwareRequestList;
        }


        public static async Task<bool> RequestSoftware(string softwareId)
        {
            WebClient webClient = LoginRequest.webClient;

            if (webClient == null)
                return false;

            bool success = false;

            try
            {
                success = await RequestSoftware(webClient, string.Format("submitrequest.php?software_id={0}", softwareId));
            }
            catch(Exception)
            {
                success = false;
            }

            return success;
        }

        public static async Task<bool> RequestApproval(string softwareId, string userId)
        {
            WebClient webClient = LoginRequest.webClient;

            if (webClient == null)
                return false;

            bool success = false;

            try
            {
                success = await RequestApproval(webClient, string.Format("requestapproval.php?user_id={0}&software_id={1}", userId, softwareId));

            }
            catch (Exception)

            {
                success = false;
            }

            return success;
        }
    }
}
