﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TeamHack1337.Controllers
{
    public class StopIDResponse
    {
        public string stop_id { get; set; }
        public string stop_name { get; set; }
        public object stop_desc { get; set; }
        public double stop_lat { get; set; }
        public double stop_lon { get; set; }
        public object zone_id { get; set; }
        public object stop_url { get; set; }
        public string stop_code { get; set; }
        public object stop_street { get; set; }
        public object stop_city { get; set; }
        public object stop_region { get; set; }
        public object stop_postcode { get; set; }
        public object stop_country { get; set; }
        public object location_type { get; set; }
        public object parent_station { get; set; }
        public object stop_timezone { get; set; }
        public object wheelchair_boarding { get; set; }
        public object direction { get; set; }
        public object position { get; set; }
        public string the_geom { get; set; }
    }

    public class StopFromStopIDRootObject
    {
        public string status { get; set; }
        public List<StopIDResponse> response { get; set; }
        public object error { get; set; }
    }
}