using MainProject.DatabaseClient;
using MainProject.DTO;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace MainProject.Extensions.ClientExtensions
{
    public static class TicketRepositoryExtensions
    {
        public static Task<int> CreateAsync(this ITicketRepository ticketRepository, TicketDto ticket)
        {
            var form = GetHttpContent(ticket);
            return ticketRepository.CreateAsync(form);
        }

        public static Task UpdateAsync(this ITicketRepository ticketRepository, TicketDto ticket)
        {
            var form = GetHttpContent(ticket);
            return ticketRepository.UpdateAsync(form);
        }

        private static MultipartFormDataContent GetHttpContent(TicketDto ticket)
        {
            return new MultipartFormDataContent
            {
                ////new { new StringContent(), nameof() },
            };
        }
    }
}
