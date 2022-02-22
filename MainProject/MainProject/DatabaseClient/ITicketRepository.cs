using MainProject.DTO;
using RestEase;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace MainProject.DatabaseClient
{
    public interface ITicketRepository
    {
        [Get("/ticket/all")]
        Task<List<TicketDto>> GetAllAsync(CancellationToken cancellationToken = default);

        [Get("/ticket/find/{id}")]
        Task<TicketDto> FindByIdAsync([Path] long id, CancellationToken cancellationToken = default);

        [Post("/ticket/save")]
        Task<long> CreateAsync([Body] HttpContent context, CancellationToken cancellationToken = default);

        [Put("/ticket/update")]
        Task UpdateAsync([Body] HttpContent context, CancellationToken cancellationToken = default);

        [Delete("/ticket/delete/{id}")]
        Task DeleteAsync([Path] long id, CancellationToken cancellationToken = default);
    }
}
