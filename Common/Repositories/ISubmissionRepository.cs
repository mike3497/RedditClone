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
    }
}
