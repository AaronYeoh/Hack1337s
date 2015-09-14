using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TeamHack1337.Controllers;

namespace TeamHack1337.Model
{
    public class BusStopModel
    {
        public string stop_code { get; set; }
        public string stop_id { get; set; }
        public string stop_lat { get; set; }
        public string stop_lon { get; set; }
        public List<Route> routes { get; set; }
    }
}