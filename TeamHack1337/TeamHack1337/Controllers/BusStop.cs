using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Web;
using Newtonsoft.Json;
using TeamHack1337.Model;

namespace TeamHack1337.Controllers
{
    public class BusStop
    {
        public string stop_code { get; set; }
        public string stop_id { get; set; }
        public string stop_lat { get; set; }
        public string stop_lon { get; set; }
        public List<Route> routes { get; set; }
        // public string filename = "stop_list.txt";


        public BusStop(string stop_code)
        {
            this.stop_code = stop_code;
            routes = new List<Route>();
            
            getStopID();
            getRoutes();
            getArrivalTimes(stop_code);

        }

        public void getArrivalTimes(string stop_code)
        {
            WebClient webClient = new WebClient();

            string s = webClient.DownloadString("http://api.maxx.co.nz/RealTime/v2/Departures/Stop/" + stop_code);
            var json = JsonConvert.DeserializeObject<RealTimeBoardClass.RootObject>(s);

            foreach (var route in routes)
            {
                try
                {

                    if (route.ArrivalTimes == null)
                    {
                        route.ArrivalTimes = new List<string>();
                    }

                    foreach (var movement in json.Movements)
                    {
                        if (movement.Route == route.route_short_name)
                        {
                            if (movement.ExpectedArrivalTime != null)
                            {
                                route.ArrivalTimes.Add(
                                    movement.ExpectedArrivalTime.GetValueOrDefault().ToLocalTime().ToShortTimeString());
                            }
                            else
                            {
                                route.ArrivalTimes.Add(
                                    movement.ActualArrivalTime.ToLocalTime().ToLocalTime().ToShortTimeString());
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

        public void getRoutes()
        {
            WebClient webClient = new WebClient();
            string s = webClient.DownloadString("http://api.at.govt.nz/v1/gtfs/routes/stopid/" + stop_id + "?api_key=6fbfc488-fec6-4de0-abaa-3dc5afe31002");
            var json = JsonConvert.DeserializeObject<BusStopList.RootObjectRoutes>(s);

            foreach (var response in json.response)
            {
                routes.Add(new Route(response.route_id, response.route_short_name, stop_code));
            }
            Console.WriteLine(routes.Count);
        }




        //TODO: Must find a way to fix
        public void getStopID()
        {
            //var stream = Assembly.GetExecutingAssembly().GetManifestResourceStream("stop_list.txt");
            StopList stopList = new StopList();
            var file = stopList.List;
            var lines = file.Split('\n');

            for (int i = 0; i < lines.Length; i++)
            {
                var lineElements = lines[i].Split(' ');
                if (stop_code.Equals(lineElements[1]))
                {
                    stop_id = lineElements[0];
                    stop_lat = lineElements[2];
                    stop_lon = lineElements[3];
                    break;
                }
            }
        }
    }

}