using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AislesAPI.Models
{
    public class AisleContext : DbContext
    {

        public AisleContext(DbContextOptions<AisleContext> options)
            : base(options)
        {
        }

        public DbSet<Aisle> Aisles { get; set; }
        public DbSet<AisleSection> AisleSections { get; set; }

        

    }
}
