using MalGen.Library.Services;

using Microsoft.Extensions.DependencyInjection;

namespace MalGen.app
{
    class Program
    {
        static void Main(string[] args)
        {
            var serviceCollection = new ServiceCollection();
            ConfigureServices(serviceCollection);

            var serviceProvider = serviceCollection.BuildServiceProvider();
            serviceProvider.GetService<App>().Run();
        }

        private static void ConfigureServices(IServiceCollection serviceCollection)
        {
            serviceCollection.AddSingleton(new ExceptionService());

            serviceCollection.AddTransient<App>();
        }
    }
}