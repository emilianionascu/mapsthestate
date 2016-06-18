using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web.Http;
using System.Web.Mvc;
using MapTheState.Web.DataImport;
using MapTheState.Web.Repositories;
using Microsoft.Owin;
using Neo4jClient;
using Owin;
using SimpleInjector;
using SimpleInjector.Extensions.ExecutionContextScoping;
using SimpleInjector.Integration.Web.Mvc;

[assembly: OwinStartup(typeof(MapTheState.Web.Startup))]

namespace MapTheState.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);

            var container = new Container();
            container.Options.DefaultScopedLifestyle = new ExecutionContextScopeLifestyle();

            var url = ConfigurationManager.AppSettings["GraphDBUrl"];
            var user = ConfigurationManager.AppSettings["GraphDBUser"];
            var password = ConfigurationManager.AppSettings["GraphDBPassword"];

            container.RegisterSingleton(() => NeoServerConfiguration.GetConfiguration(new Uri(url), user, password));
            container.RegisterSingleton<IGraphClientFactory, GraphClientFactory>();
            container.Register<IExcelImporter, ExcelImporter>();
            container.Register<IInstitutionsRepository, InstitutionsRepository>();

            DependencyResolver.SetResolver(new SimpleInjectorDependencyResolver(container));

            app.Use(async (context, next) =>
            {
                using (container.BeginExecutionContextScope())
                {
                    await next();
                }
            });
        }
    }
}
