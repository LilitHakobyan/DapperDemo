using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;



namespace JAMSDapperDemo.Model
{
    [Table("FolderParamAT")]
    public class FolderParamAt
    {
        [Key]
        public int TenantId { get; set; }
        [Key]
        public int FolderId { get; set; }
        [Key]
        public int ParamId { get; set; }
        public Guid ParamUid { get; set; }
        [Required]
        [StringLength(256)]
        public string ParamName { get; set; }
        public byte DataType { get; set; }
        public int Length { get; set; }
        [Key]
        public int Version { get; set; }
        public int? Override { get; set; }

        [ForeignKey("TenantId,FolderId,Version")]
        [InverseProperty("FolderParamAts")]
        public FolderAt FolderAt { get; set; }
    }
}
