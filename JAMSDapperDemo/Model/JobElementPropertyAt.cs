using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;



namespace JAMSDapperDemo.Model
{
    [Table("JobElementPropertyAT")]
    public class JobElementPropertyAt
    {
        [Key]
        public int TenantId { get; set; }
        [Key]
        public int JobId { get; set; }
        [Key]
        public int ElementId { get; set; }
        [Key]
        public int PropertyId { get; set; }
        [Key]
        public int Version { get; set; }
        public string StringValue { get; set; }
        public int? IntValue { get; set; }
        public DateTime? DateTimeValue { get; set; }
        public Guid? GuidValue { get; set; }
        public int? ReferenceId { get; set; }
        public bool? ReferenceRelative { get; set; }
        public Guid? OwnerUid { get; set; }

        [ForeignKey("TenantId,JobId,Version,ElementId")]
        [InverseProperty("JobElementPropertyAts")]
        public JobElementAt JobElementAt { get; set; }
        [ForeignKey("TenantId,PropertyId")]
        [InverseProperty("JobElementPropertyAts")]
        public PropertyDefinition PropertyDefinition { get; set; }
    }
}
