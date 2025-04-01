using Microsoft.AspNetCore.Mvc;
using Robo.Models.Head;
using Robo.Services;

namespace Robo.Controllers
{
        [ApiController]
        [Route("api/[controller]")]
    public class HeadController : ControllerBase
    {
        private readonly HeadService _roboService;

        // Construtor para injeção de dependência
        public HeadController(HeadService roboService)
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
    }
}
