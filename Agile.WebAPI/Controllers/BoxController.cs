using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Agile.Models.Box;
using Agile.Services.Box;
using Microsoft.AspNetCore.Mvc;

namespace Agile.WebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BoxController : ControllerBase
    {
        private readonly IBoxService _boxService;
        public BoxController(IBoxService boxService)
        {
            _boxService = boxService;
        }

        [HttpPost]
        public async Task<IActionResult> CreateBox([FromBody] BoxCreate request)
        {
            if (!ModelState.IsValid)
            return BadRequest(ModelState);

            if (await _boxService.CreateBoxAsync(request))
            return Ok("Mail created successfully.");

            return BadRequest();
        }

        [HttpGet]
        public async Task<IActionResult> GetAllBoxes()
        {
            return Ok();
        }

        [HttpGet("{boxId:int}")]
        public async Task<IActionResult> GetBoxById([FromRoute] int boxId)
        {
            var detail = await _boxService.GetBoxAsync(boxId);
            return detail is not null
            ? Ok(detail)
            : NotFound();
        }
    }
}