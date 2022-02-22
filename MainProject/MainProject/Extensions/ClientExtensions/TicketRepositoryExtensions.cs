using MainProject.DatabaseClient;
using MainProject.DTO;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace MainProject.Extensions.ClientExtensions
{
    public static class TicketRepositoryExtensions
    {
        public static Task<long> CreateAsync(this ITicketRepository ticketRepository, TicketDto ticket)
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
                { new StringContent(ticket.Id.ToString()), nameof(ticket.Id) },
                { new StringContent(ticket.FlightNumber.ToString()), nameof(ticket.FlightNumber) },
                { new StringContent(ticket.DepartureDate.ToString()), nameof(ticket.DepartureDate) },
                { new StringContent(ticket.ClientId.ToString()), nameof(ticket.ClientId) },
                { new StringContent(ticket.Price.ToString()), nameof(ticket.Price) },
            };
        }
    }
}
