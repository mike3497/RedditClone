using Common.Models;
using Common.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Managers.Managers
{
    public class CommentManager
    {
        private readonly ICommentRepository _commentRepository;

        public CommentManager(ICommentRepository commentRepository)
        {
            _commentRepository = commentRepository;
        }

        public IEnumerable<Comment> GetAllBySubmissionId(int id)
        {
            return _commentRepository.GetAllBySubmissionId(id);
        }

        public IEnumerable<Comment> GetAllTopLevelBySubmissionId(int id)
        {
            return _commentRepository.GetAllTopLevelBySubmissionId(id);
        }

        public void Create(Comment comment)
        {
            comment.TimeStamp = DateTime.Now;

            _commentRepository.Create(comment);
            _commentRepository.SaveChanges();
        }
    }
}
