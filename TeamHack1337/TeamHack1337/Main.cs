using Nancy;

namespace TeamHack1337
{
    public class HelloModule : NancyModule
    {
         public HelloModule()
            {
                Get["/"] = parameters => "Hello World";
                Get["/{category}"] = parameters => "My category is " + parameters.category;
            }
    }
}