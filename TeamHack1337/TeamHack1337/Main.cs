using FileHelpers;
using Nancy;
using Newtonsoft.Json;

namespace TeamHack1337
{
    public class HelloModule : NancyModule
    {
        public HelloModule()
        {
            Get["/"] = parameters => "Hello World";

            Get["/stop_code={stop_code}"] = parameters => "Your stop code is "+ parameters.stop_code;

            Get["/initiatecacherefresh"] = _ =>
            {
                //refresh
                return "Done";
            };
        }

    }
}