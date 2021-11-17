using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;



namespace JAMSDapperDemo.Model
{
    [Table("Tenant")]
    public class Tenant
    {
        public Tenant()
        {
            TenantProperties = new HashSet<TenantProperty>();
        }

        [Key]
        public int TenantId { get; set; }
        [Required]
        [StringLength(64)]
        public string TenantName { get; set; }
        public DateTime LastChange { get; set; }
        [Required]
        [StringLength(64)]
        public string LastChangedBy { get; set; }
        public byte[] Acl { get; set; }

        [InverseProperty(nameof(TenantProperty.Tenant))]
        public ICollection<TenantProperty> TenantProperties { get; set; }
    }
}
