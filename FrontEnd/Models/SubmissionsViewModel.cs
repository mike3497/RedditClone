using Common.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FrontEnd.Models
{
    public class SubmissionsViewModel
    {
        public Submission Submission { get; set; }
        public Comment NewComment { get; set; }
        public IEnumerable<Comment> Comments { get; set; }
    }

    public class CreateSubmissionViewModel
    {
        public Submission Submission { get; set; }
        public SubmissionType Type { get; set; }
    }

    public class SearchSubmissionViewModel
    {
        public IEnumerable<SubmissionDetails> SearchResults { get; set; }
        public string SearchTerm { get; set; }
    }
}