using System.Reflection;
using Griz.BookList.Lib.Data;
using Griz.BookList.Lib.Models;
using Griz.Core.Data;

[assembly: WebActivator.PreApplicationStartMethod(typeof(Griz.BookList.Web.NinjectWebCommon), "Start")]
[assembly: WebActivator.ApplicationShutdownMethodAttribute(typeof(Griz.BookList.Web.NinjectWebCommon), "Stop")]

namespace Griz.BookList.Web
{
    using System;
    using System.Web;

    using Microsoft.Web.Infrastructure.DynamicModuleHelper;

    using Ninject;
    using Ninject.Web.Common;

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
        
        /// <summary>
        /// Creates the kernel that will manage your application.
        /// </summary>
        /// <returns>The created kernel.</returns>
        private static IKernel CreateKernel()
        {
            var kernel = new StandardKernel();
            kernel.Bind<Func<IKernel>>().ToMethod(ctx => () => new Bootstrapper().Kernel);
            kernel.Bind<IHttpModule>().To<HttpApplicationInitializationHttpModule>();
            
            RegisterServices(kernel);
            return kernel;
        }

        /// <summary>
        /// Load your modules or register your services here!
        /// </summary>
        /// <param name="kernel">The kernel.</param>
        private static void RegisterServices(IKernel kernel)
        {
					//kernel.Bind<IProfileService>().To<ProfileService>();
					//kernel.Bind<IReviewService>().To<ReviewService>();
					//kernel.Bind<IReviewYearService>().To<ReviewYearService>();
					//kernel.Bind<IAnnualScoreService>().To<AnnualScoreService>();
					//kernel.Bind<ICalculationScoreWeightService>().To<CalculationScoreWeightService>();

	        kernel.Bind<IBookRepository>().To<BookRepository>();
					kernel.Bind<IUserProfileRepository>().To<UserProfileRepository>();

					kernel.Load(Assembly.Load("Griz.Core"));
					kernel.Load(Assembly.Load("Griz.BookList.Lib"));
        }        
    }
}
