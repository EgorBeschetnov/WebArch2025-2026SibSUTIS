using Microsoft.AspNetCore.Mvc;
using ValeraAPI.Services;
using ValeraAPI.DTOs;

namespace ValeraAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ValeraController : ControllerBase
    {
        private readonly IvaleraService _valeraService;

        public ValeraController(IValeraService valeraService)
        {
            _valeraService = valeraService;
        }

        [HttpGet]
        public ActionResult<ValeraStateDTO> GetState()
        {
            return Ok(_valeraService.GetState());
        }

        [HttpPost("Action")]
        public ActionResult<ValeraStateDTO> ExecuteAction([FromBody] ActionRequestDTO request)
        {
            try
            {
                var result = _valeraService.ExecuteAction(request.Action);
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
        public ActionResult<ValeraSteateDTO> Reset()
        {
            _valeraService.Reset();
            return Ok(_valeraService.GetState());
        }

    }
}