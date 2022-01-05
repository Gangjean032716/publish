﻿using Evento.Infrastructure.Commands.Users;
using Evento.Infrastructure.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Kurs_Prog_ASP.NET.Controllers
{
    public class AccountController : Controller
    {
        private IUserService _userService;
        public AccountController(IUserService userService)
        {
            _userService= userService;
        }
        [HttpGet]
        [Authorize]
        public async Task<IActionResult> Get()
       =>Json(await _userService.GetAccountAsync());

        [HttpGet("tickets")]
        public async Task<IActionResult> GetTickets()
        {
            throw new NotImplementedException();
        }

        [HttpPost("register")]
        public async Task<IActionResult> Post(Register command)
        {
            await _userService.RegisterAsync(Guid.NewGuid(),
                command.Email, command.Name, command.Password, command.Role);
            return Created("/account", null);
        }

        [HttpPost("login")]
        public async Task<IActionResult> Post(Login command)
        => Json(await _userService.LoginAsync(command.Email, command.Password));
    }
}
