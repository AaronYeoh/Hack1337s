using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Runtime.Caching;
using System.Web;
using System.Web.Caching;
using Newtonsoft.Json;
using TeamHack1337.Model;
using TeamHack1337.Model.AT_API_models;
using TeamHack1337.Model._1337_models;

namespace TeamHack1337.Controllers
{
    public static class Constants
    {
        public static string AtBaseUrl = "http://api.at.govt.nz/v1/gtfs/";
        public static string MaxxRealTimeUrl = "http://api.maxx.co.nz/RealTime/v2/Departures/Stop/";
        public static string ApiKey = "?api_key=ab88cbf9-a815-4ddd-9a93-17ab16caccce";
    }
    public class BusStopGenerator
    {
       private AtApiHelper atApiHelper = new AtApiHelper();

        public BusStop GenerateBusStop(string stopCode)
        {
            BusStop busStop = new BusStop();
            //Convert to stop id
            string stopId = GetStopId(stopCode);

            //Get the routes that run by each id
            List<Route> routes = GetRoutes(stopId);

            //Get the shapes.
            //List<Shape> shapes = GetShapes(shape_id);
            

            return busStop;
        }

        private List<Route> GetRoutes(string stopId)
        {
            WebClient webClient = new WebClient();
            string s = webClient.DownloadString("http://api.at.govt.nz/v1/gtfs/routes/stopid/" + stopId + "?api_key=6fbfc488-fec6-4de0-abaa-3dc5afe31002");
            var json = JsonConvert.DeserializeObject<BusStopList.RootObjectRoutes>(s);

            var routes = new List<Route>();
            foreach (var response in json.response)
            {
                //Adds shape automatically
                routes.Add(new Route(response.route_id));
            }
            Debug.WriteLine("Number of routes: " + routes.Count);

            return routes;
        }

        private string GetStopId(string stopCode)
        {
            //api.at.govt.nz/v1/gtfs/stops/stopCode/8439?api_key=ab88cbf9-a815-4ddd-9a93-17ab16caccce
            WebClient webClient = new WebClient();
            string s = webClient.DownloadString(Constants.AtBaseUrl + "routes/stopCode/" + stopCode + "?api_key=6fbfc488-fec6-4de0-abaa-3dc5afe31002");
            var json = JsonConvert.DeserializeObject<StopRootObject>(s);

            Stop stop = new Stop();
            stop.latitude = json.response.stop_id;

            Debug.WriteLine("Number of routes: " + routes.Count);
        }
    }

    
    public class AtApiHelper
    {
        ApiHelper apiHelper = new ApiHelper();
        
        public string Get(string baseUrl, string subUrlStr, string code = "", string APIKey = "")
        {
            string url = baseUrl + subUrlStr + code + APIKey;

            return apiHelper.GetString(url);
        }
    }


}