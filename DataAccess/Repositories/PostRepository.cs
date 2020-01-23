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
        
        public void Create(Post item)
        {
            _connection.Posts.Add(item);
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            _connection.Dispose();
        }

        public bool Exists(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Post> GetAll()
        {
            return _connection.Posts.ToList();
        }

        public Post Read(int id)
        {
            throw new NotImplementedException();
        }

        public void SaveChanges()
        {
            _connection.SaveChanges();
        }

        public void Update(Post item)
        {
            throw new NotImplementedException();
        }
    }
}
