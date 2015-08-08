using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Web;
using Newtonsoft.Json;
using TeamHack1337.Model;

namespace TeamHack1337.Controllers
{
    public class Route
    {
        public string route_id { get; set; }
        public string shape_id { get; set; }
        public string route_short_name { get; set; }
        public List<Coordinate> coordinates;
        public List<DateTime> ArrivalTimes { get; set; }
        //public List<DateTime> EstimatedArrivalTimes { get; set; }


        public Route(string route_id, string route_short_name, string stop_code)
        {
            this.route_short_name = route_short_name;
            this.route_id = route_id;
            coordinates = new List<Coordinate>();
            getShapeID();
            getShapePoints();
            getArrivalTimes(stop_code);
        }

        public void getShapePoints() 
        {
            WebClient webClient = new WebClient();
            string s = webClient.DownloadString("http://api.at.govt.nz/v1/gtfs/shapes/shapeId/" + shape_id + "?api_key=6fbfc488-fec6-4de0-abaa-3dc5afe31002");
            var json = JsonConvert.DeserializeObject<BusStopList.RootObjectShapePoints>(s);

            foreach (var response in json.response)
            {
                coordinates.Add(new Coordinate(response.shape_pt_lat, response.shape_pt_lon));
            }
        }

        public void getShapeID()
        {
            WebClient webClient = new WebClient();
            string s = webClient.DownloadString("http://api.at.govt.nz/v1/gtfs/trips/routeid/" + route_id + "?api_key=6fbfc488-fec6-4de0-abaa-3dc5afe31002");
            var json = JsonConvert.DeserializeObject<BusStopList.RootObjectShapeID>(s);

            foreach (var response in json.response)
            {
                shape_id = response.shape_id;
                break;
            }
        }

        public void getArrivalTimes(string stop_code)
        {
            WebClient webClient = new WebClient();

            try
            {
                string s = webClient.DownloadString("http://api.maxx.co.nz/RealTime/v2/Departures/Stop/" + stop_code);
                var json = JsonConvert.DeserializeObject<RealTimeBoardClass.RootObject>(s);
                foreach (var movement in json.Movements)
                {
                    if (movement.Route == route_short_name)
                    {
                        if (movement.ExpectedArrivalTime == null)
                        {
                            ArrivalTimes.Add(movement.ActualArrivalTime);
                        }
                        else
                        {
                            ArrivalTimes.Add(movement.ExpectedArrivalTime is DateTime
                                ? (DateTime) movement.ExpectedArrivalTime
                                : new DateTime());
                        }
                    }
                }
            }
            catch (Exception e)
            {
                Debug.WriteLine("GetArrivalTime Fail. Try again? Details:" + e);
            }
        }
    }
}