using Common.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FrontEnd.Models
{
    public class PostsViewModel
    {
        public Post Post { get; set; }
        public Comment Comment { get; set; }
        public IEnumerable<Comment> Comments { get; set; }
    }
}