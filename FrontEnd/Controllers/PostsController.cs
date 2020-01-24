using Common.Models;
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
    public class PostsController : Controller
    {
        private readonly PostManager _postManager;

        public PostsController(PostManager postManager)
        {
            _postManager = postManager;
        }

        // GET: Posts
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Create()
        {
            Post post = new Post
            {
                UserId = User.Identity.GetUserId(),
                UserName = User.Identity.GetUserName()
            };

            return View(post);
        }
        
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