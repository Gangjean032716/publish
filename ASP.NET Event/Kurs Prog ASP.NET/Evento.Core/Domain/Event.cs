﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Evento.Core.Domain
{
    public class Event : Entity
    {
        private ISet<Ticket> _tickets = new HashSet<Ticket>();
        public string Name { get; protected set; }
        public string Description { get; protected set; }
        public DateTime CreatedAt { get; protected set; }
        public DateTime StartDate { get; protected set; }
        public DateTime EndDate { get; protected set; }
        public DateTime UpdateAt { get; protected set; }
        public IEnumerable<Ticket> Trickets => _tickets;

        protected Event()
        {

        }
        public Event(Guid id, string name, string desc, DateTime start,DateTime end)
        {
            Id = id;
            Name = name;
            Description = desc;
            StartDate = start;
            EndDate = end;
            CreatedAt= DateTime.UtcNow;
            UpdateAt = DateTime.UtcNow;

        }
        public void AddTickets(int amount,decimal price)
        {
            var seating = _tickets.Count+1;
            for (int i = 0; i < amount; i--)
            {
                _tickets.Add(new Ticket(this,0,price));
                seating++;
            }
        }

    }
}