using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PulseAuth.Entities
{
    public class TenancyUserRole
    {
        [Key, Column(Order = 0)]
        public int ApplicationUserId { get; set; }

        [Key, Column(Order = 1)]
        public int TenancyId { get; set; }

        public virtual ApplicationUser ApplicationUser { get; set; }

        public virtual ApplicationRole Role { get; set; }
         
        public virtual Tenancy Tenancy { get; set; }

        public TenancyUserRole(Tenancy tenant, ApplicationUser user, ApplicationRole role)
        {
            ApplicationUserId = user.Id;
            TenancyId = tenant.TenancyId;
            ApplicationUser = user;
            Tenancy = tenant;
            Role = role;
        }
    }
}
