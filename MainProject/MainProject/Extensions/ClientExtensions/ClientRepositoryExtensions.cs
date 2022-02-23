using MainProject.DatabaseClient;
using MainProject.DTO;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace MainProject.Extensions.ClientExtensions
{
    public static class ClientRepositoryExtensions
    {
        public static Task<long> CreateAsync(this IClientRepository clientRepository, ClientDto client)
        {
            var form = GetHttpContent(client);
            return clientRepository.CreateAsync(form);
        }

        public static Task UpdateAsync(this IClientRepository clientRepository, ClientDto client)
        {
            var form = GetHttpContent(client);
            return clientRepository.UpdateAsync(form);
        }

        private static StringContent GetHttpContent(ClientDto client)
        {
            var form = new StringContent(JsonSerializer.Serialize(client));
            return form;
        }
    }
}
