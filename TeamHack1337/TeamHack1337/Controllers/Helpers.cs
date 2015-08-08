using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TeamHack1337
{
    public class WebApiHelper
    {
        WebApiHelper()
        {
            
        }
    }

    public interface IUrlGenerator
    {
        string GenerateUrl();
    }
}