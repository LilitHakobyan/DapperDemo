using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;



namespace JAMSDapperDemo.Model
{
    [Table("AuditTrail")]
    public class AuditTrail
    {
        public DateTime AuditTime { get; set; }
        [Key]
        public int TenantId { get; set; }
        [Key]
        public int AuditTrailId { get; set; }
        [Required]
        [StringLength(64)]
        public string Username { get; set; }
        [Required]
        public string Message { get; set; }
        public int ObjectType { get; set; }
        public int ObjectId { get; set; }
    }
}
