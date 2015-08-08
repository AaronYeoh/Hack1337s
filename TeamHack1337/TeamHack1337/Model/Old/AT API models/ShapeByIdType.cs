using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TeamHack1337.Model.AT_API_models
{
    //api.at.govt.nz/v1/gtfs/shapes/shapeId/0245?api_key=ab88cbf9-a815-4ddd-9a93-17ab16caccce
    public class ShapeResponse
    {
        public string shape_id { get; set; }
        public double shape_pt_lat { get; set; }
        public double shape_pt_lon { get; set; }
        public int shape_pt_sequence { get; set; }
        public object shape_dist_traveled { get; set; }
    }

    public class ShapeByIdObject
    {
        public string status { get; set; }
        public List<ShapeResponse> response { get; set; }
        public object error { get; set; }
    }
}