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
        public ActionResult Create(Comment comment)
        {
            comment.UserId = User.Identity.GetUserId();
            comment.UserName = User.Identity.GetUserName();

            _commentManager.Create(comment);

            return RedirectToAction("View", "Posts", new { @id = comment.SubmissionId });
        }
    }
}