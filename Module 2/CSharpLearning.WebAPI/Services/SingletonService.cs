using Microsoft.Extensions.DependencyInjection;
using System;

namespace CSharpLearning.WebAPI.Services
{
    public class SingletonService
    {
        private readonly IServiceScopeFactory _factory;

        public SingletonService(IServiceScopeFactory factory)
        {
            _factory = factory;
        }

        public void DoStuff()
        {
            using var scope = _factory.CreateScope();
            IServiceProvider provider = scope.ServiceProvider;
            IService service = provider.GetRequiredService<IService>();

            service.Write();
        }
    }
}
