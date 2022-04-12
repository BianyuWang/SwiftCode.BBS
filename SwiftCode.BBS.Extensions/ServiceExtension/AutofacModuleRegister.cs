using Autofac;
using SwiftCode.BBS.IRepositories.Base;
using SwiftCode.BBS.IServices.Base;
using SwiftCode.BBS.Repositories.Base;
using SwiftCode.BBS.Services.Base;
using System.Linq;
using System.Reflection;


namespace SwiftCode.BBS.Extensions.ServiceExtension
{
   public  class AutofacModuleRegister : Autofac.Module
    {
        protected override void Load(ContainerBuilder builder)
        {   //way one
            //   builder.RegisterType<ArticleServices>().As<IArticleService>();
            // var basepath = AppContext.BaseDirectory;
            //way two
            //var assemblysService = Assembly.Load("SwiftCode.BBS.Services");
            //builder.RegisterAssemblyTypes(assemblysService).AsImplementedInterfaces();
            //var assemblysRepository = Assembly.Load("SwiftCode.BBS.Repositories");
            //builder.RegisterAssemblyTypes(assemblysRepository).AsImplementedInterfaces();
            //way three
            //var serviceDllFile = Path.Combine(basepath, "SwiftCode.BBS.Services.dll");
            //var repositoryDllFile = Path.Combine(basepath, "SwiftCode.BBS.Repositories.dll");
            //if (!(File.Exists(serviceDllFile) && File.Exists(repositoryDllFile)))
            //{

            //    var msg = "could not find service.dll and repository.dll";
            //    throw new Exception(msg);
            //}

            //var assmblysServices = Assembly.LoadFrom(serviceDllFile);
            //builder.RegisterAssemblyTypes(assmblysServices).AsImplementedInterfaces();
            //var assemblysRepository = Assembly.LoadFrom(repositoryDllFile);
            //builder.RegisterAssemblyTypes(assemblysRepository).AsImplementedInterfaces();

            builder.RegisterGeneric(typeof(BaseRepository<>)).As(typeof(IBaseRepository<>)).InstancePerDependency();
            builder.RegisterGeneric(typeof(BaseServices<>)).As(typeof(IBaseServeces<>)).InstancePerDependency();

            var assemblysServices = Assembly.Load("SwiftCode.BBS.Services"); //important!!! not interface
            builder.RegisterAssemblyTypes(assemblysServices).AsImplementedInterfaces();



            var assemblysRepository = Assembly.Load("SwiftCode.BBS.Repositories");
            builder.RegisterAssemblyTypes(assemblysRepository)
                .AsImplementedInterfaces();

        }
    }
}
