using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TeamHack1337.Model
{
    public class RealTimeBoardClass
    {
        public class Movement
        {
            public DateTime ActualArrivalTime { get; set; }
            public DateTime ActualDepartureTime { get; set; }
            public string ArrivalBoardingActivity { get; set; }
            public object ArrivalPlatformName { get; set; }
            public string ArrivalStatus { get; set; }
            public string DepartureBoardingActivity { get; set; }
            public object DeparturePlatformName { get; set; }
            public string DestinationDisplay { get; set; }
            public DateTime? ExpectedArrivalTime { get; set; }
            public DateTime? ExpectedDepartureTime { get; set; }
            public bool InCongestion { get; set; }
            public bool Monitored { get; set; }
            public string Route { get; set; }
            public string Stop { get; set; }
            public DateTime TimeStamp { get; set; }
            public object VehicleJourneyName { get; set; }
        }

        public class RootObject
        {
            public object Error { get; set; }
            public List<object> Extensions { get; set; }
            public List<Movement> Movements { get; set; }
        }
    }
}