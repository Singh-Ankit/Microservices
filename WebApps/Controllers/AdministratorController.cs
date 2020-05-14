using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using WebApps.ViewModels;

namespace WebApps.Controllers
{
    [Authorize]
    public class AdministratorController : Controller
    {
        private readonly RoleManager<IdentityRole> roleManager;

        public AdministratorController(RoleManager<IdentityRole> roleManager)
        {
            this.roleManager = roleManager;
        }
        [HttpGet]
        public IActionResult CreateRole()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateRole(CreateRoleViewModel model)
        {
            if (ModelState.IsValid) 
            {
                IdentityRole identityRole = new IdentityRole() 
                {
                      Name = model.RoleName,
                };
                IdentityResult identityResult = await roleManager.CreateAsync(identityRole);
                
                if(identityResult.Succeeded) 
                {
                    return RedirectToAction("index", "home");
                }
                foreach (IdentityError item in identityResult.Errors)
                {
                    ModelState.AddModelError("",  item.Description);
                }
            }
            return View(model);
        }

        [HttpGet]
        public IActionResult ListRoles() 
        {
            string _roleList = "No Roles Available";
            var role = roleManager.Roles;
            List<string> dataList = new List<string>();
            if (role.Count() != 0)
            {
                _roleList = String.Empty;
               // _roleList = role.Select(x => x.Name).ToList().ToString();
                foreach (var item in role)
                {
                    _roleList = _roleList + " " + item.Name;
                }
            }
            return Content(_roleList);
        }
    }
}