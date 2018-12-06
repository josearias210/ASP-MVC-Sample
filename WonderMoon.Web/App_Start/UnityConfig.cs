using System.Web.Mvc;
using Unity;
using Unity.Mvc5;
using Wonder.Core.Interfaces;
using Wonder.Infrastructure.Repositories.EF;

namespace WonderMoon.Web
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
			var container = new UnityContainer();

            container.RegisterType<IRolRepository, RolRepository>();
            container.RegisterType<IUserRepository, UserRepository>();
            DependencyResolver.SetResolver(new UnityDependencyResolver(container));
        }
    }
}