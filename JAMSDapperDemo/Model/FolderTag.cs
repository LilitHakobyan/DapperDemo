using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;



namespace JAMSDapperDemo.Model
{
    [Table("FolderTag")]
    public class FolderTag
    {
        [Key]
        public int TenantId { get; set; }
        [Key]
        public int FolderId { get; set; }
        [Key]
        public int TagId { get; set; }

        [ForeignKey("TenantId,FolderId")]
        [InverseProperty("FolderTags")]
        public Folder Folder { get; set; }
        [ForeignKey("TenantId,TagId")]
        [InverseProperty(nameof(Tag.FolderTags))]
        public Tag T { get; set; }
    }
}
