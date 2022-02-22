using MainProject.DTO;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MainProject.Interfaces
{
    public interface ITicketService
    {
        Task<List<TicketDto>> GetAllAsync();

        Task<TicketDto> FindByIdAsync(long id);

        Task<long> CreateAsync(TicketDto ticket);

        Task UpdateAsync(TicketDto ticket);

        Task DeleteAsync(long id);
    }
}
