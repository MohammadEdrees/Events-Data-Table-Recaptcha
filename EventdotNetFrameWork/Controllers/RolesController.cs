using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EventdotNetFrameWork.Models;
using Microsoft.AspNet.Identity.EntityFramework;
namespace EventdotNetFrameWork.Controllers
{
    [Authorize(Roles ="Admin")]
    public class RolesController : Controller
    {
        ApplicationDbContext context;
        public RolesController()
        {
            context = new ApplicationDbContext();
        }
        // GET: Roles
        public ActionResult Index()
        {
            var Roles = context.Roles.ToList();
            return View(Roles);
        }

        public ActionResult Create() {

            var role = new IdentityRole();
            return View(role);

        }

        [HttpPost]
        public ActionResult Create(IdentityRole role)
        {
            context.Roles.Add(role);
            context.SaveChanges();
            return RedirectToAction("Index");

        }
    }
}