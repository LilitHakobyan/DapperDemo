using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;



namespace JAMSDapperDemo.Model
{
    [Table("HistoryTag")]
    public class HistoryTag
    {
        [Key]
        public int TenantId { get; set; }
        public int JobId { get; set; }
        [Key]
        public long HistoryId { get; set; }
        [Key]
        public int TagId { get; set; }

        [ForeignKey("TenantId,JobId,HistoryId")]
        [InverseProperty("HistoryTags")]
        public History History { get; set; }
        [ForeignKey("TenantId,TagId")]
        [InverseProperty(nameof(Tag.HistoryTags))]
        public Tag T { get; set; }
    }
}
