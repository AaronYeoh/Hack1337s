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
        public List<string> ArrivalTimes { get; set; }
        //public List<DateTime> EstimatedArrivalTimes { get; set; }


        public Route(string route_id, string route_short_name, string stop_code)
        {
            this.route_short_name = route_short_name;
            this.route_id = route_id;
            coordinates = new List<Coordinate>();
            getShapeID();
            getShapePoints();
        }

        public void getShapePoints() 
        {
            WebClient webClient = new WebClient();
            string s = webClient.DownloadString("http://api.at.govt.nz/v1/gtfs/shapes/shapeId/" + shape_id + "?api_key=6fbfc488-fec6-4de0-abaa-3dc5afe31002");
            var json = JsonConvert.DeserializeObject<BusStopList.RootObjectShapePoints>(s);

            foreach (var response in json.response)
            {
                coordinates.Add(new Coordinate(this.shape_id, response.shape_pt_lat, response.shape_pt_lon));
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

        
    }
}