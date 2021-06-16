using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ParksApi.Data
{
    public class ParksDataContext : DbContext
    {
        public ParksDataContext(DbContextOptions<ParksDataContext> options): base(options)
        {

        }
      
        public virtual DbSet<MetroPark> MetroParks { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<MetroPark>().Property(p => p.Reservation).IsRequired();
            
        }
    }
}
