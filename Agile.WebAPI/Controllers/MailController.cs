using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Agile.Models.Mail;
using Agile.Services.Mail;
using Microsoft.AspNetCore.Mvc;

namespace Agile.WebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MailController : ControllerBase
    {
        private readonly IMailService _mailService;
        public MailController(IMailService mailService)
        {
            _mailService = mailService;
        }

        [HttpPost]
        public async Task<IActionResult> CreateMail([FromBody] MailCreate request)
        {
            if (!ModelState.IsValid)
            return BadRequest(ModelState);

            if (await _mailService.CreateMailAsync(request))
            return Ok("Mail created successfully.");

            return BadRequest();
        }

        [HttpGet]
        public async Task<IActionResult> GetAllMail()
        {
            return Ok();
        }

        [HttpGet("{mailId:int}")]
        public async Task<IActionResult> GetMailById([FromRoute] int mailId)
        {
            var detail = await _mailService.GetMailByIdAsync(mailId);
            return detail is not null
            ? Ok(detail)
            : NotFound();
        }
        
        [HttpPut]
        public async Task<IActionResult> UpdateMailById([FromBody] MailUpdate request)
        {
            if(!ModelState.IsValid)
            return BadRequest(ModelState);

            return await _mailService.UpdateMailAsync(request)
            ? Ok("Mail updated successfully.")
            : BadRequest("Mail could not be updated.");
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteMail([FromRoute] int mailId)
        {
            return await _mailService.DeleteMailAsync(mailId)
            ? Ok($"Mail {mailId} was deleted successfully.")
            : BadRequest($"Mail {mailId} could not be deleted.");
        }
    }
}