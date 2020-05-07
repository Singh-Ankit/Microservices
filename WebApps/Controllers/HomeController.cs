using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using WebApps.Models;
using WebApps.Helper;
using System.Net.Http;
using Newtonsoft.Json;
using WebApps.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Http;
using X.PagedList;

namespace WebApps.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly UserManager<ApplicationUser> userManager;
        private readonly SignInManager<ApplicationUser> signInManager;
        private readonly IDashboardService _dashboardService;

        Helper_catalogue _api = new Helper_catalogue();
        //private readonly Helper_catalogue _api;

        public HomeController(ILogger<HomeController> logger, UserManager<ApplicationUser> userManager,
            SignInManager<ApplicationUser> signInManager, IDashboardService dashboardService)
        {
            _logger = logger;
            _dashboardService = dashboardService;
            this.userManager = userManager;
            this.signInManager = signInManager;
        }

        public async Task<IActionResult> Index(int? page)
        
        {
            var pageNumber = page ?? 1; // if no page is specified, default to the first page (1)
            int pageSize = 8; // Get 25 students for each requested page.
            List<CatalogueViewModel> catalogueViewModel = new List<CatalogueViewModel>();
            HttpClient client = _api.Initial();
            HttpResponseMessage res = await client.GetAsync("api/Catalogues");
            if (res.IsSuccessStatusCode)
            {
                var ReadResponse = res.Content.ReadAsStringAsync().Result;
                catalogueViewModel = JsonConvert.DeserializeObject<List<CatalogueViewModel>>(ReadResponse);
            }
           ;
            //X.PagedList.Mvc.Common.PagedListRenderOptions
           // X.PagedList.Mvc.Core.Common.PagedListRenderOptions
            //return View(catalogueViewModel);
            return View(catalogueViewModel.ToPagedList(pageNumber, pageSize));
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Enroll(int id) 
        {
            if (ModelState.IsValid)
            {
               string emailId = TempData["LoggedUser"].ToString();
               bool isLoggedIn = signInManager.IsSignedIn(User);
               bool enrollCourse = await _dashboardService.EnrollForCourse(emailId, id);
                if (enrollCourse)
                {
                    ViewBag.IsEnrolled = "Yes";
                    TempData["AlertMessage"] = "Yes";
                    return RedirectToAction("index", "home");
                }
                else 
                {
                    ViewBag.IsEnrolled = "No";
                    TempData["AlertMessage"] = "No";
                    return RedirectToAction("index", "home");
                }
            }
            return Content("Not Enrolled");
        }
    }
}
