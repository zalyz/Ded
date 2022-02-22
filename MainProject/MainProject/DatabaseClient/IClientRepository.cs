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
        [Get("")]
        Task<List<ClientDto>> GetAllAsync(CancellationToken cancellationToken = default);

        [Get("")]
        Task<ClientDto> FindById([Path] long id, CancellationToken cancellationToken = default);

        [Post("")]
        Task<long> CreateAsync([Body] HttpContent context, CancellationToken cancellationToken = default);

        [Patch("")]
        Task UpdateAsync([Body] HttpContent context, CancellationToken cancellationToken = default);

        [Delete("/{id}")]
        Task DeleteAsync([Path]long id, CancellationToken cancellationToken = default);
    }
}
