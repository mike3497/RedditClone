using Common.Models;
using Common.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repositories
{
    public class SubmissionVoteRepository : ISubmissionVoteRepository
    {
        private readonly DBContext _connection;

        public SubmissionVoteRepository(DBContext connection)
        {
            _connection = connection;
        }

        public IEnumerable<SubmissionVote> GetAll()
        {
            return _connection.SubmissionVotes.ToList();
        }

        #region CRUD
        public void Create(SubmissionVote item)
        {
            _connection.SubmissionVotes.Add(item);
        }
        
        public SubmissionVote Read(int id)
        {
            return _connection.SubmissionVotes.Where(m => m.Id == id).SingleOrDefault();
        }

        public void Update(SubmissionVote item)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public bool Exists(int id)
        {
            throw new NotImplementedException();
        }
        #endregion

        public void UpVote(int submissionId, string userId)
        {
            var vote = new SubmissionVote
            {
                SubmissionId = submissionId,
                UserId = userId,
                Type = VoteType.UpVote
            };

            Create(vote);
        }

        public void DownVote(int submissionId, string userId)
        {
            var vote = new SubmissionVote
            {
                SubmissionId = submissionId,
                UserId = userId,
                Type = VoteType.DownVote
            };

            Create(vote);
        }

        public int GetUpVotes(int submissionId)
        {
            var upVotes = _connection.SubmissionVotes.Where(m => m.SubmissionId == submissionId)
                .Where(m => m.Type == VoteType.UpVote)
                .Select(m => m.Type)
                .Count();

            return upVotes;
        }

        public int GetDownVotes(int submissionId)
        {
            var downVotes = _connection.SubmissionVotes.Where(m => m.SubmissionId == submissionId)
                .Where(m => m.Type == VoteType.DownVote)
                .Select(m => m.Type)
                .Count();

            return downVotes;
        }

        public bool HasUserVoted(int submissionId, string userId)
        {
            var hasVoted = _connection.SubmissionVotes.Where(m => m.SubmissionId == submissionId)
                .Where(m => m.UserId == userId)
                .Any();
                
            return hasVoted;
        }

        public VoteType GetUserVote(int submissionId, string userId)
        {
            var vote = _connection.SubmissionVotes.Where(m => m.SubmissionId == submissionId)
                .Where(m => m.UserId == userId)
                .SingleOrDefault();

            return vote.Type;
        }

        public void SaveChanges()
        {
            _connection.SaveChanges();
        }

        public void Dispose()
        {
            _connection.Dispose();
        }
    }
}
