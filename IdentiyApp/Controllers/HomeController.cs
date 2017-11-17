using Model;
using Model.ModelContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace IdentiyApp.Controllers
{
    [AllowAnonymous]
    public class HomeController : Controller
    {

        private AspNetUsers AspNetUser_ = new AspNetUsers();

        public ActionResult Index(string name)
        {
            if (string.IsNullOrEmpty(name))
            {
                return View(AspNetUser_.Listar());
            }
            else
            {
                ViewBag.Name = name;
                return View(AspNetUser_.Listar().Where(c => c.Name.ToLower().Contains(name)));
            }



        }


    

    public JsonResult LlamarJson(string name)
    {
        var output = AspNetUser_.Listar();
        return Json(output, JsonRequestBehavior.AllowGet);
    }
    public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }
        
        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}