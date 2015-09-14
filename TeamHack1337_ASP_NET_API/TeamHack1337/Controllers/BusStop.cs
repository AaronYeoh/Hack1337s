using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Web;
using Newtonsoft.Json;
using TeamHack1337.Model;
using System.Web.Caching;

namespace TeamHack1337.Controllers
{
    public class BusStop
    {
        public BusStopModel BusStopInstance { get; set; }
        public BusStop(string stop_code)
        {
            LoadStop(stop_code);
        }


        private void LoadStop(string stop_code)
        {
               
            var Cache = HttpRuntime.Cache;
            string cache_key = stop_code;
            WebClient webClient = new WebClient();
            string s;
            object temp = null;
            try
            {
                temp = Cache.Get(cache_key);
            }
            catch
            { //chomp!
            }
            if (temp != null)
            {
                BusStopInstance = temp as BusStopModel;
            }
            else
            {
                BusStopInstance = new BusStopModel();         
                BusStopInstance.stop_code = stop_code;
                BusStopInstance.routes = new List<Route>();

                getStopID(stop_code);

                if (BusStopInstance.stop_id != null)
                {
                    getRoutes(stop_code);
                }
                else
                {
                    Debug.WriteLine("Bad stop code");
                }

                    
                var expiration = DateTime.Now.AddDays(1);
                var sliding = Cache.NoSlidingExpiration;
                Cache.Insert(cache_key, BusStopInstance, null, expiration, sliding);
                
            }
                       
            if (BusStopInstance != null)
            {
                getArrivalTimes(stop_code); 
            }
           
        }


        public void getArrivalTimes(string stop_code)
        {
            WebClient webClient = new WebClient();
            

            string s = webClient.DownloadString("http://api.maxx.co.nz/RealTime/v2/Departures/Stop/" + stop_code);
            var json = JsonConvert.DeserializeObject<RealTimeBoardClass.RootObject>(s);

            foreach (var route in BusStopInstance.routes)
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
                                var nztime = DateToNZTime(movement.ExpectedArrivalTime.GetValueOrDefault());
                                route.ArrivalTimes.Add(nztime);
                            }
                            else
                            {
                                var nztime = DateToNZTime(movement.ActualArrivalTime.GetValueOrDefault());
                                route.ArrivalTimes.Add(nztime);
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

        private static string DateToNZTime(DateTime time)
        {
            var nzTimeZone = TimeZoneInfo.FindSystemTimeZoneById("New Zealand Standard Time");
            var nzTime = TimeZoneInfo.ConvertTime(time, nzTimeZone);
            //var nzTime = TimeZoneInfo.ConvertTimeFromUtc(time, nzTimeZone);

            var shortTime = nzTime.ToShortTimeString();
            return shortTime;
        }

        public void getRoutes(string stop_code)
        {
            WebClient webClient = new WebClient();
            try
            {
                string s =
                    webClient.DownloadString("http://api.at.govt.nz/v1/gtfs/routes/stopid/" + BusStopInstance.stop_id +
                                             "?api_key=6fbfc488-fec6-4de0-abaa-3dc5afe31002");
                var json = JsonConvert.DeserializeObject<BusStopList.RootObjectRoutes>(s);

                foreach (var response in json.response)
                {
                    BusStopInstance.routes.Add(new Route(response.route_id, response.route_short_name, stop_code));
                }
                Debug.WriteLine(BusStopInstance.routes.Count);
            }
            catch (Exception e)
            {
            }
        }









        public void getStopID(string stop_code)
        {
            //var stream = Assembly.GetExecutingAssembly().GetManifestResourceStream("stop_list.txt");
            StopList stopList = new StopList();

            var allstops = stopList.AllStops;

            foreach (var stop in allstops)
            {
                if (stop_code == stop.stop_code)
                {
                    BusStopInstance.stop_id = stop.stop_id;
                    BusStopInstance.stop_lat = stop.stop_lat.ToString();
                    BusStopInstance.stop_lon = stop.stop_lon.ToString();
                }
            }

        }
    }

}