using Common.Models;
using Common.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Managers.Managers
{
    public class PostManager
    {
        private readonly IPostRepository _postRepository;

        public PostManager(IPostRepository postRepository)
        {
            _postRepository = postRepository;
        }

        public IEnumerable<Post> GetAll()
        {
            return _postRepository.GetAll();
        }

        public void Create(Post post)
        {
            _postRepository.Create(post);
            _postRepository.SaveChanges();
        }

        public Post Read(int id)
        {
            return _postRepository.Read(id);
        }

        public void Update(Post post)
        {
            _postRepository.Update(post);
            _postRepository.SaveChanges();
        }

        public void Delete(int id)
        {
            _postRepository.Delete(id);
            _postRepository.SaveChanges();
        }

        public bool Exists(int id)
        {
            return _postRepository.Exists(id);
        }
    }
}
