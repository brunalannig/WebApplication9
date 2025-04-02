using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WebApplication9.Models;

namespace WebApplication9.Data
{
    public class WebApplication9Context : DbContext
    {
        public WebApplication9Context (DbContextOptions<WebApplication9Context> options)
            : base(options)
        {
        }

        public DbSet<WebApplication9.Models.EstadoCivil> EstadoCivil { get; set; } = default!;
        public DbSet<WebApplication9.Models.Pessoa> Pessoa { get; set; } = default!;
        public DbSet<WebApplication9.Models.Compra> Compra { get; set; } = default!;
    }
}
