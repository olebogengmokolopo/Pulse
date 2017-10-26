using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity.EntityFramework;
using Newtonsoft.Json;

namespace PulseAuth.Entities
{
    public class Tenancy
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]

        public int TenancyId { get; set; }

        [Required]
        [MaxLength(100)]
        public string TenancyName { get; set; }

        [MaxLength(512)]
        public string TenancyDescription { get; set; }

        [JsonIgnore]
        [ForeignKey("TenancyId")]
        public List<TenancyUserRole> TenancyUserRoles { get; set; } = new List<TenancyUserRole>();

        public Tenancy()
        {
            
        }
    }
}
