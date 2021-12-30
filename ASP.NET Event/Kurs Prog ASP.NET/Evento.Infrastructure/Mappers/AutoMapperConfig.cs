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
            .ForMember(x=>x.TicketsCount,m=>m.MapFrom(p=>p.Trickets.Count()));
            
        }).CreateMapper();
            
    }
}