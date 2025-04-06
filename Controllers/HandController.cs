using Microsoft.AspNetCore.Mvc;
using Robo.Models.Hand;
using Robo.Models.Left;
using Robo.Services;

namespace Robo.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class HandController : ControllerBase
    {
        private readonly HandService _roboService;

        // Construtor para injeção de dependência
        public HandController(HandService roboService)
        {
            _roboService = roboService;
        }

        // PUT: api/Hand/RightPulse
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

        // PUT: api/Hand/LeftPulse
        [HttpPut("LeftPulse")]
        public IActionResult UpdateLeftPulse(LeftPulse leftPulse)
        {
            if (leftPulse == null)
            {
                return BadRequest();
            }

            var result = _roboService.UpdateLeftPulse(leftPulse);

            if (result == 1)
                return Ok();

            return NotFound();
        }
    }
}
