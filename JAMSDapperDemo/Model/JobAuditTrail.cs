using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;



namespace JAMSDapperDemo.Model
{
    [Table("JobAuditTrail")]
    public class JobAuditTrail
    {
        [Key]
        public int TenantId { get; set; }
        [Key]
        public int JobId { get; set; }
        [Key]
        public int AuditTrailId { get; set; }
        public DateTime AuditTime { get; set; }
        [Required]
        [StringLength(64)]
        public string UserName { get; set; }
        [Required]
        public string Message { get; set; }
        [Required]
        public string Comment { get; set; }
        public string Details { get; set; }

        [ForeignKey("TenantId,JobId")]
        [InverseProperty("JobAuditTrails")]
        public Job Job { get; set; }
    }
}
