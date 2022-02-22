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

        [HttpGet("/{id}")]
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
            var id = await _clientService.CreateAsync(client);
            return Ok(id);
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

        [HttpDelete]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> Delete(long id)
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
