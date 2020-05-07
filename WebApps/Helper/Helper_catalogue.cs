using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace WebApps.Helper
{
    public class Helper_catalogue
    {
        public HttpClient Initial() 
        {
            var client = new HttpClient();
            client.BaseAddress = new Uri("https://localhost:44313/");
            return client;

            //using (var client = new HttpClient())
            //{
            //    try
            //    {
                    
            //    } 
            //    catch (Exception ex) 
            //    {
            //        throw ex;
            //    }
            //}
        }
    }
}
