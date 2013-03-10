using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using Longsor.Data;
using Longsor.Data.Contracts;
using Ninject;

namespace Longsor.Api
{
    public class IocConfig
    {
        public static void RegisterIoc(HttpConfiguration config)
        {
            var kernel = new StandardKernel(); // Ninject IoC

            kernel.Bind<ILongsorUow>().To<ILongsorUow>();

            kernel.Bind<RepositoryFactories>().To<RepositoryFactories>().InSingletonScope();

            //kernel.Bind<IRepositoryProvider>().To<RepositoryProvider>();

            config.DependencyResolver = new NinjectDependencyResolver(kernel);
        }
    }
}