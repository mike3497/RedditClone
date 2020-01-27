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
    public class CommentsController : Controller
    {
        private readonly CommentManager _commentManager;

        public CommentsController(CommentManager commentManager)
        {
            _commentManager = commentManager;
        }

        [HttpPost]
        public ActionResult Create(PostsViewModel comment)
        {
            comment.Comment.UserId = User.Identity.GetUserId();
            comment.Comment.UserName = User.Identity.GetUserName();

            _commentManager.Create(comment.Comment);

            return RedirectToAction("Index", "Home");
        }
    }
}