﻿using Evento.Infrastructure.Services;
using Microsoft.AspNetCore.Mvc;

namespace Kurs_Prog_ASP.NET.Controllers
{

    [Route("events/{eventId}/tickets")]
    public class TicketsController : ApiControllerBase
    {
        private readonly ITicketsService _ticketService;

        public TicketsController(ITicketsService ticketService)
        {
            _ticketService=ticketService;
        }

        [HttpGet("{ticketId}")]
        public async Task<IActionResult> Get(Guid eventId,Guid tricketId)
        {
            var ticket = await _ticketService.GetAsync(UserId,eventId,tricketId);
            if(ticket == null)
            {
                return NotFound();
            }
            return Json(ticket);
        }

        [HttpPost("purchase/{amount}")]
        public async Task<IActionResult> Post(Guid eventId, int amount)
        {
            await _ticketService.PurchaseAsync(UserId, eventId, amount);
         
            return NoContent();
        }

        [HttpDelete("cancel/{amount}")]
        public async Task<IActionResult> Delete(Guid eventId, int amount)
        {
            await _ticketService.CancelAsync(UserId, eventId, amount);

            return NoContent();
        }
    }
}
