using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Models
{
    public class SubmissionVote
    {
        public int Id { get; set; }
        public VoteType Type { get; set; }
        public int SubmissionId { get; set; }
        public string UserName { get; set; }
        public string UserId { get; set; }
    }

    public enum VoteType
    {
        UpVote,
        DownVote,
        None
    }
}
