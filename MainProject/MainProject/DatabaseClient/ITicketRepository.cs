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
        [Get("")]
        Task<List<TicketDto>> GetAllAsync(CancellationToken cancellationToken = default);

        [Post("")]
        Task<int> CreateAsync([Body] HttpContent context, CancellationToken cancellationToken = default);

        [Patch("")]
        Task UpdateAsync([Body] HttpContent context, CancellationToken cancellationToken = default);

        [Delete("/{id}")]
        Task DeleteAsync([Path] int id, CancellationToken cancellationToken = default);
    }
}
