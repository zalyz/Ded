using MainProject.ControllerModels;
using MainProject.DTO;
using MainProject.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RestEase;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MainProject.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Produces("application/json")]
    public class ClientController : ControllerBase
    {
        private readonly IClientService _clientService;

        public ClientController(IClientService clientService)
        {
            _clientService = clientService;
        }

        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<ClientDto>), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _clientService.GetAllAsync());
        }

        [HttpGet("/api/client/{id}")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ClientDto), StatusCodes.Status200OK)]
        public async Task<IActionResult> Get([FromRoute]long id)
        {
            if (id <= 0)
            {
                return BadRequest();
            }

            return Ok(await _clientService.FindByIdAsync(id));
        }

        [HttpGet("/api/client/filter")]
        [ProducesResponseType(typeof(IEnumerable<ClientDto>), StatusCodes.Status200OK)]
        public async Task<IActionResult> Filter([FromQuery] string passportNumber, [FromQuery] string fullName)
        {
            var collection = await _clientService.GetAllAsync();
            if (passportNumber is not null)
            {
                collection = collection.Where(e => e.PassportNumber.Equals(passportNumber)).ToList();
            }

            if (fullName is not null)
            {
                collection = collection.Where(e => e.FullName.Equals(fullName)).ToList();
            }

            return Ok(collection);
        }

        [HttpPost]
        [ProducesResponseType(typeof(int), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Post([FromForm] ClientModel clientModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var client = new ClientDto
            {
                FullName = clientModel.FullName,
                PassportNumber = clientModel.PassportNumber,
            };
            try
            {
                var id = await _clientService.CreateAsync(client);
            }
            catch (ApiException ex)
            {
                return Ok();
            }
            return Ok();
        }

        [HttpPatch]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> Patch([FromForm] ClientUpdateModel clientModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var client = new ClientDto
            {
                Id = clientModel.Id,
                FullName = clientModel.FullName,
                PassportNumber = clientModel.PassportNumber,
            };
            await _clientService.UpdateAsync(client);
            return Ok();
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> Delete([FromRoute]long id)
        {
            if (id <= 0)
            {
                return BadRequest();
            }

            await _clientService.DeleteAsync(id);
            return Ok();
        }
    }
}
