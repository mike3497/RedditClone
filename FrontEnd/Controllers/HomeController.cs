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

        public ActionResult Index(int page = 1, int numPerPage = 5)
        {
            var vm = new HomeViewModel();

            double total = _submissionManager.GetTotalCount();
            int pageCount = (int)Math.Ceiling(total / numPerPage);

            try
            {
                vm.Submissions = _submissionManager.GetPaged(page, numPerPage);
                vm.PageNumber = page;
                vm.PageCount = pageCount;
            }
            catch (Exception ex)
            {
                vm.Submissions = _submissionManager.GetPaged(1, numPerPage);
                vm.PageNumber = 1;
                vm.PageCount = pageCount;
            }

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