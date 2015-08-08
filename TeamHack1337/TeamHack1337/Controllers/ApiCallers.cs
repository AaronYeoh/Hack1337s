using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web;

namespace TeamHack1337.Controllers
{
    public interface IApiCaller
    {

    }

    public class ApiCaller : IApiCaller
    {
        private string GetString()
        {
            //string response 
        }
    }

    public interface IStringGetter
    {
        string GetString();
    }

    public class GetStringFromUrl : IStringGetter
    {
        public async Task<string> GetString(string url)
        {
            WebClient webClient = new WebClient();

            try
            {
                if (Uri.IsWellFormedUriString(url, UriKind.RelativeOrAbsolute))
                {
                    var uri = new Uri(url);
                    var str = webClient.DownloadString(uri);
                    return str;
                }
            }
            catch (Exception e)
            {
                Debug.WriteLine("url= " + url + "Something happened in GetStringFromUrl: " + e);
            }
            return "";
        }
    }


}