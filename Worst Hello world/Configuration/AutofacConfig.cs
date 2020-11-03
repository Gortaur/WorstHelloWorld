using Autofac;
using WorstHelloWorld.Core.Providers;
using WorstHelloWorld.Infrastructure.Repositories;
using WorstHelloWorld.Interface.Core.Providers;
using WorstHelloWorld.Interface.Infrastructure.Repositories;

namespace Worst_Hello_world.Configuration
{
    public static class AutofacConfig
    {
        public static IContainer Configure()
        {
            var builder = new ContainerBuilder();

            builder.RegisterType<HelloWorldCharactersProvider>().As<IHelloWorldCharactersProvider>();
            builder.RegisterType<HelloWorldProvider>().As<IHelloWorldProvider>();
            builder.RegisterType<DesiredNumbersRepository>().As<IDesiredNumbersRepository>();

            return builder.Build();
        }
       
    }
}
