using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace PulseAuth.Entities
{
    public class TenancyUserRole
    {
        [Key]
        [Column(Order = 0)]
        [ForeignKey("ApplicationUser")]
        public int ApplicationUserId { get; set; }

        [Key]
        [Column(Order = 1)]
        [ForeignKey("Tenancy")]
        public int TenancyId { get; set; }

        [JsonIgnore]
        public virtual ApplicationUser ApplicationUser { get; set; }

        public virtual Tenancy Tenancy { get; set; }

        [Required]
        public virtual ApplicationRole Role { get; set; }

        public TenancyUserRole()
        {
            
        }

        public TenancyUserRole(Tenancy tenant, ApplicationUser user, ApplicationRole role)
        {
            ApplicationUserId = user.Id;
            TenancyId = tenant.TenancyId;
            ApplicationUser = user;
            Tenancy = tenant;
            Role = role;
            user.TenancyUserRoles.Add(this);
            tenant.TenancyUserRoles.Add(this);
        }
    }
}
