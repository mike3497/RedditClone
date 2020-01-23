using Common.Models;
using Managers.Managers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FrontEnd.Controllers
{
    public class HomeController : Controller
    {
        private readonly PostManager _postManager;

        public HomeController(PostManager postManager)
        {
            _postManager = postManager;
        }

        public ActionResult Index()
        {
            var posts = _postManager.GetAll();

            return View(posts);
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