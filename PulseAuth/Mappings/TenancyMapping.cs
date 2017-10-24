using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PulseAuth.Entities;

namespace PulseAuth.Mappings
{
    internal class TenancyMapping
    {
        public static void Map(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Tenancy>()
                .HasKey(u => u.TenancyId);

            modelBuilder.Entity<Tenancy>()
                .Property(u => u.TenancyId)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            modelBuilder.Entity<Tenancy>()
                .Property(u => u.TenancyName)
                .IsRequired();

            modelBuilder.Entity<Tenancy>()
                .Property(u => u.TenancyDescription)
                .IsOptional();
        }
    }
}
