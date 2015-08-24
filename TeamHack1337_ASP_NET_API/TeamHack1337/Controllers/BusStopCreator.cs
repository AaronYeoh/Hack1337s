using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TeamHack1337.Controllers
{
    public class BusStopCreator
    {

        public BusStop CreateBusStop(string stopCode)
        {
            return new BusStop(stopCode);
        }
    }
}