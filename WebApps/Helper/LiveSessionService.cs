using Microsoft.Extensions.Configuration;
using Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace WebApps.Helper
{
    public class LiveSessionService : ILiveSessionService
    {
        private readonly IConfiguration configuration;
        public LiveSessionService(IConfiguration configuration)
        {
            this.configuration = configuration;
        }

        //async Task<ActionResult<EventsResponse>>
        public async Task<IList<LiveSession>> GetPrivateSession(string primarySkill)
        {
            List<LiveSession> objLiveSession;
            try
            {
                using (var client = new HttpClient())
                {
                   
                   // objLiveSession = new LiveSession();
                    var httpRequest = new HttpRequestMessage(HttpMethod.Get, (Convert.ToString(configuration.GetSection("URLpatterns:getLiveSession").Value + primarySkill)));
                    var Response = await client.SendAsync(httpRequest);
                    if (Response.IsSuccessStatusCode)
                    {
                        var ReadResponse = await Response.Content.ReadAsStringAsync();

                        var DserlizedResponse = JsonConvert.DeserializeObject<IList<LiveSession>>(ReadResponse);

                        return DserlizedResponse;
                    }
                    else
                    {
                        Response.EnsureSuccessStatusCode();
                        objLiveSession = new List<LiveSession>() { 
                            new LiveSession() { 
                              ErrorMsg = "Not Success Call"
                            }
                        };
                        return objLiveSession;
                    }
                }
            }
            catch (Exception ex)
            {
                objLiveSession = new List<LiveSession>() {
                            new LiveSession() {
                              ErrorMsg = ex.Message
                            }
                        };
                return objLiveSession;
            }
        }
    }
}
