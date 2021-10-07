﻿using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Uzytkownik
    {
        public string Login { get; set; }
        public string  Haslo { get; set; }
    }
    public class UzytkownikDBContext : DbContext
    {
        public DbSet<Uzytkownik> Ksiazka { get; set; }
    }
}
