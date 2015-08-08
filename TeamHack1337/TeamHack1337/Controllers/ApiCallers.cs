using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;

namespace TeamHack1337.Controllers
{
    public interface IApiCaller
    {

    }

    public class ApiCaller : IApiCaller
    {
        private string GetString()
        {
            //string response 
        }
    }

    public interface IStringGetter
    {
        string GetString();
    }

    public class GetStringFromUrl : IStringGetter
    {
        public string GetString(string url)
        {
            WebClient webClient = new WebClient();

            var str = webClient.
        }
    }


}