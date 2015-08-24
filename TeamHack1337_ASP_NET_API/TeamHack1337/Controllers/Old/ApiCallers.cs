using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Runtime.Caching;
using System.Threading.Tasks;
using System.Web;
using Newtonsoft.Json;
using TeamHack1337.Model.AT_API_models;

namespace TeamHack1337.Controllers
{
    public class ApiCaller
    {
       //ApiHelper apiHelper = new ApiHelper();

       //public void getRoutes()
       //{
       //    stop_id = "0001";
       //    string s = webClient.DownloadString("http://api.at.govt.nz/v1/gtfs/routes/stopid/" + stop_id + "?api_key=6fbfc488-fec6-4de0-abaa-3dc5afe31002");
       //    var json = JsonConvert.DeserializeObject<BusStopList.RootObjectRoutes>(s);

       //    foreach (var response in json.response)
       //    {
       //        routes.Add(new Route(response.route_id));
       //    }
       //    Console.WriteLine(routes.Count);
       //}




    }










    public class ApiHelper
    {
        public string GetString(string url)
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