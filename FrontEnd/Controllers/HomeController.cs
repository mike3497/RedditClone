using Common.Models;
using FrontEnd.Models;
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
        private readonly SubmissionManager _submissionManager;

        public HomeController(SubmissionManager submissionManager)
        {
            _submissionManager = submissionManager;
        }

        public ActionResult Index(int page = 1, int numPerPage = 5, SortType sort = SortType.Date)
        {
            var vm = new HomeViewModel();

            double total = _submissionManager.GetTotalCount();
            int pageCount = (int)Math.Ceiling(total / numPerPage);
            vm.Submissions = _submissionManager.GetPaged(page, numPerPage, sort);
            vm.PageNumber = page;
            vm.PageCount = pageCount;
            vm.SortType = sort;

            return View(vm);
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