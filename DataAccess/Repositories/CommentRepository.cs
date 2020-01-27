using Common.Models;
using Common.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repositories
{
    public class CommentRepository : ICommentRepository
    {
        private readonly DBContext _connection;

        public CommentRepository(DBContext connection)
        {
            _connection = connection;
        }

        public IEnumerable<Comment> GetAll()
        {
            return _connection.Comments.ToList();
        }

        public IEnumerable<Comment> GetAllByPostId(int id)
        {
            return _connection.Comments.Where(m => m.PostId == id).ToList();
        }

        public void Create(Comment item)
        {
            _connection.Comments.Add(item);
        }

        public Comment Read(int id)
        {
            return _connection.Comments.SingleOrDefault(m => m.Id == id);
        }

        public void Update(Comment item)
        {
            var comment = _connection.Comments.SingleOrDefault(m => m.Id == item.Id);
            if (comment != null)
            {
                comment.Content = item.Content;
                comment.PostId = item.PostId;
                comment.UserId = item.UserId;
                comment.UserName = item.UserName;
                comment.UpVotes = item.UpVotes;
                comment.DownVotes = item.DownVotes;
            }
        }

        public void Delete(int id)
        {
            var comment = _connection.Comments.SingleOrDefault(m => m.Id == id);
            if (comment != null)
            {
                _connection.Comments.Remove(comment);
            }
        }

        public bool Exists(int id)
        {
            return _connection.Comments.Any(m => m.Id == id);
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
