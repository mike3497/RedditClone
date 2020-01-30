using Common.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FrontEnd.Models
{
    public class HomeViewModel
    {
        public IEnumerable<PostDetails> Posts { get; set; }
    }
}