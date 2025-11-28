using Microsoft.AspNetCore.Mvc;
using ValeraAPI.services;
using ValeraAPI.DTOs;

namespace ValeraAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ValeraController : ControllerBase
    {
        private readonly IValeraService _valeraService;

        public ValeraController(IValeraService valeraService)
        {
            _valeraService = valeraService;
        }

        [HttpGet]
        public async Task<ActionResult<ValeraStateDTO>> GetState()
        {
            return Ok(await _valeraService.GetState());
        }

        [HttpPost("Action")]
        public async Task<ActionResult<ValeraStateDTO>> ExecuteAction([FromBody] ActionRequestDTO request)
        {
            try
            {
                var result = await _valeraService.ExecuteAction(request.Action);
                return Ok(result);
            }

            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }

            catch (InvalidOperationException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("reset")]
        public async Task<ActionResult<ValeraStateDTO>> Reset()
        {
            await _valeraService.Reset();
            return Ok(await _valeraService.GetState());
        }

    }
}