using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Web;
using Newtonsoft.Json;

namespace TeamHack1337.Controllers
{
    public class BusStop
    {
        public string stop_code { get; set; }
        public string stop_id { get; set; }
        public double stop_lat { get; set; }
        public double stop_lon { get; set; }
        public List<Route> routes { get; set; }
       // public string filename = "stop_list.txt";
        

        public BusStop(string stop_code)
        {
            this.stop_code = stop_code;
            routes = new List<Route>();
            getStopID();
            getRoutes();
        }

        //api.at.govt.nz/v1/gtfs/stops/stopCode/8439?api_key=ab88cbf9-a815-4ddd-9a93-17ab16caccce
        //public void getStopID()
        //{
        //    WebClient webClient = new WebClient();
        //    string s = webClient.DownloadString("http://api.at.govt.nz/v1/gtfs/stops/stopCode/" + stop_code + "?api_key=6fbfc488-fec6-4de0-abaa-3dc5afe31002");
        //    var json = JsonConvert.DeserializeObject<StopFromStopIDRootObject>(s);

        //    stop_id = json.response[0].stop_id;
        //    stop_lat = json.response[0].stop_lat;
        //    stop_lon = json.response[0].stop_lon;
        //}

        public void getRoutes()
        {
            WebClient webClient = new WebClient();
            string s = webClient.DownloadString("http://api.at.govt.nz/v1/gtfs/routes/stopid/" + stop_id + "?api_key=6fbfc488-fec6-4de0-abaa-3dc5afe31002");
            var json = JsonConvert.DeserializeObject<BusStopList.RootObjectRoutes>(s);

            foreach(var response in json.response) {
                routes.Add(new Route(response.route_id, response.route_short_name, stop_code));
            }
            Console.WriteLine(routes.Count);
        }




        //TODO: Must find a way to fix
        public void getStopID()
        {
            var stream = Assembly.GetExecutingAssembly().GetManifestResourceStream("stop_list.txt");
            var file = new System.IO.StreamReader(stream);
            string line;
            string id;
            while ((line = file.ReadLine()) != null)
            {
                if (line.Length != 0)
                {
                    
                    id = line.Substring(0, 4);
                   
                    if (stop_code.Equals(id))
                    {
                        //stop_id = id;
                        
                    }
                }
            }
            file.Close();
        }
    }

}