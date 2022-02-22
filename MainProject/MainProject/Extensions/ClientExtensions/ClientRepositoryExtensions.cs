using MainProject.DatabaseClient;
using MainProject.DTO;
using System.Net.Http;
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

        private static MultipartFormDataContent GetHttpContent(ClientDto client)
        {
            return new MultipartFormDataContent
            {
                ////new { new StringContent(), nameof() },
            };
        }
    }
}
