using AppCDS.Models;

using Microsoft.EntityFrameworkCore;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AppCDS.Data
{
    public class DiscosDBContext: DbContext
    {
        public DiscosDBContext(DbContextOptions<DiscosDBContext> options) : base(options) { }

        public DbSet<Disco> Disco { get; set; }
    }
}
