using Common.Models;
using Common.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repositories
{
    public class SubmissionRepository : ISubmissionRepository
    {
        private readonly DBContext _connection;

        public SubmissionRepository(DBContext connection)
        {
            _connection = connection;
        }

        public IEnumerable<Submission> GetAll()
        {
            return _connection.Submissions.ToList();
        }

        public IEnumerable<Submission> GetPaged(int page, int numPerPage, SortType sortType)
        {
            var list = _connection.Submissions.ToList();

            switch (sortType)
            {
                case SortType.Score:
                    // Implement
                    break;
                case SortType.Date:
                    list = list.OrderByDescending(m => m.TimeStamp).ToList();
                    break;
            }

            return list.Skip((page - 1) * numPerPage)
                .Take(numPerPage)
                .ToList();
        }

        public IEnumerable<Submission> GetSubmissionsByUserId(string userId)
        {
            return _connection.Submissions.Where(m => m.UserId == userId).ToList();
        }

        public int GetTotalCount()
        {
            return _connection.Submissions.Count();
        }

        public int GetNumberOfCommentsBySubmissionId(int id)
        {
            return _connection.Comments.Where(m => m.SubmissionId == id).Count();
        }

        #region CRUD
        public void Create(Submission item)
        {
            _connection.Submissions.Add(item);
        }

        public Submission Read(int id)
        {
            return _connection.Submissions.SingleOrDefault(m => m.Id == id);
        }

        public void Update(Submission item)
        {
            var submission = _connection.Submissions.SingleOrDefault(m => m.Id == item.Id);
            if (submission != null)
            {
                submission.Title = item.Title;
                submission.Content = item.Content;
                submission.UserId = item.UserId;
                submission.UserName = item.UserName;
                submission.UpVotes = item.UpVotes;
                submission.DownVotes = item.DownVotes;
            }
        }

        public void Delete(int id)
        {
            var submission = _connection.Submissions.SingleOrDefault(m => m.Id == id);
            if (submission != null)
            {
                _connection.Submissions.Remove(submission);
            }
        }

        public bool Exists(int id)
        {
            return _connection.Submissions.Any(m => m.Id == id);
        }
        #endregion

        public void UpVote(int id)
        {
            var submission = _connection.Submissions.Where(m => m.Id == id).SingleOrDefault();

            if (submission != null)
            {
                submission.UpVotes += 1;
            }
        }

        public void DownVote(int id)
        {
            var submission = _connection.Submissions.Where(m => m.Id == id).SingleOrDefault();

            if (submission != null)
            {
                submission.DownVotes += 1;
            }
        }

        public IEnumerable<Submission> Search(string searchTerm)
        {
            string[] keywords = searchTerm.Split(' ');

            return _connection.Submissions.Where(m => keywords.Any(n => m.Title.Contains(n))).ToList();
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
