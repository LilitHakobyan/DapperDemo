using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;



namespace JAMSDapperDemo.Model
{
    [Table("FolderAT")]
    public class FolderAt
    {
        public FolderAt()
        {
            FolderElementAts = new HashSet<FolderElementAt>();
            FolderParamAts = new HashSet<FolderParamAt>();
            FolderTagAts = new HashSet<FolderTagAt>();
        }

        public DateTime AuditTime { get; set; }
        public DateTime LastChange { get; set; }
        [Required]
        [StringLength(64)]
        public string LastChangedBy { get; set; }
        [Key]
        public int TenantId { get; set; }
        [Key]
        public int FolderId { get; set; }
        [Required]
        [StringLength(256)]
        public string FolderName { get; set; }
        [Key]
        public int Version { get; set; }
        public int? ParentFolderId { get; set; }
        public string Description { get; set; }
        public byte[] Acl { get; set; }
        public string ChangeComment { get; set; }

        [InverseProperty(nameof(FolderElementAt.FolderAt))]
        public ICollection<FolderElementAt> FolderElementAts { get; set; }
        [InverseProperty(nameof(FolderParamAt.FolderAt))]
        public ICollection<FolderParamAt> FolderParamAts { get; set; }
        [InverseProperty(nameof(FolderTagAt.FolderAt))]
        public ICollection<FolderTagAt> FolderTagAts { get; set; }
    }
}
