using Common;
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
                TimeSpan time = (DateTime.Now - item.TimeStamp);
                string postTime;

                if (time.Days < 1)
                {
                    if (time.Hours < 1)
                    {
                        postTime = String.Format("{0:0} {1} ago", time.TotalMinutes, "minute".Pluralize((int)time.TotalMinutes));
                    }
                    else
                    {
                        postTime = String.Format("{0:0} {1} ago", time.TotalHours, "hour".Pluralize((int)time.TotalHours));
                    }
                }
                else
                {
                    postTime = String.Format("{0:0} {1} ago", time.TotalDays, "day".Pluralize((int)time.TotalDays));
                }

                var postDetails = new PostDetails
                {
                    Post = item,
                    NumComments = GetNumberOfCommentsByPostId(item.Id),
                    TimeSinceCreated = postTime
                };

                list.Add(postDetails);
            }

            return list;
        }

        public IEnumerable<Post> Search(string searchTerm)
        {
            var search = _postRepository.Search(searchTerm);

            return search;
        }
    }
}
