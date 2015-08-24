using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TeamHack1337.Model.AT_API_models
{
    //api.at.govt.nz/v1/gtfs/routes/stopid/2005?api_key=ab88cbf9-a815-4ddd-9a93-17ab16caccce
    public class RoutesResponse
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

    public class RoutesByStopIdObject
    {
        public string status { get; set; }
        public List<RoutesResponse> response { get; set; }
        public object error { get; set; }

    }
}