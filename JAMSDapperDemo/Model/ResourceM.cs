using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;



namespace JAMSDapperDemo.Model
{
    [Table("ResourceM")]
    [Index(nameof(TenantId), nameof(ResourceName), Name = "SK_ResourceM_Name", IsUnique = true)]
    public class ResourceM
    {
        [Key]
        public int TenantId { get; set; }
        [Key]
        public int ResourceId { get; set; }
        public DateTime LastChange { get; set; }
        [Required]
        [StringLength(64)]
        public string LastChangedBy { get; set; }
        [StringLength(256)]
        public string ResourceName { get; set; }
        public int? QtyAvailable { get; set; }
        public bool? AgentSpecific { get; set; }
        public string Description { get; set; }
        public byte[] Acl { get; set; }
    }
}
