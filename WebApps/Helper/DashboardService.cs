using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
//using Model;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using WebApps.HelperModels;

namespace WebApps.Helper
{
    public class DashboardService : IDashboardService
    {
        private readonly IConfiguration configuration;

        //bool accessTokenFlag = default(bool);

        public DashboardService(IConfiguration configuration)
        {
            this.configuration = configuration;
        }
       
        public async Task<bool> EnrollForCourse(string Email, int CourseID)
        {
            MyCourses objMyCoursesRequest;
            try 
            {
                using (var client = new HttpClient())
                {
                    objMyCoursesRequest = new MyCourses() 
                    { CourseId = CourseID.ToString(), emailID = Email, enrollmentDate = DateTime.Today.ToString("D") };
                    var SerilzeRequestObject = JsonConvert.SerializeObject(objMyCoursesRequest);
                  //  client.BaseAddress = new Uri(Convert.ToString(configuration.GetSection("URLpatterns:addCourse").Value));
                    var httpRequest = new HttpRequestMessage(HttpMethod.Post, (Convert.ToString(configuration.GetSection("URLpatterns:addCourse").Value)));
                    httpRequest.Content = new StringContent(SerilzeRequestObject, Encoding.UTF8, "application/json"); ;
                    var Response = await client.SendAsync(httpRequest);
                    if (Response.IsSuccessStatusCode)
                    {
                        var ReadResponse = await Response.Content.ReadAsStringAsync();
                       // var DserlizedResponse = JsonConvert.DeserializeObject<List<MyCourses>>(ReadResponse);
                        return true;
                    }
                    else { Response.EnsureSuccessStatusCode(); return false; }
                }
            }
            catch 
            {
                return false;
            }
            throw new NotImplementedException();
        }
    }
}
