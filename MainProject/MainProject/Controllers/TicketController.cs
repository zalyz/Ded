using MainProject.ControllerModels;
using MainProject.DTO;
using MainProject.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
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

        [HttpGet("/{id}")]
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

        [HttpDelete]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Delete(long id)
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
