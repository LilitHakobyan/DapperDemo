using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;



namespace JAMSDapperDemo.Model
{
    [Table("ReportDesign")]
    public class ReportDesign
    {
        public DateTime LastChange { get; set; }
        [Required]
        [StringLength(64)]
        public string LastChangedBy { get; set; }
        public int ReportTypeId { get; set; }
        [Key]
        public int ReportDesignId { get; set; }
        public int ReportDatasource { get; set; }
        [Required]
        [StringLength(256)]
        public string ReportDesignName { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        [StringLength(16)]
        public string Version { get; set; }
        public byte[] ReportSource { get; set; }
        [Key]
        public int TenantId { get; set; }

        [ForeignKey("TenantId,ReportTypeId")]
        [InverseProperty("ReportDesigns")]
        public ReportType ReportType { get; set; }
    }
}
