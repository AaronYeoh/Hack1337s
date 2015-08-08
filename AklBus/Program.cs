using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AklBus {
    class Program
    {
        static void Main(string[] args)
        {
            
            string stop_code = "2238";
            BusStop busStop = new BusStop(stop_code);
            Console.WriteLine(busStop.routes[0].shape_id);
            Console.ReadKey();
        }
    }
}


//string s = webClient.DownloadString("http://api.at.govt.nz/v1/gtfs/stops?api_key=6fbfc488-fec6-4de0-abaa-3dc5afe31002");
/*var json = JsonConvert.DeserializeObject<BusStopList.RootObject>(s);

            foreach(var response in json.response) {
                Console.Write(response.stop_id + " " + response.stop_code + " " + response.stop_lat + " " + response.stop_lon + "\n");
                Console.WriteLine();
            }
            Console.ReadKey();*/