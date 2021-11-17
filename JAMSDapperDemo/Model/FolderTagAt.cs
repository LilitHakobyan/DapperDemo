using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;



namespace JAMSDapperDemo.Model
{
    [Table("FolderTagAT")]
    public class FolderTagAt
    {
        [Key]
        public int TenantId { get; set; }
        [Key]
        public int FolderId { get; set; }
        [Key]
        public int Version { get; set; }
        [Key]
        public int TagId { get; set; }

        [ForeignKey("TenantId,FolderId,Version")]
        [InverseProperty("FolderTagAts")]
        public FolderAt FolderAt { get; set; }
        [ForeignKey("TenantId,TagId")]
        [InverseProperty(nameof(Tag.FolderTagAts))]
        public Tag T { get; set; }
    }
}
