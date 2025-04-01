using Microsoft.AspNetCore.Mvc;
using Robo.Models.Head;
using Robo.Models.Left;
using Robo.Models.Right;
using Robo.Services;

namespace Robo.Controllers
{
        [ApiController]
        [Route("api/[controller]")]
    public class RoboController : ControllerBase
    {
        private readonly RoboService _roboService;

        // Construtor para injeção de dependência
        public RoboController(RoboService roboService)
        {
            _roboService = roboService;
        }

        // PUT: api/Robo/HeadRotation
        [HttpPut("HeadRotation")]
        public IActionResult UpdateHeadRotation(HeadRotation headRotation)
        {
            if (headRotation == null)
            {
                return BadRequest();
            }

            var result = _roboService.UpdateHeadRotation(headRotation);

            if (result == 1)
                return Ok();

            return NotFound();
        }

        // PUT: api/Robo/HeadTilt
        [HttpPut("HeadTilt")]
        public IActionResult UpdateHeadTilt(HeadTilt headTilt)
        {
            if (headTilt == null)
            {
                return BadRequest();
            }

            var result = _roboService.UpdateHeadTilt(headTilt);

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
