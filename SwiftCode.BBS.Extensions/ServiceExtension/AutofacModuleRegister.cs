using Autofac;
using SwiftCode.BBS.IServices;

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace SwiftCode.BBS.Extensions.ServiceExtension
{
   public  class AutofacModuleRegister : Autofac.Module
    {
        protected override void Load(ContainerBuilder builder)
        {
        // builder.RegisterType<ArticleServices>().As<IArticleService>();
            var basepath = AppContext.BaseDirectory;

            //var assemblysService = Assembly.Load("SwiftCode.BBS.Services");
            //builder.RegisterAssemblyTypes(assemblysService).AsImplementedInterfaces();
            //var assemblysRepository = Assembly.Load("SwiftCode.BBS.Repositories");
            //builder.RegisterAssemblyTypes(assemblysRepository).AsImplementedInterfaces();

            var serviceDllFile = Path.Combine(basepath, "SwiftCode.BBS.Services.dll");
            var repositoryDllFile = Path.Combine(basepath, "SwiftCode.BBS.Repositories.dll");
            if (!(File.Exists(serviceDllFile) && File.Exists(repositoryDllFile)))
            {

                var msg = "could not find service.dll and repository.dll";
                throw new Exception(msg);
            }

            var assmblysServices = Assembly.LoadFrom(serviceDllFile);
            builder.RegisterAssemblyTypes(assmblysServices).AsImplementedInterfaces();
            var assemblysRepository = Assembly.LoadFrom(repositoryDllFile);
            builder.RegisterAssemblyTypes(assemblysRepository).AsImplementedInterfaces();

        }
    }
}
