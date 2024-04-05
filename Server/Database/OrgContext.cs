using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Organizer.Shared.Models;

namespace Organizer.Server.Database
{
    public partial class OrgContext : DbContext
    {
        public DbSet<Printer> Printers { get; set; }
        public DbSet<Job> Jobs { get; set; }

        public OrgContext(DbContextOptions<OrgContext> options)
            : base(options) { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) { }
    }
}
