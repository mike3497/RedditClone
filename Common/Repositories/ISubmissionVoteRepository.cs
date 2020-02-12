using Common.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Repositories
{
    public interface ISubmissionVoteRepository : ICrudRepository<SubmissionVote>, IDisposable
    {
        void UpVote(int submissionId, string userId);
        void DownVote(int submissionId, string userId);
        int GetUpVotes(int submissionId);
        int GetDownVotes(int submissionId);
        bool HasUserVoted(int submissionId, string userId);
        VoteType GetUserVote(int submissionId, string userId);
    }
}
