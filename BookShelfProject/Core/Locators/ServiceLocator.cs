using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookShelfProject.Core.Locators
{
    public static class ServiceLocator
    {
        private static IServiceProvider _serviceProvider;

        public static void Initialize(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }
        public static T GetService<T>()
        {
            if (_serviceProvider == null) throw new InvalidOperationException("ServiceLocator has not been initialized.");

            return _serviceProvider.GetRequiredService<T>();
        }
    }
}
