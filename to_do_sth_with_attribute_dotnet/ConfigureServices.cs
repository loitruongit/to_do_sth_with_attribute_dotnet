using to_do_sth_with_attribute_dotnet.ActionFilters;
using to_do_sth_with_attribute_dotnet.AuthorizationFilters;

namespace to_do_sth_with_attribute_dotnet
{
    public static class ConfigureServices
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            services.AddTransient<CheckHeaderForActionFilter>();
            services.AddTransient<DenyAllAuthorizationAttribute>();

            return services;
        }
    }
}
