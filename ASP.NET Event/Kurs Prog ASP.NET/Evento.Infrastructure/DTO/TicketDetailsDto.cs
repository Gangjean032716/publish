﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Evento.Infrastructure.DTO
{
    public  class TicketDetailsDto : TicketsDto
    {
        public Guid EventId { get; set; }
        public string EventName { get; set; }
    }
}
