using Microsoft.AspNetCore.Mvc;
using PruebaPromart.DTO.Request;
using PruebaPromart.DTO.Response;
using PruebaPromart.Entities.Complex;
using PruebaPromart.Services.Interfaces;

namespace PruebaPromart.API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ClientController : ControllerBase
    {
        private readonly IClientService _service;

        public ClientController(IClientService service)
        {
            _service = service;
        }
        [HttpGet]
        [ProducesResponseType(typeof(BaseResponseEntity<List<ClientInfo?>>), 200)]
        public async Task<IActionResult> GetAllClients()
        {
            var lst = await _service.GetClients();
            return Ok(lst); 
        }

        [HttpGet("{id:int}")]
        [ProducesResponseType(typeof(BaseResponseEntity<ClientInfo?>), 200)]
        [ProducesResponseType(typeof(BaseResponseEntity<ClientInfo?>), 404)]
        public async Task<IActionResult> GetClientById(int id)
        {
            var client = await _service.GetClientById(id);
            if (client == null) return NotFound(client);
            return Ok(client);
        }

        [HttpGet]
        [ProducesResponseType(typeof(BaseResponseEntity<List<ClientInfo?>>), 200)]
        public async Task<IActionResult> GetOlderClients()
        {
            var lst = await _service.GetOlderClients();
            return Ok(lst);
        }

        [HttpPost]
        [ProducesResponseType(typeof(BaseResponseEntity<int>), 201)]
        [ProducesResponseType(typeof(BaseResponseEntity<int>), 400)]
        public async Task<IActionResult> CreateClient(DtoClient request)
        {
            var client = await _service.Create(request);
            return Ok(client);
        }
    }
}
