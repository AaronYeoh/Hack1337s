using System.Collections.Generic;
using System.Net;
using Newtonsoft.Json;
using TeamHack1337.Model._1337_models;

namespace TeamHack1337.Model.AT_API_models
{
    public class Route
    {
        public string route_id { get; set; }
        public string shape_id { get; set; }
        public List<Coordinate> coordinates;
        public WebClient webClient = new WebClient();

        public Route(string route_id)
        {
            this.route_id = route_id;
            coordinates = new List<Coordinate>();
            getShapeID();
            getShapePoints();
        }

        public void getShapePoints()
        {
            string s = webClient.DownloadString("http://api.at.govt.nz/v1/gtfs/shapes/shapeId/" + shape_id + "?api_key=6fbfc488-fec6-4de0-abaa-3dc5afe31002");
            var json = JsonConvert.DeserializeObject<BusStopList.RootObjectShapePoints>(s);

            foreach (var response in json.response)
            {
                coordinates.Add(new Coordinate(response.shape_pt_lat, response.shape_pt_lon));
            }
        }

        public void getShapeID()
        {
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