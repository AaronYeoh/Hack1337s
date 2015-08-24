using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TeamHack1337.Model
{
    public class SimpleBusStop
    {
        public string stop_code { get; set; }
        public string stop_id { get; set; }
        public string stop_lat { get; set; }
        public string stop_lon { get; set; }

        public SimpleBusStop(string stopCode, string stopId, string stopLat, string stopLon)
        {
            stop_lat = stopLat;
            stop_lon = stopLon;
            stop_code = stopCode;
            stop_id = stopId;
        }
    }
}