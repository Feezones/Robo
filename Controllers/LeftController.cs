using Microsoft.AspNetCore.Mvc;
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

        // PUT: api/Robo/LeftArm
        [HttpPut("LeftArm")]
        public IActionResult UpdateLeftArm(LeftArm leftArm)
        {
            if (leftArm == null)
            {
                return BadRequest();
            }

            var result = _roboService.UpdateLeftArm(leftArm);

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
