﻿using AutoMapper;
using Evento.Core.Repositories;
using Evento.Infrastructure.DTO;
using Evento.Infrastructure.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Evento.Infrastructure.Services
{
    public class TicketsService : ITicketsService
    {
        private readonly IUserRepository _userRepository;
        private readonly IEventRepository _eventRepository;
        private readonly IMapper _mapper;

        public TicketsService(IUserRepository userRepository, IEventRepository eventRepository, IMapper mapper)
        {
            _userRepository=userRepository;
            _eventRepository=eventRepository;
            _mapper=mapper;
        }

      

        public async Task<TicketsDto> GetAsync(Guid userId, Guid eventId, Guid ticketId)
        {
            var user = await _userRepository.GetOrFailAsync(userId);
            var ticket = await _eventRepository.GetTicketOrFailAsync(eventId, ticketId);

            return _mapper.Map<TicketsDto>(ticket);
        }

        public async Task PurchaseAsync(Guid userId, Guid eventId, int amount)
        {
            var user = await _userRepository.GetOrFailAsync(userId);
            var @event = await _eventRepository.GetOrFailAsync(@eventId);
            @event.PurchatedTickets(user, amount);
            await _eventRepository.UpdateAsync(@event);
            
        }

        public async Task CancelAsync(Guid userId, Guid eventId, int amount)
        {
            var user = await _userRepository.GetOrFailAsync(userId);
            var @event = await _eventRepository.GetOrFailAsync(@eventId);
            @event.CancelPurchasedTickets(user, amount);
            await Task.CompletedTask;
        }
    }
}