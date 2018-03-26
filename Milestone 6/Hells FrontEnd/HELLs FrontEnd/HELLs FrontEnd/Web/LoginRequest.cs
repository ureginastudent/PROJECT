using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using System.Reflection;
using System.Windows.Forms;

namespace HELLs_FrontEnd.Web
{
    public static class LoginRequest
    {
        public static WebClient webClient = null;

        /* I decided to not use polymorphism (Generate an abstract class for a loginsession, and inherit different types of authentication)
        * and instead use reflection to populate the loginsession, this saves me the need to re-write the login subroutine for all authentication methods
        */

        private static async Task<T> Login<T>(WebClient webClient, string Path, string Username, string Password)
        {
            string response = await webClient.DownloadString(Path);
            T newUser = default(T);

            if (response != null && response.Substring(0, 7) == "success")
            {
                Type myType = typeof(T);
                PropertyInfo[] properties = myType.GetProperties();

                newUser = (T)System.Activator.CreateInstance(myType);

                foreach (var property in properties)
                {
                    if (property.Name == "Id")
                    {
                        property.SetValue(newUser, int.Parse(response.Split(':')[1]));
                    }
                    else if (property.Name == "UserName")
                    {
                        property.SetValue(newUser, Username);
                    }
                    else if (property.Name == "Password")
                    {
                        property.SetValue(newUser, Password);
                    }
                }
            }

            return newUser;
        }

        public static async Task<T> Login<T>(string Username, string Password)
        {
            HttpClientFactory Factory = new HttpClientFactory();

            if (webClient == null)
                webClient = Factory.CreateClient();

            if (webClient == null)
                return default(T); //not successful in generating a client object

            T newUser = default(T);

            try
            {
                newUser = await Login<T>(webClient, string.Format("login.php?user={0}&pass={1}&type={2}", Username, Password, typeof(T).Name.ToString()), Username, Password);
            }
            catch (Exception)
            {
                newUser = default(T);
            }

            return newUser;
        }
    }
}
