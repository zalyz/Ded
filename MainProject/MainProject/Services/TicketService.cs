using MainProject.DatabaseClient;
using MainProject.DTO;
using MainProject.Extensions.ClientExtensions;
using MainProject.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MainProject.Services
{
    public class TicketService : ITicketService
    {
        private readonly ITicketRepository _ticketRepository;

        public TicketService(ITicketRepository ticketRepository)
        {
            _ticketRepository = ticketRepository;
        }

        public Task<long> CreateAsync(TicketDto ticket)
        {
            return _ticketRepository.CreateAsync(ticket);
        }

        public Task DeleteAsync(long id)
        {
            return _ticketRepository.DeleteAsync(id);
        }

        public Task<TicketDto> FindByIdAsync(long id)
        {
            return _ticketRepository.FindByIdAsync(id);
        }

        public Task<List<TicketDto>> GetAllAsync()
        {
            return _ticketRepository.GetAllAsync();
        }

        public Task UpdateAsync(TicketDto ticket)
        {
            return _ticketRepository.UpdateAsync(ticket);
        }
    }
}
