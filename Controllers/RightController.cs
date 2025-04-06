using Microsoft.AspNetCore.Mvc;
using Robo.Models.Arm;
using Robo.Models.Hand;
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
    }
}
