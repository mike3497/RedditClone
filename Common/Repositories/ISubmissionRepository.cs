using Common.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Repositories
{
    public interface ISubmissionRepository : ICrudRepository<Submission>, IDisposable
    {
        int GetNumberOfCommentsBySubmissionId(int id);
        IEnumerable<Submission> Search(string searchTerm);
        IEnumerable<Submission> GetPaged(int page, int numPerPage, SortType sortType);
        IEnumerable<Submission> GetSubmissionsByUserId(string userId);
        int GetTotalCount();
        void UpVote(int id);
        void DownVote(int id);
    }
}
