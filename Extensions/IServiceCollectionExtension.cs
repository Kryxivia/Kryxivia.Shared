using Kryxivia.Shared.Settings;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Text;

namespace Kryxivia.Domain.Extensions
{
    public static class IServiceCollectionExtension
    {
        public static IServiceCollection AddKryxSharedServices(this IServiceCollection services)
        {
            return services;
        }
    }
}
