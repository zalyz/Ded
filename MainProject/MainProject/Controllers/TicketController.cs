using MainProject.ControllerModels;
using MainProject.DTO;
using MainProject.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MainProject.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Produces("application/json")]
    public class TicketController : ControllerBase
    {
        private readonly ITicketService _ticketService;

        public TicketController(ITicketService ticketService)
        {
            _ticketService = ticketService;
        }

        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<TicketDto>), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _ticketService.GetAllAsync());
        }

        [HttpGet("/api/ticket/{id}")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(TicketDto), StatusCodes.Status200OK)]
        public async Task<IActionResult> Get([FromRoute]long id)
        {
            if (id <= 0)
            {
                return BadRequest();
            }

            return Ok(await _ticketService.FindByIdAsync(id));
        }

        [HttpGet("/api/ticket/filter")]
        [ProducesResponseType(typeof(IEnumerable<TicketDto>), StatusCodes.Status200OK)]
        public async Task<IActionResult> Filter([FromQuery]long? flightNumber, [FromQuery] DateTime? departureDateTime)
        {
            var collection = await _ticketService.GetAllAsync();
            if (flightNumber.HasValue)
            {
                collection = collection.Where(e => e.FlightNumber == flightNumber.Value).ToList();
            }

            if (departureDateTime.HasValue)
            {
                collection = collection.Where(e => e.DepartureDate.Equals(departureDateTime.Value)).ToList();
            }

            return Ok(collection);
        }

        [HttpPost]
        [ProducesResponseType(typeof(int), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Post([FromForm]TicketModel ticketModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var ticket = new TicketDto
            {
                FlightNumber = ticketModel.FlightNumber,
                DepartureDate = ticketModel.DepartureDate,
                Price = ticketModel.Price,
                ClientId = ticketModel.ClientId,
            };
            var id = await _ticketService.CreateAsync(ticket);
            return Ok(id);
        }

        [HttpPatch]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Patch([FromForm] TicketUpdateModel ticketModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var ticket = new TicketDto
            {
                Id = ticketModel.Id,
                FlightNumber = ticketModel.FlightNumber,
                DepartureDate = ticketModel.DepartureDate,
                Price = ticketModel.Price,
                ClientId = ticketModel.ClientId,
            };
            await _ticketService.UpdateAsync(ticket);
            return Ok();
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Delete([FromRoute]long id)
        {
            if (id <= 0)
            {
                return BadRequest();
            }

            await _ticketService.DeleteAsync(id);
            return Ok();
        }
    }
}
