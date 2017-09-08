using System;
using System.Web;
using System.Web.Http;
using AccesoDatos;
using AccesoDatosImpl;
using LogicaNegocio;
using LogicaNegocioImpl;
using Microsoft.Web.Infrastructure.DynamicModuleHelper;
using Ninject;
using Ninject.Web.Common;
using Ninject.Web.WebApi;

[assembly: WebActivatorEx.PreApplicationStartMethod(typeof(inventarioApp.App_Start.NinjectWebCommon), "Start")]
[assembly: WebActivatorEx.ApplicationShutdownMethodAttribute(typeof(inventarioApp.App_Start.NinjectWebCommon), "Stop")]

namespace inventarioApp.App_Start
{

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

        /// <summary>
        /// Load your modules or register your services here!
        /// </summary>
        /// <param name="kernel">The kernel.</param>
        private static void RegisterServices(IKernel kernel)
        {
            kernel.Bind<IProveedorDao>().To<ProveedorDao>();
            kernel.Bind<IProductoDao>().To<ProductoDao>();
            kernel.Bind<IRemisionesEntradaDao>().To<RemisionesEntradaDao>();
            kernel.Bind<IAlmacenDao>().To<AlmacenDao>();

            kernel.Bind<IAdministrarProveedores>().To<AdministrarProveedores>();
            kernel.Bind<IAdministrarProductos>().To<AdministrarProductos>();
            kernel.Bind<IAdministrarRemisionesEntrada>().To<AdministrarRemisionesEntrada>();
            kernel.Bind<IAdministrarAlmacenes>().To<AdministrarAlmacenes>();
        }        
    }
}
