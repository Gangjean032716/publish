﻿using AutoMapper;
using Evento.Core.Domain;
using Evento.Infrastructure.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Evento.Infrastructure.Mappers
{
    public static class AutoMapperConfig
    {
        public static IMapper Initial() => new MapperConfiguration(cfg =>
        {
            cfg.CreateMap<Event, EventDto>()
            
            .ForMember(x => x.AvaliableTicketsCount, m => m.MapFrom(p => p.AveliableTrickets.Count()))
            .ForMember(x => x.PurchasedTicketCount, m => m.MapFrom(p => p.PurchatesTrickets.Count()))
            .ForMember(x => x.TicketsCount, m => m.MapFrom(p => p.Tickets.Count()));
            cfg.CreateMap<Event, EventDetailsDto>();
            cfg.CreateMap<Ticket,TicketsDto>();
            cfg.CreateMap<Ticket,TicketDetailsDto>();
            cfg.CreateMap<User, AccountDto>();
            
        }).CreateMapper();
            
    }
}
