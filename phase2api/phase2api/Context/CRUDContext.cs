using Microsoft.EntityFrameworkCore;
using phase2api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace phase2api.Context
{
    public class CRUDContext : DbContext
    {

        public CRUDContext(DbContextOptions<CRUDContext> options) : base(options)
        {

        }

        public DbSet<Diary> Diary { get; set; }
        public DbSet<Entry> Entry { get; set; }

    }
}
