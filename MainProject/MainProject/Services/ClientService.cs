using MainProject.DatabaseClient;
using MainProject.DTO;
using MainProject.Extensions.ClientExtensions;
using MainProject.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MainProject.Services
{
    public class ClientService : IClientService
    {
        private readonly IClientRepository _clientRepository;

        public ClientService(IClientRepository clientRepository)
        {
            _clientRepository = clientRepository;
        }

        public Task<int> CreateAsync(ClientDto client)
        {
            return _clientRepository.CreateAsync(client);
        }

        public Task DeleteAsync(int id)
        {
            return _clientRepository.DeleteAsync(id);
        }

        public Task<List<ClientDto>> GetAllAsync()
        {
            return _clientRepository.GetAllAsync();
        }

        public Task UpdateAsync(ClientDto client)
        {
            return _clientRepository.UpdateAsync(client);
        }
    }
}
