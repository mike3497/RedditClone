using Common.Models;
using FrontEnd.Models;
using Managers.Managers;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FrontEnd.Controllers
{
    public class SubmissionsController : Controller
    {
        private readonly SubmissionManager _submissionManager;
        private readonly CommentManager _commentManager;

        public SubmissionsController(SubmissionManager submissionManager, CommentManager commentManager)
        {
            _submissionManager = submissionManager;
            _commentManager = commentManager;
        }

        public ActionResult View(int id)
        {
            if (!_submissionManager.Exists(id))
            {
                return RedirectToAction("Index", "Home");
            }

            var vm = new SubmissionsViewModel
            {
                Submission = _submissionManager.Read(id),
                Comment = new Comment(),
                Comments = _commentManager.GetAllByPostId(id)
            };

            return View(vm);
        }

        public ActionResult Search(string searchTerm)
        {
            var list = _submissionManager.Search(searchTerm);

            return View(list);
        }

        [Authorize]
        public ActionResult Create()
        {
            Submission submission = new Submission
            {
                UserId = User.Identity.GetUserId(),
                UserName = User.Identity.GetUserName()
            };

            return View(submission);
        }

        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Submission submission)
        {
            if (submission.Type == SubmissionType.Link)
            {
                if (submission.Content != "")
                {
                    if (!Uri.IsWellFormedUriString(submission.Content, UriKind.Absolute))
                    {
                        ModelState.AddModelError("Content", "Please enter a valid URL.");
                    }
                }
            }

            if (!ModelState.IsValid)
            {
                return View(submission);    
            }

            int id = _submissionManager.Create(submission);

            return RedirectToAction("View", new { @id = id });
        }
    }
}