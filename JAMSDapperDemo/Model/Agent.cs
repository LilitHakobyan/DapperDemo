using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace JAMSDapperDemo.Model
{
    [Table("Agent")]
    [Index(nameof(TenantId), nameof(AgentName), Name = "SK_Agent_Name", IsUnique = true)]
    public class Agent
    {
        public Agent()
        {
            AgentProperties = new HashSet<AgentProperty>();
        }

        public DateTime LastChange { get; set; }
        [Required]
        [StringLength(64)]
        public string LastChangedBy { get; set; }
        [Key]
        public int TenantId { get; set; }
        [Key]
        public int AgentId { get; set; }
        [Required]
        [StringLength(256)]
        public string AgentName { get; set; }
        [Required]
        public string Description { get; set; }
        public int AgentElementTypeId { get; set; }
        public int PlatformElementTypeId { get; set; }
        public int JobLimit { get; set; }
        public bool Online { get; set; }
        public Guid AgentUid { get; set; }
        public byte[] Acl { get; set; }

        [InverseProperty(nameof(AgentProperty.Agent))]
        public ICollection<AgentProperty> AgentProperties { get; set; }
    }
}
