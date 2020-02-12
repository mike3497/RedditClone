using Common.Models;
using Common.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Managers.Managers
{
    public class SubmissionVoteManager
    {
        private readonly ISubmissionVoteRepository _submissionVoteRepository;

        public SubmissionVoteManager(ISubmissionVoteRepository submissionVoteRepository)
        {
            _submissionVoteRepository = submissionVoteRepository;
        }

        public void Create(SubmissionVote submissionVote)
        {
            _submissionVoteRepository.Create(submissionVote);
            _submissionVoteRepository.SaveChanges();
        }

        public void UpVote(int submissionId, string userId)
        {
            _submissionVoteRepository.UpVote(submissionId, userId);
            _submissionVoteRepository.SaveChanges();
        }

        public void DownVote(int submissionId, string userId)
        {
            _submissionVoteRepository.DownVote(submissionId, userId);
            _submissionVoteRepository.SaveChanges();
        }

        public int GetUpVotes(int submissionId)
        {
            return _submissionVoteRepository.GetUpVotes(submissionId);
        }

        public int GetDownVotes(int submissionId)
        {
            return _submissionVoteRepository.GetDownVotes(submissionId);
        }

        public bool HasUserVoted(int submissionId, string userId)
        {
            return _submissionVoteRepository.HasUserVoted(submissionId, userId);
        }

        public VoteType GetUserVote(int submissionId, string userId)
        {
            return _submissionVoteRepository.GetUserVote(submissionId, userId);
        }
    }
}
