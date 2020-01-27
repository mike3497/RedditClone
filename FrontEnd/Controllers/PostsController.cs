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
    public class PostsController : Controller
    {
        private readonly PostManager _postManager;
        private readonly CommentManager _commentManager;

        public PostsController(PostManager postManager, CommentManager commentManager)
        {
            _postManager = postManager;
            _commentManager = commentManager;
        }

        public ActionResult View(int id)
        {
            if (!_postManager.Exists(id))
            {
                return RedirectToAction("Index", "Home");
            }

            var vm = new PostsViewModel
            {
                Post = _postManager.Read(id),
                Comment = new Comment(),
                Comments = _commentManager.GetAllByPostId(id)
            };

            return View(vm);
        }

        [Authorize]
        public ActionResult Create()
        {
            Post post = new Post
            {
                UserId = User.Identity.GetUserId(),
                UserName = User.Identity.GetUserName()
            };

            return View(post);
        }

        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Post post)
        {
            if (!ModelState.IsValid)
            {
                return View(post);    
            }

            _postManager.Create(post);

            return RedirectToAction("Index", "Home");
        }
    }
}