using MainProject.Interfaces;
using MainProject.Services;
using Microsoft.Extensions.DependencyInjection;

namespace MainProject.Extensions
{
    public static class RegisterServices
    {
        public static void AddServices(this IServiceCollection services)
        {
            services.AddScoped<ITicketService, TicketService>();
            services.AddScoped<IClientService, ClientService>();
        }
    }
}
