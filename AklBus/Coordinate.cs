﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AklBus
{
    class Coordinate
    {
        public double latitude { get; set; }
        public double longitude { get; set; }

        public Coordinate(double latitude, double longitude)
        {
            this.latitude = latitude;
            this.longitude = longitude;
        }
    }
}
