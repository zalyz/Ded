﻿using MainProject.DTO;
using RestEase;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace MainProject.DatabaseClient
{
    public interface ITicketRepository
    {
        [Get("/all")]
        Task<List<TicketDto>> GetAllAsync(CancellationToken cancellationToken = default);

        [Get("/find/{id}")]
        Task<TicketDto> FindByIdAsync([Path] long id, CancellationToken cancellationToken = default);

        [Post("/save")]
        Task<long> CreateAsync([Body] HttpContent context, CancellationToken cancellationToken = default);

        [Put("/update")]
        Task UpdateAsync([Body] HttpContent context, CancellationToken cancellationToken = default);

        [Delete("/delete/{id}")]
        Task DeleteAsync([Path] long id, CancellationToken cancellationToken = default);
    }
}