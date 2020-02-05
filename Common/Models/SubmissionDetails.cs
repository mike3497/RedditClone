using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Models
{
    public class SubmissionDetails
    {
        public Submission Submission { get; set; }
        public int NumComments { get; set; }
        public string TimeSinceCreated { get; set; }
    }
}