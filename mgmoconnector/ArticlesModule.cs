using Autofac;
using mgmoarticleblo.Articles;
using mgmoarticledata;
using mgmoarticledata.Articles;
using mgmoarticontracts.Articles;
using mgmomain.Data;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;

namespace mgmoconnector
{
   public  class ArticlesModule : Module
    {
        private IConfiguration _configuration;

        public ArticlesModule(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        protected override void Load(ContainerBuilder builder)
        {
            // The generic ILogger<TCategoryName> service was added to the ServiceCollection by ASP.NET Core.
            // It was then registered with Autofac using the Populate method. All of this starts
            // with the `UseServiceProviderFactory(new AutofacServiceProviderFactory())` that happens in Program and registers Autofac
            // as the service provider.
            //builder.Register(c => new ValuesService(c.Resolve<ILogger<ValuesService>>()))
            //    .As<IValuesService>()
            //    .InstancePerLifetimeScope();
            var conString = _configuration.GetConnectionString("articles");

            var connectionInfo = new ConnectionInfo
            {
                ConnectionString = conString,
                Container = "articles"
            };
            builder.RegisterType<ArticleService>();
            builder.RegisterType<ArticleDataHandlers>().As<IArticleData>().WithParameter("connectionInfo", connectionInfo);
            builder.RegisterType<ArticleHandler>().As<IAricleHandler>();
        }
    }
}
