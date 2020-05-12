using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Model;
using WebApps.Helper;
using WebApps.Identity;
using WebApps.Models;
using WebApps.ViewModels;

namespace WebApps.Controllers
{
    
    public class LiveSessionsController : Controller
    {
        private readonly UserManager<ApplicationUser> userManager;
        private readonly SignInManager<ApplicationUser> signInManager;
       // private readonly ILogger<HomeController> _logger;
        private readonly ILiveSessionService _liveSessionService;

        public LiveSessionsController(UserManager<ApplicationUser> userManager,
            SignInManager<ApplicationUser> signInManager, ILiveSessionService liveSessionService)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
            _liveSessionService = liveSessionService;
        }

        [HttpGet]
        public async Task<IActionResult> ListAllSessions()
        {
            IList<LiveSessionViewModel> webinar = new List<LiveSessionViewModel>();
            if (ModelState.IsValid)
            {
                var details = userManager.GetUserAsync(User);

                var Test1 = userManager.GetUserId(User);
                //string emailId = TempData["LoggedUser"].ToString();
                bool isLoggedIn = signInManager.IsSignedIn(User);
                LiveSession objliveSession = new LiveSession();

                if (isLoggedIn)
                {
                    string _primarySkill = details.Result.primarySkill;
                    string email = details.Result.Email;

                    IList<LiveSession> _result = await _liveSessionService.GetPrivateSession(_primarySkill);
                    if (_result.Count != 0)
                    {
                        foreach (var item in _result)
                        {
                            webinar.Add(new LiveSessionViewModel()
                            {
                                SId = item.SId,
                                description = item.description,
                                duration = item.duration,
                                isPrivate = item.isPrivate,
                                organiser = item.organiser,
                                Url = item.Url,
                                sessionCategory = item.sessionCategory
                            });
                        }

                        return View(webinar);
                    }
                    else 
                    {
                        TempData["NoSession"] = "You will soon see a private session here!";
                        return View(webinar);
                    }
                    
                }
                else
                {
                    return View();
                }
            }
            else 
            {
                return View(webinar);
            }
          
        }
    }
}