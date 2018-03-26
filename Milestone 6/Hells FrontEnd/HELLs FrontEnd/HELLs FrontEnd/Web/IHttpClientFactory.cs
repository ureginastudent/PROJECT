using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;

namespace HELLs_FrontEnd.Web
{
    public interface IHttpClientFactory
    {
        WebClient CreateClient();
    }
}
