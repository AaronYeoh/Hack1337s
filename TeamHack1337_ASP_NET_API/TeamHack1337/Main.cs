using System.Collections.Generic;
using System.IO;
using System.Text;
using FileHelpers;
using Nancy;
using Newtonsoft.Json;
using TeamHack1337.Controllers;
using TeamHack1337.Model;

namespace TeamHack1337
{
    public class HelloModule : NancyModule
    {
        public HelloModule()
        {
            Get["/"] = parameters => "Hello World";

            Get["/text/stop_code={stop_code}"] = parameters => "Your stop code is " + parameters.stop_code;

            Get["/stop_code={stop_code}"] = parameters =>
            {
                BusStopCreator busStopCreator = new BusStopCreator();

                //Create busstop
                BusStop busStop = busStopCreator.CreateBusStop(parameters.stop_code.ToString());

                string str = JsonConvert.SerializeObject(busStop.BusStopInstance);
                var jsonBytes = Encoding.UTF8.GetBytes(str);
                return new Response
                {
                    ContentType = "application/json",
                    Contents = s => s.Write(jsonBytes, 0, jsonBytes.Length)
                };

            };
            Get["/bus_stops"] = _ =>
            {
                List<SimpleBusStop> busStopList = new List<SimpleBusStop>();
                StopList stopList = new StopList();

                var allstops = stopList.AllStops;

                foreach (var stop in allstops)
                {
                    var busstop = new SimpleBusStop(stop.stop_code, stop.stop_id, stop.stop_lat.ToString(), stop.stop_lon.ToString());
                    busStopList.Add(busstop);
                }

                string str = JsonConvert.SerializeObject(busStopList);
                var jsonBytes = Encoding.UTF8.GetBytes(str);
                var resp = new Response();
                resp.ContentType = "application/json";
                resp.Contents = s => s.Write(jsonBytes, 0, jsonBytes.Length);
                resp.WithHeader("Access-Control-Allow-Origin", "*");
                return resp;
            };
        }

    }
}