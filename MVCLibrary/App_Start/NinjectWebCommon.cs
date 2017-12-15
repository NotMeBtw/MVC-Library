[assembly: WebActivatorEx.PreApplicationStartMethod(typeof(MVCLibrary.App_Start.NinjectWebCommon), "Start")]
[assembly: WebActivatorEx.ApplicationShutdownMethodAttribute(typeof(MVCLibrary.App_Start.NinjectWebCommon), "Stop")]

namespace MVCLibrary.App_Start
{
    using System;
    using System.Web;

    using Microsoft.Web.Infrastructure.DynamicModuleHelper;

    using Ninject;
    using Ninject.Web.Common;
    using System.Web.Http;
    using Ninject.Web.Common.WebHost;
    using Ninject.Web.WebApi;
    using MVCLibrary.Models;
    using MVCLibrary.IServices;
    using MVCLibrary.Services;
    using MVCLibrary.IRepository;
    using MVCLibrary.Repository;
    using MVCLibrary.Implementations.Services;
    using MVCLibrary.Abstract.IServices;

    public static class NinjectWebCommon
    {
        private static readonly Bootstrapper bootstrapper = new Bootstrapper();

        /// <summary>
        /// Starts the application
        /// </summary>
        public static void Start()
        {
            DynamicModuleUtility.RegisterModule(typeof(OnePerRequestHttpModule));
            DynamicModuleUtility.RegisterModule(typeof(NinjectHttpModule));
            bootstrapper.Initialize(CreateKernel);
        }

        /// <summary>
        /// Stops the application.
        /// </summary>
        public static void Stop()
        {
            bootstrapper.ShutDown();
        }

        private static IKernel CreateKernel()
        {
            var kernel = new StandardKernel();
            try
            {
                kernel.Bind<Func<IKernel>>().ToMethod(ctx => () => new Bootstrapper().Kernel);
                kernel.Bind<IHttpModule>().To<HttpApplicationInitializationHttpModule>();

                RegisterServices(kernel);
                GlobalConfiguration.Configuration.DependencyResolver = new NinjectDependencyResolver(kernel);
                return kernel;
            }
            catch
            {
                kernel.Dispose();
                throw;
            }
        }

        private static void RegisterServices(IKernel kernel)
        {

            kernel.Bind<MVCLIbraryContext>().ToSelf().InRequestScope();
            kernel.Bind<ILanguageService>().To<LanguageService>().InRequestScope();
            kernel.Bind<IAdminService>().To<AdminService>().InRequestScope();
            kernel.Bind<ICategoryRepository>().To<CategoryRepository>().InRequestScope();
            kernel.Bind<IBookRepository>().To<BookRepository>().InRequestScope();
            kernel.Bind<IBookService>().To<BookService>().InRequestScope();
            kernel.Bind<ICategoryService>().To<CategoryService>().InRequestScope();
            kernel.Bind<ICartService>().To<CartService>().InRequestScope();

        }
    }
}