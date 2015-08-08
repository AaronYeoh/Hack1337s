using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using Newtonsoft.Json;


namespace AklBus
{
    class BusStop
    {
        public string stop_code { get; set; }
        public string stop_id { get; set; }
        public double stop_lat { get; set; }
        public double stop_lon { get; set; }
        public List<Route> routes { get; set; }
        public string filename = "stop_list.txt";
        public WebClient webClient = new WebClient();

        public BusStop(string stop_code)
        {
            this.stop_code = stop_code;
            routes = new List<Route>();
            getStopID();
            getRoutes();
        }

        public void getRoutes()
        {
            stop_id = "0001";
            string s = webClient.DownloadString("http://api.at.govt.nz/v1/gtfs/routes/stopid/" + stop_id + "?api_key=6fbfc488-fec6-4de0-abaa-3dc5afe31002");
            var json = JsonConvert.DeserializeObject<BusStopList.RootObjectRoutes>(s);

            foreach(var response in json.response) {
                routes.Add(new Route(response.route_id));
            }
            Console.WriteLine(routes.Count);
        }

        public void getStopID()
        {
            var file = new System.IO.StreamReader(filename);
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
