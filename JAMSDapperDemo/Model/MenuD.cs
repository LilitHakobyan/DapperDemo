using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;



namespace JAMSDapperDemo.Model
{
    [Table("MenuD")]
    public class MenuD
    {
        [Key]
        public int TenantId { get; set; }
        [Key]
        public int MenuId { get; set; }
        [Key]
        public int Sequence { get; set; }
        public DateTime LastChange { get; set; }
        public bool IncludeFolders { get; set; }
        public bool IncludeJobs { get; set; }
        public bool IncludeMenus { get; set; }
        public int? FolderId { get; set; }
        [StringLength(256)]
        public string TheName { get; set; }

        [ForeignKey("TenantId,MenuId")]
        [InverseProperty("MenuDs")]
        public MenuM MenuM { get; set; }
    }
}
