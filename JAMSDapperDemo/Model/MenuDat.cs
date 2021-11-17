using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;



namespace JAMSDapperDemo.Model
{
    [Table("MenuDAT")]
    public class MenuDat
    {
        public DateTime? LastChange { get; set; }
        [Key]
        public int MenuId { get; set; }
        [Key]
        public int Version { get; set; }
        [Key]
        public int Sequence { get; set; }
        public bool? IncludeFolders { get; set; }
        public bool? IncludeJobs { get; set; }
        public bool? IncludeSetups { get; set; }
        public bool? IncludeMenus { get; set; }
        public int? FolderId { get; set; }
        [StringLength(256)]
        public string TheName { get; set; }
        [Key]
        public int TenantId { get; set; }

        [ForeignKey("TenantId,MenuId,Version")]
        [InverseProperty("MenuDats")]
        public MenuMat MenuMat { get; set; }
    }
}
