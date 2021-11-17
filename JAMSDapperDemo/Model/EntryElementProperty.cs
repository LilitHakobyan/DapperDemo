using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;



namespace JAMSDapperDemo.Model
{
    [Table("EntryElementProperty")]
    public class EntryElementProperty
    {
        [Key]
        public int TenantId { get; set; }
        [Key]
        [Column("JAMSEntry")]
        public int Jamsentry { get; set; }
        [Key]
        public int ElementId { get; set; }
        [Key]
        public int PropertyId { get; set; }
        public string StringValue { get; set; }
        public int? IntValue { get; set; }
        public DateTime? DateTimeValue { get; set; }
        public Guid? GuidValue { get; set; }
        public int? ReferenceId { get; set; }
        public bool? ReferenceRelative { get; set; }
        public Guid? OwnerUid { get; set; }

        [ForeignKey("TenantId,Jamsentry,ElementId")]
        [InverseProperty("EntryElementProperties")]
        public EntryElement EntryElement { get; set; }
        [ForeignKey("TenantId,PropertyId")]
        [InverseProperty("EntryElementProperties")]
        public PropertyDefinition PropertyDefinition { get; set; }
    }
}
