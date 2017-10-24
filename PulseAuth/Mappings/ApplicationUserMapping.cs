using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PulseAuth.Entities;

namespace PulseAuth.Mappings
{
    internal class ApplicationUserMapping
    {
        public static void Map(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ApplicationUser>()
                .HasMany(u => u.TenancyUserRoles);
        }
    }
}
