using MainProject.DTO;
using RestEase;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace MainProject.DatabaseClient
{
    public interface IClientRepository
    {
        [Get("/client/all")]
        Task<List<ClientDto>> GetAllAsync(CancellationToken cancellationToken = default);

        [Get("/client/find/{id}")]
        Task<ClientDto> FindByIdAsync([Path] long id, CancellationToken cancellationToken = default);

        [Post("/client/save")]
        Task<long> CreateAsync([Body] HttpContent context, CancellationToken cancellationToken = default);

        [Put("/client/update")]
        Task UpdateAsync([Body] HttpContent context, CancellationToken cancellationToken = default);

        [Delete("/client/delete/{id}")]
        Task DeleteAsync([Path]long id, CancellationToken cancellationToken = default);
    }
}
