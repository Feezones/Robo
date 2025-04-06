using Microsoft.AspNetCore.Mvc;
using Robo.Models.Arm;
using Robo.Models.Hand;
using Robo.Models.Left;
using Robo.Services;

namespace Robo.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class LeftController : ControllerBase
    {
        private readonly LeftService _roboService;

        // Construtor para injeção de dependência
        public LeftController(LeftService roboService)
        {
            _roboService = roboService;
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

        // PUT: api/Robo/LeftPulse
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
