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
        [Required]
        public SubmissionType Type { get; set; }
        [Required]
        public string Title { get; set; }
        public string URL { get; set; }
        public string Content { get; set; }
        [Required]
        public string UserId { get; set; }
        [Required]
        public string UserName { get; set; }
        public int UpVotes { get; set; }
        public int DownVotes { get; set; }
        [Required]
        public DateTime TimeStamp { get; set; }
    }

    public enum SubmissionType
    {
        Text,
        Link
    }

    public enum SortType
    {
        Date,
        Score
    }
}
