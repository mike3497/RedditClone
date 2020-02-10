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
    [Authorize]
    public class CommentsController : Controller
    {
        private readonly CommentManager _commentManager;

        public CommentsController(CommentManager commentManager)
        {
            _commentManager = commentManager;
        }

        [HttpPost]
        public ActionResult Create(SubmissionsViewModel vm)
        {
            vm.NewComment.UserId = User.Identity.GetUserId();
            vm.NewComment.UserName = User.Identity.GetUserName();

            vm.NewComment.SubmissionId = vm.Submission.Id;

            _commentManager.Create(vm.NewComment);

            return RedirectToAction("View", "Submissions", new { @id = vm.Submission.Id });
        }
    }
}