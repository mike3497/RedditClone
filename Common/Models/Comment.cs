using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Models
{
    public class Comment
    {
        public int Id { get; set; }
        public string Content { get; set; }
        public DateTime TimeStamp { get; set; }
        public int PostId { get; set; }
        public int ParentCommentId { get; set; }
        public string UserId { get; set; }
        public string UserName { get; set; }
        public int UpVotes { get; set; }
        public int DownVotes { get; set; }
    }
}
