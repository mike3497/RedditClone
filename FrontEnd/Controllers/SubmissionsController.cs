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
        private readonly SubmissionVoteManager _submissionVoteManager;

        public SubmissionsController(SubmissionManager submissionManager, CommentManager commentManager, SubmissionVoteManager submissionVoteManager)
        {
            _submissionManager = submissionManager;
            _commentManager = commentManager;
            _submissionVoteManager = submissionVoteManager;
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
                NewComment = new Comment(),
                Comments = _commentManager.GetAllBySubmissionId(id)
            };

            return View(vm);
        }

        public ActionResult Search(string searchTerm)
        {
            var vm = new SearchSubmissionViewModel
            {
                SearchResults = _submissionManager.Search(searchTerm),
                SearchTerm = searchTerm
            };

            return View(vm);
        }

        [Authorize]
        public ActionResult Create(SubmissionType type = SubmissionType.Text)
        {
            var vm = new CreateSubmissionViewModel
            {
                Submission = new Submission
                {
                    UserId = User.Identity.GetUserId(),
                    UserName = User.Identity.GetUserName()
                },
                Type = type
            };

            return View(vm);
        }

        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(CreateSubmissionViewModel vm)
        {
            vm.Submission.Type = vm.Type;

            if (vm.Type == SubmissionType.Link)
            {
                if (String.IsNullOrWhiteSpace(vm.Submission.URL))
                {
                    ModelState.AddModelError("Submission.URL", "Please enter a URL.");
                }
                else
                {
                    if (!Uri.IsWellFormedUriString(vm.Submission.URL, UriKind.Absolute))
                    {
                        ModelState.AddModelError("Submission.URL", "Please enter a valid URL.");
                    }
                }
            }
            else
            {
                if (String.IsNullOrEmpty(vm.Submission.Content))
                {
                    ModelState.AddModelError("Submission.Content", "Please enter some content.");
                }
            }

            if (!ModelState.IsValid)
            {
                return View(vm);    
            }

            int id = _submissionManager.Create(vm.Submission);

            return RedirectToAction("View", new { @id = id });
        }

        public PartialViewResult VoteButtons(int submissionId)
        {
            string userId = User.Identity.GetUserId();

            VoteButtons voteButtons = new VoteButtons
            {
                Score = _submissionManager.GetScore(submissionId),
                UserVoteType = _submissionVoteManager.GetUserVote(submissionId, userId)
            };

            return PartialView("_VoteButtons", voteButtons);
        }

        [Authorize]
        [HttpPost]
        public JsonResult UpVote(int id)
        {
            string userId = User.Identity.GetUserId();

            if (!_submissionVoteManager.HasUserVoted(id, userId))
            {
                _submissionManager.UpVote(id);
                _submissionVoteManager.UpVote(id, userId);
            }

            return Json(_submissionManager.GetScore(id), JsonRequestBehavior.AllowGet);
        }

        [Authorize]
        [HttpPost]
        public JsonResult DownVote(int id)
        {
            string userId = User.Identity.GetUserId();

            if (!_submissionVoteManager.HasUserVoted(id, userId))
            {
                _submissionManager.DownVote(id);
                _submissionVoteManager.DownVote(id, userId);
            }

            return Json(_submissionManager.GetScore(id), JsonRequestBehavior.AllowGet);
        }
    }
}