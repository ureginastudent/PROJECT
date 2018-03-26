using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using System.Windows.Forms;

namespace HELLs_FrontEnd.Web
{
    public static class SignupRequest
    {
        private static async Task<bool> Signup(WebClient webClient, string Path)
        {
            string Response = await webClient.DownloadString(Path);
            return Response == "success" ? true : false;
        }

        public static async Task<bool> Signup(string Username, string Password, string Email)
        {
            WebClient webClient = LoginRequest.webClient;

            if (webClient == null)
                return false;

            bool success = false;

            try
            {
               success = await Signup(webClient, string.Format("signup.php?user={0}&pass={1}&email={2}", Username, Password, Email));
            }
            catch(Exception)
            {
                success = false;
            }

            return success;
        }
    }
}
