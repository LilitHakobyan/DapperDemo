using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;



namespace JAMSDapperDemo.Model
{
    [Table("EntryProperty")]
    public class EntryProperty
    {
        [Key]
        public int TenantId { get; set; }
        [Key]
        [Column("JAMSEntry")]
        public int Jamsentry { get; set; }
        [Key]
        public int PropertyId { get; set; }
        public string StringValue { get; set; }
        public int? IntValue { get; set; }
        public DateTime? DateTimeValue { get; set; }
        public Guid? GuidValue { get; set; }
        public int? ReferenceId { get; set; }
        public bool? ReferenceRelative { get; set; }

        [ForeignKey("TenantId,Jamsentry")]
        [InverseProperty("EntryProperties")]
        public Entry Entry { get; set; }
        [ForeignKey("TenantId,PropertyId")]
        [InverseProperty("EntryProperties")]
        public PropertyDefinition PropertyDefinition { get; set; }
    }
}
