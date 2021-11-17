using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;



namespace JAMSDapperDemo.Model
{
    [Table("ReportType")]
    public class ReportType
    {
        public ReportType()
        {
            ReportDesigns = new HashSet<ReportDesign>();
        }

        public DateTime LastChange { get; set; }
        [Required]
        [StringLength(64)]
        public string LastChangedBy { get; set; }
        [Key]
        public int ReportTypeId { get; set; }
        [Required]
        [StringLength(256)]
        public string ReportTypeName { get; set; }
        [Required]
        public string Description { get; set; }
        [Key]
        public int TenantId { get; set; }

        [InverseProperty(nameof(ReportDesign.ReportType))]
        public ICollection<ReportDesign> ReportDesigns { get; set; }
    }
}
