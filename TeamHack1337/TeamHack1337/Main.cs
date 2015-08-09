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

                string str = JsonConvert.SerializeObject(busStop);
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
                var file = stopList.List;
                var lines = file.Split('\n');

                for (int i = 0; i < lines.Length; i++)
                {
                    var lineElements = lines[i].Split(' ');

                    var stop_id = lineElements[0];
                    var stop_code = lineElements[1];

                    var stop_lat = lineElements[2];
                    var stop_lon = lineElements[3];
                    var busstop = new SimpleBusStop(stop_code, stop_id, stop_lat, stop_lon);
                    busStopList.Add(busstop);
                }

                string str = JsonConvert.SerializeObject(busStopList);
                var jsonBytes = Encoding.UTF8.GetBytes(str);
                return new Response
                {
                    ContentType = "application/json",
                    Contents = s => s.Write(jsonBytes, 0, jsonBytes.Length)
                };
            };
        }

    }
}