using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TeamHack1337.Model.AT_API_models;

namespace TeamHack1337.Model._1337_models
{
    public class BusStop
    {
        public string stop_code { get; set; }
        public string stop_id { get; set; }
        public double stop_lat { get; set; }
        public double stop_lon { get; set; }
        public List<Route> routes { get; set; }
    }

    public class Routes
    {
        public string RouteName { get; set; } // Bus number
        public List<Coordinate> Coordinates { get; set; }
        //TODO: Change this to DateTime! Or something.
        public List<string> ArrivalTimes { get; set; }

    }


    public class Coordinate
    {
        public double latitude { get; set; }
        public double longitude { get; set; }

        public Coordinate(double latitude, double longitude)
        {
            this.latitude = latitude;
            this.longitude = longitude;
        }
    }
}