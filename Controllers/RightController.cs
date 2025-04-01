using Microsoft.AspNetCore.Mvc;
using Robo.Models.Right;
using Robo.Services;

namespace Robo.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RightController : ControllerBase
    {
        private readonly RightService _roboService;

        // Construtor para injeção de dependência
        public RightController(RightService roboService)
        {
            _roboService = roboService;
        }

        // PUT: api/Robo/RightArm
        [HttpPut("RightArm")]
        public IActionResult UpdateRightArm(RightArm rightArm)
        {
            if (rightArm == null)
            {
                return BadRequest();
            }

            var result = _roboService.UpdateRightArm(rightArm);

            if (result == 1)
                return Ok();

            return NotFound();
        }

        // PUT: api/Robo/RightPulse
        [HttpPut("RightPulse")]
        public IActionResult UpdateRightPulse(RightPulse rightPulse)
        {
            if (rightPulse == null)
            {
                return BadRequest();
            }

            var result = _roboService.UpdateRightPulse(rightPulse);

            if (result == 1)
                return Ok();

            return NotFound();
        }
    }
}
