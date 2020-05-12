using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApps.Helper
{
    public interface ILiveSessionService
    {
        Task<IList<LiveSession>> GetPrivateSession(string primarySkill);
    }
}
