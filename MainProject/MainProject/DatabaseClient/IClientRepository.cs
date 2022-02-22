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
        [Get("/all")]
        Task<List<ClientDto>> GetAllAsync(CancellationToken cancellationToken = default);

        [Get("/find/{id}")]
        Task<ClientDto> FindByIdAsync([Path] long id, CancellationToken cancellationToken = default);

        [Post("/save")]
        Task<long> CreateAsync([Body] HttpContent context, CancellationToken cancellationToken = default);

        [Patch("/update")]
        Task UpdateAsync([Body] HttpContent context, CancellationToken cancellationToken = default);

        [Delete("/delete/{id}")]
        Task DeleteAsync([Path]long id, CancellationToken cancellationToken = default);
    }
}
