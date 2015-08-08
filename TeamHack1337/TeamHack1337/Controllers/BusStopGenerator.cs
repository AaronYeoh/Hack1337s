using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Net;

namespace TeamHack1337.Controllers
{
    public static class Constants
    {
        public static string AtBaseUrl = "http://api.at.govt.nz/v1/gtfs";
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
           // string stopId GetStopId(stopCode);

            //Get the routes that run by each id
           // Routes routes = GetRoutes(stopId);

            //Get the shapes.

            //

        }

    }


    public class AtApiHelper
    {

        private WebClient webclient = new WebClient();
        public string Get(string subUrlStr, string code = "")
        {
            string url = baseUrl + subUrlStr + code + APIKey;
            return url;

        }
    }

    public class BusStop
    {
        public List<Routes> Routes { get; set; } 
    }

    public class Routes
    {
        public string RouteName { get; set; } // Bus number
        public List<Shape> Shape { get; set; }
        //TODO: Change this to DateTime! Or something.
        public List<string> ArrivalTimes { get; set; }

    }
    public class Shape
    {
        public List<Point> Points { get; set; }

        public Shape(string shapeid)
        {
           
        }
    }
    public class Point
    {
        public double Latitude { get; set; }
        public double Longitude { get; set; }
    }
}