using MainProject.DatabaseClient;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using RestEase;

namespace MainProject.Extensions
{
    public static class RestEaseClients
    {
        public static void AddClients(this IServiceCollection services, IConfiguration configuration)
        {
            var databaseApiAddress = configuration["DatabaseApiAddress"];

            services.AddScoped(scope =>
            {
                var baseUrl = databaseApiAddress;
                return RestClient.For<ITicketRepository>(baseUrl);
            });

            services.AddScoped(scope =>
            {
                var baseUrl = databaseApiAddress;
                return RestClient.For<IClientRepository>(baseUrl);
            });
        }
    }
}
