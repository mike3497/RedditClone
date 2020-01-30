using Common.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Repositories
{
    public interface IPostRepository : ICrudRepository<Post>, IDisposable
    {
        int GetNumberOfCommentsByPostId(int id);
    }
}
