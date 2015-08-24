﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TeamHack1337.Controllers
{
    public class Coordinate
    {
        public double latitude { get; set; }
        public double longitude { get; set; }

        public string shapeid { get; set; }

        public Coordinate(string shapeid, double latitude, double longitude)
        {
            this.shapeid = shapeid;
            this.latitude = latitude;
            this.longitude = longitude;
        }
    }
}