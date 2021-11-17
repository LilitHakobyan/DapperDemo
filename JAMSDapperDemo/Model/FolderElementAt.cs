using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;



namespace JAMSDapperDemo.Model
{
    [Table("FolderElementAT")]
    public class FolderElementAt
    {
        public FolderElementAt()
        {
            FolderElementPropertyAts = new HashSet<FolderElementPropertyAt>();
        }

        [Key]
        public int TenantId { get; set; }
        [Key]
        public int FolderId { get; set; }
        [Key]
        public int ElementId { get; set; }
        [Key]
        public int Version { get; set; }
        public int ElementTypeId { get; set; }
        public Guid ElementUid { get; set; }
        [Required]
        [StringLength(256)]
        public string ElementName { get; set; }
        public int? Override { get; set; }

        [ForeignKey("TenantId,FolderId,Version")]
        [InverseProperty("FolderElementAts")]
        public FolderAt FolderAt { get; set; }
        [InverseProperty(nameof(FolderElementPropertyAt.FolderElementAt))]
        public ICollection<FolderElementPropertyAt> FolderElementPropertyAts { get; set; }
    }
}
