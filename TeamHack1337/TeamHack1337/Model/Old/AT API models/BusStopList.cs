using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TeamHack1337.Model.AT_API_models
{
    class BusStopList
    {
        public class Response
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
        public class RootObject
        {
            public string status { get; set; }
            public List<Response> response { get; set; }
        }

        public class ResponseRoutes
        {
            public string route_id { get; set; }
            public string agency_id { get; set; }
            public string route_short_name { get; set; }
            public string route_long_name { get; set; }
            public object route_desc { get; set; }
            public int route_type { get; set; }
            public object route_url { get; set; }
            public string route_color { get; set; }
            public string route_text_color { get; set; }
        }
        public class RootObjectRoutes
        {
            public string status { get; set; }
            public List<ResponseRoutes> response { get; set; }
        }
        public class ResponseShapeID
        {
            public string route_id { get; set; }
            public string service_id { get; set; }
            public string trip_id { get; set; }
            public string trip_headsign { get; set; }
            public int direction_id { get; set; }
            public object block_id { get; set; }
            public string shape_id { get; set; }
            public object trip_short_name { get; set; }
            public object trip_type { get; set; }
        }
        public class RootObjectShapeID
        {
            public string status { get; set; }
            public List<ResponseShapeID> response { get; set; }
        }
        public class ResponseShapePoints
        {
            public string shape_id { get; set; }
            public double shape_pt_lat { get; set; }
            public double shape_pt_lon { get; set; }
            public int shape_pt_sequence { get; set; }
            public object shape_dist_traveled { get; set; }
        }
        public class RootObjectShapePoints
        {
            public string status { get; set; }
            public List<ResponseShapePoints> response { get; set; }
        }
    }
}