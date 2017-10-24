using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity.EntityFramework;

namespace PulseAuth.Entities
{
    public class Tenancy
    {
        [Key]
        public int TenancyId { get; set; }

        [Required]
        [MaxLength(100)]
        public string TenancyName { get; set; }

        [MaxLength(512)]
        public string TenancyDescription { get; set; }

        [ForeignKey("TenancyId")]
        public virtual List<TenancyUserRole> TenancyUserRoles { get; set; }
    }
}
