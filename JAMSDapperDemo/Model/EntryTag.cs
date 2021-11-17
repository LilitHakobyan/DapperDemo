using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;



namespace JAMSDapperDemo.Model
{
    [Table("EntryTag")]
    public class EntryTag
    {
        [Key]
        public int TenantId { get; set; }
        [Key]
        [Column("JAMSEntry")]
        public int Jamsentry { get; set; }
        [Key]
        public int TagId { get; set; }

        [ForeignKey("TenantId,Jamsentry")]
        [InverseProperty("EntryTags")]
        public Entry Entry { get; set; }
        [ForeignKey("TenantId,TagId")]
        [InverseProperty(nameof(Tag.EntryTags))]
        public Tag T { get; set; }
    }
}
