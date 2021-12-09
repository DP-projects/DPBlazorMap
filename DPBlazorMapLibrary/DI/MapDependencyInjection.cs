using DPBlazorMapLibrary.JsInterops.Events;
using DPBlazorMapLibrary.JsInterops.LeftletDefaultIconFactories;
using DPBlazorMapLibrary.JsInterops.Maps;
using Microsoft.Extensions.DependencyInjection;

namespace DPBlazorMapLibrary.DI
{
    public static class MapDependencyInjection
    {
        public static IServiceCollection AddMapService(this IServiceCollection services)
        {
            AddJsInterops(services);
            return services;
        }
        private static void AddJsInterops(IServiceCollection services)
        {
            services.AddTransient<IMapJsInterop, MapJsInterop>();
            services.AddTransient<IEventedJsInterop, EventedJsInterop>();
            services.AddTransient<IIconFactoryJsInterop, IconFactoryJsInterop>();
        }
    }
}
