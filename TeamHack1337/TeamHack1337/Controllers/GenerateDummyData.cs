using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TeamHack1337.Controllers
{
    public class GenerateDummyData
    {
        public BusStop busstop{get; set;}
        void GenerateBusStop()
        {
            busstop = new BusStop();
            busstop.Routes();
        }
    }

    public class Getter
    {
        private string baseUrl = "http://api.at.govt.nz/v1/gtfs";
        private string APIKey = "?api_key=ab88cbf9-a815-4ddd-9a93-17ab16caccce";
        private Webclient webclient = new WebClient();
        public static string Get(string subUrlStr, string code)
        {
            if 
           string url = baseUrl+subUrlStr+
           webClient
       
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
            //TODO: Fill this in!
            GetPoints();
        }
    }
    public class Point
    {
        public double Latitude { get; set; }
        public double Longitude { get; set; }
    }
}