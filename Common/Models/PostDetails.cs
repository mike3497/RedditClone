﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Models
{
    public class PostDetails
    {
        public Post Post { get; set; }
        public int NumComments { get; set; }
        public string TimeSinceCreated { get; set; }
    }
}