using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using FileHelpers;
using Newtonsoft.Json;

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

    //public class FileHelper<T> where T : class
    //{
    //    private void OpenFile()
    //    {
    //        //var engine = new FileHelperEngine<T>();
    //        var engine = new FileHelperEngine<HelloModule.Stop>();
    //        var hello = engine.ReadFile(@"~\Resources\stop_list.csv");
    //        JsonConvert.SerializeObject(hello);
    //        return;
    //    }

    //    private void WriteFile()
    //    {
    //        File.Create()
    //    }

    //}

    public class BusStopLocation
    {

    }

}