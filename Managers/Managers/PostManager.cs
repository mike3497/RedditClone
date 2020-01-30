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

        public int GetNumberOfCommentsByPostId(int id)
        {
            return _postRepository.GetNumberOfCommentsByPostId(id);
        }

        public void Create(Post post)
        {
            post.TimeStamp = DateTime.Now;

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

        public IEnumerable<PostDetails> GetPostsWithDetails()
        {
            var posts = GetAll();

            List<PostDetails> list = new List<PostDetails>();

            foreach(var item in posts)
            {
                var postDetails = new PostDetails
                {
                    Post = item,
                    NumComments = GetNumberOfCommentsByPostId(item.Id)
                };

                list.Add(postDetails);
            }

            return list;
        }
    }
}
