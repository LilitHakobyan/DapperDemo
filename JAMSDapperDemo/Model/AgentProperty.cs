using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace JAMSDapperDemo.Model
{
    [Table("AgentProperty")]
    public class AgentProperty
    {
        [Key]
        public int TenantId { get; set; }
        [Key]
        public int AgentId { get; set; }
        [Key]
        public int PropertyId { get; set; }
        public string StringValue { get; set; }
        public int? IntValue { get; set; }
        public DateTime? DateTimeValue { get; set; }
        public Guid? GuidValue { get; set; }
        public int? ReferenceId { get; set; }
        public bool? ReferenceRelative { get; set; }

        [ForeignKey("TenantId,AgentId")]
        [InverseProperty("AgentProperties")]
        public Agent Agent { get; set; }
        [ForeignKey("TenantId,PropertyId")]
        [InverseProperty("AgentProperties")]
        public PropertyDefinition PropertyDefinition { get; set; }
    }
}
