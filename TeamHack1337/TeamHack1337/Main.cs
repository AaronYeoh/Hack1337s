using System.IO;
using System.Text;
using FileHelpers;
using Nancy;
using Newtonsoft.Json;
using TeamHack1337.Controllers;

namespace TeamHack1337
{
    public class HelloModule : NancyModule
    {
        public HelloModule()
        {
            Get["/"] = parameters => "Hello World";

            Get["/text/stop_code={stop_code}"] = parameters => "Your stop code is "+ parameters.stop_code;

            Get["/stop_code={stop_code}"] = parameters =>
            {
                BusStopCreator busStopCreator = new BusStopCreator();
                BusStop busStop = busStopCreator.CreateBusStop(parameters.stop_code.ToString());
                string str =  JsonConvert.SerializeObject(busStop);
                var jsonBytes = Encoding.UTF8.GetBytes(str);
                return new Response
                {
                    ContentType = "application/json",
                    Contents = s => s.Write(jsonBytes, 0, jsonBytes.Length)
                };
                
            };
            Get["/initiatecacherefresh"] = _ =>
            {
                //refresh
                return File.ReadAllText("/Resources/stop_list.csv");

            };
        }

    }
}