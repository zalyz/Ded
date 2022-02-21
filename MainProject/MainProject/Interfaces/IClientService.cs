using MainProject.DTO;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MainProject.Interfaces
{
    public interface IClientService
    {
        Task<List<ClientDto>> GetAllAsync();

        Task<int> CreateAsync(ClientDto client);

        Task UpdateAsync(ClientDto client);

        Task DeleteAsync(int id);
    }
}
