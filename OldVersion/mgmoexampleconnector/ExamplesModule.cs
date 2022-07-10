using Autofac;
using mgmoexampleblo.RxjsExample;
using mgmoexampleinterface.Rxjs;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mgmoexampleconnector
{
    public class ExamplesModule : Module
    {
        private IConfiguration _configuration;

        public ExamplesModule(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<RxJsExample>().As<IRxJsExample>();
        }
    }
}
