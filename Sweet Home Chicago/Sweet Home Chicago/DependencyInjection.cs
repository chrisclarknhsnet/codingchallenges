using Microsoft.Extensions.DependencyInjection;
using System;

namespace Sweet_Home_Chicago
{
    public class DependencyInjection
    {
        public static ServiceProvider Configure()
        {
            //setup our DI
            return new ServiceCollection()
                .AddSingleton<ILoader, Loader>()
                .AddSingleton<IRepository, Repository>()
                .BuildServiceProvider();
        }
    }
}
