using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AklBus {
    class Program
    {
        static void Main(string[] args)
        {
            string stop_code = "7106";
            BusStop busStop = new BusStop(stop_code);
        }
    }
}