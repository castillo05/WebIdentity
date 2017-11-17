using Microsoft.AspNet.Identity.Owin;
using Model;
using Service;
using Service.Auth;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace IdentiyApp.Controllers
{
    [Authorize(Roles = "Admin")]
    public class UserController : Controller
    {

        private readonly UserService _userService = new UserService();

        private ApplicationRoleManager _roleManager
        {
            get
            {
                return HttpContext.GetOwinContext().Get<ApplicationRoleManager>();
            }
        }

        private ApplicationUserManager _userManager
        {
            get
            {
                return HttpContext.GetOwinContext().Get<ApplicationUserManager>();
            }
        }
       
        public ActionResult Index()
        {
            return View(
                _userService.GetAll()
                );
        }

        public async Task CreateRoles()
        {
            var roles = new List<ApplicationRole>
            {
                new ApplicationRole {Name = "Admin" },
                new ApplicationRole {Name = "Moderator" },
                new ApplicationRole {Name = "User" }
            };

            foreach (var r in roles)
            {
                try
                {
                    if (!await _roleManager.RoleExistsAsync(r.Name))
                    {
                        var x = await _roleManager.CreateAsync(r);
                    }
                }
                catch (Exception)
                {

                    throw;
                }
            }
        }

        public async Task<ActionResult> Get(string id)
        {
            var model = await _userManager.FindByIdAsync(id);
            ViewBag.Roles = _roleManager.Roles.OrderBy(x => x.Name).ToList();

            return View(model);
        }

        public async Task<ActionResult> AddRoletoUser(string UserId, string RoleId)
        {
            var roles = await _userManager.IsInRoleAsync(UserId,RoleId);
            if (roles)
            {
                throw new Exception("Solo se puede tener un role por usuario");
            }

            await _userManager.AddToRoleAsync(UserId, RoleId);
            return RedirectToAction("Index");
        }

        


    }
}