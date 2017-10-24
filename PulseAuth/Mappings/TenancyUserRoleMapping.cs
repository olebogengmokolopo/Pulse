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
    internal class TenancyUserRoleMapping
    {
        public static void Map(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TenancyUserRole>()
                .HasKey(u => new { u.TenancyId, u.ApplicationUserId});

            modelBuilder.Entity<TenancyUserRole>()
                .HasRequired(u => u.ApplicationUser);

            modelBuilder.Entity<TenancyUserRole>()
                .HasRequired(u => u.Tenancy);

            modelBuilder.Entity<TenancyUserRole>()
                .HasRequired(u => u.Role);
        }
    }
}
