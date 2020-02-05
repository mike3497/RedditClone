using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Models
{
    public class Submission
    {
        public int Id { get; set; }
        public SubmissionType Type { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public string UserId { get; set; }
        public string UserName { get; set; }
        public int UpVotes { get; set; }
        public int DownVotes { get; set; }
        public DateTime TimeStamp { get; set; }
    }

    public enum SubmissionType
    {
        Text,
        Link
    }
}
