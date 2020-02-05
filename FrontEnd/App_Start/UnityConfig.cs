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

            // Managers
            container.RegisterType<SubmissionManager, SubmissionManager>();
            container.RegisterType<CommentManager, CommentManager>();
            
            DependencyResolver.SetResolver(new UnityDependencyResolver(container));
        }
    }
}