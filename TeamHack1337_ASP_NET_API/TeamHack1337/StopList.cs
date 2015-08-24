using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using Newtonsoft.Json;
using TeamHack1337.Model;

namespace TeamHack1337
{

    public class StopList
    {
        public List<AllStops.Response> AllStops { get; set; }
        //Request the resource 
        public StopList(){
			LoadStops();
		}
		
		private void LoadStops(){
			WebClient webClient = new WebClient();
            string s = webClient.DownloadString("http://api.at.govt.nz/v1/gtfs/stops?api_key=6fbfc488-fec6-4de0-abaa-3dc5afe31002");
            AllStops.RootObject json = JsonConvert.DeserializeObject<AllStops.RootObject>(s);
		    AllStops = json.response;

		}
    }
}