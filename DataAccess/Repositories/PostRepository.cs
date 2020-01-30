using Common.Models;
using Common.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repositories
{
    public class PostRepository : IPostRepository
    {
        private readonly DBContext _connection;

        public PostRepository(DBContext connection)
        {
            _connection = connection;
        }

        public IEnumerable<Post> GetAll()
        {
            return _connection.Posts.ToList();
        }

        public int GetNumberOfCommentsByPostId(int id)
        {
            return _connection.Comments.Where(m => m.PostId == id).Count();
        }

        #region CRUD
        public void Create(Post item)
        {
            _connection.Posts.Add(item);
        }

        public Post Read(int id)
        {
            return _connection.Posts.SingleOrDefault(m => m.Id == id);
        }

        public void Update(Post item)
        {
            var post = _connection.Posts.SingleOrDefault(m => m.Id == item.Id);
            if (post != null)
            {
                post.Title = item.Title;
                post.Content = item.Content;
                post.UserId = item.UserId;
                post.UserName = item.UserName;
                post.UpVotes = item.UpVotes;
                post.DownVotes = item.DownVotes;
            }
        }

        public void Delete(int id)
        {
            var post = _connection.Posts.SingleOrDefault(m => m.Id == id);
            if (post != null)
            {
                _connection.Posts.Remove(post);
            }
        }

        public bool Exists(int id)
        {
            return _connection.Posts.Any(m => m.Id == id);
        }
        #endregion

        public IEnumerable<Post> Search(string searchTerm)
        {
            string[] keywords = searchTerm.Split(' ');

            return _connection.Posts.Where(m => keywords.Any(n => m.Title.Contains(n))).ToList();
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
