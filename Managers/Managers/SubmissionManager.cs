using Common;
using Common.Models;
using Common.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Managers.Managers
{
    public class SubmissionManager
    {
        private readonly ISubmissionRepository _submissionRepository;
        private readonly SubmissionVoteManager _submissionVoteManager;

        public SubmissionManager(ISubmissionRepository submissionRepository, SubmissionVoteManager submissionVoteManager)
        {
            _submissionRepository = submissionRepository;
            _submissionVoteManager = submissionVoteManager;
        }

        public IEnumerable<Submission> GetAll()
        {
            return _submissionRepository.GetAll();
        }

        public IEnumerable<SubmissionDetails> GetPaged(int page, int numPerPage, SortType sortType)
        {
            var list = _submissionRepository.GetPaged(page, numPerPage, sortType);
            List<SubmissionDetails> result = new List<SubmissionDetails>();

            foreach(var item in list)
            {
                SubmissionDetails submissionDetails = SubmissionToSubmissionDetails(item);

                result.Add(submissionDetails);
            }

            return result;
        }

        public int GetTotalCount()
        {
            return _submissionRepository.GetTotalCount();
        }

        public int GetNumberOfCommentsBySubmissionId(int id)
        {
            return _submissionRepository.GetNumberOfCommentsBySubmissionId(id);
        }

        #region CRUD
        public int Create(Submission submission)
        {
            submission.TimeStamp = DateTime.Now;

            _submissionRepository.Create(submission);
            _submissionRepository.SaveChanges();

            return submission.Id;
        }

        public Submission Read(int id)
        {
            return _submissionRepository.Read(id);
        }

        public void Update(Submission submission)
        {
            _submissionRepository.Update(submission);
            _submissionRepository.SaveChanges();
        }

        public void Delete(int id)
        {
            _submissionRepository.Delete(id);
            _submissionRepository.SaveChanges();
        }

        public bool Exists(int id)
        {
            return _submissionRepository.Exists(id);
        }
        #endregion

        public IEnumerable<SubmissionDetails> GetSubmissionsWithDetails()
        {
            var submissions = GetAll();

            List<SubmissionDetails> list = new List<SubmissionDetails>();

            foreach(var item in submissions)
            {
                var submissionDetails = SubmissionToSubmissionDetails(item);

                list.Add(submissionDetails);
            }

            return list;
        }

        public void UpVote(int id)
        {
            _submissionRepository.UpVote(id);
            _submissionRepository.SaveChanges();
        }

        public void DownVote(int id)
        {
            _submissionRepository.DownVote(id);
            _submissionRepository.SaveChanges();
        }

        public int GetScore(int id)
        {
            var submission = _submissionRepository.Read(id);

            return (submission.UpVotes - submission.DownVotes);
        }

        public IEnumerable<SubmissionDetails> Search(string searchTerm)
        {
            var search = _submissionRepository.Search(searchTerm);

            List<SubmissionDetails> list = new List<SubmissionDetails>();

            foreach(var item in search)
            {
                var submissionDetails = SubmissionToSubmissionDetails(item);

                list.Add(submissionDetails);
            }

            return list;
        }

        private SubmissionDetails SubmissionToSubmissionDetails(Submission submission)
        {
            // Get time
            TimeSpan time = (DateTime.Now - submission.TimeStamp);
            string submissionTime;

            if (time.Days < 1)
            {
                if (time.Hours < 1)
                {
                    submissionTime = String.Format("{0:0} {1} ago", time.TotalMinutes, "minute".Pluralize((int)time.TotalMinutes));
                }
                else
                {
                    submissionTime = String.Format("{0:0} {1} ago", time.TotalHours, "hour".Pluralize((int)time.TotalHours));
                }
            }
            else
            {
                submissionTime = String.Format("{0:0} {1} ago", time.TotalDays, "day".Pluralize((int)time.TotalDays));
            }

            var submissionDetails = new SubmissionDetails
            {
                Submission = submission,
                NumComments = GetNumberOfCommentsBySubmissionId(submission.Id),
                TimeSinceCreated = submissionTime
            };

            return submissionDetails;
        }
    }
}
