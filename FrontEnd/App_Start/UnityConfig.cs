using Common.Repositories;
using DataAccess.Repositories;
using FrontEnd.Controllers;
using Managers.Managers;
using System.Web.Mvc;
using Unity;
using Unity.Injection;
using Unity.Mvc5;

namespace FrontEnd
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
			var container = new UnityContainer();

            container.RegisterType<AccountController>(new InjectionConstructor());

            // Repositories
            container.RegisterType<ISubmissionRepository, SubmissionRepository>();
            container.RegisterType<ICommentRepository, CommentRepository>();
            container.RegisterType<ISubmissionVoteRepository, SubmissionVoteRepository>();

            // Managers
            container.RegisterType<SubmissionManager, SubmissionManager>();
            container.RegisterType<CommentManager, CommentManager>();
            container.RegisterType<SubmissionVoteManager, SubmissionVoteManager>();
            
            DependencyResolver.SetResolver(new UnityDependencyResolver(container));
        }
    }
}