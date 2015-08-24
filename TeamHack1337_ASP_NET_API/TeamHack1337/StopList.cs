using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Caching;
using Newtonsoft.Json;
using TeamHack1337.Model;

namespace TeamHack1337
{

    public class StopList
    {
        private Cache Cache = HttpRuntime.Cache;
        public List<AllStops.Response> AllStops { get; set; }
        //Request the resource 
        public StopList(){
			LoadStops();
		}
		
		private void LoadStops()
		{
		    string cache_key = "stops_list";
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
		        s = temp.ToString();
		    }
		    else
            {
		        s =webClient.DownloadString(
		                "http://api.at.govt.nz/v1/gtfs/stops?api_key=6fbfc488-fec6-4de0-abaa-3dc5afe31002");
                if (s != null)
                {
                    var expiration = DateTime.Now.AddDays(1);
                    var sliding = Cache.NoSlidingExpiration;
                    Cache.Insert(cache_key, s,null, expiration, sliding);
                }
            }
		    AllStops.RootObject json = JsonConvert.DeserializeObject<AllStops.RootObject>(s);
		    AllStops = json.response;

		}
    }
}