using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AislesApi.Models
{
    public class AislesContext : DbContext
    {
        public AislesContext(DbContextOptions<AislesContext> options)
            : base(options)
        {
        }

        public DbSet<Aisle> Aisles { get; set; }
        public DbSet<Item> Items { get; set; }
    }
}
