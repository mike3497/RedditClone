using Common.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Repositories
{
    public interface ICommentRepository : ICrudRepository<Comment>, IDisposable
    {
        IEnumerable<Comment> GetAllBySubmissionId(int id);
    }
}
