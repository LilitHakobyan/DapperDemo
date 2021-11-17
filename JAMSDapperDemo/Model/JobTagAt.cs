using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;



namespace JAMSDapperDemo.Model
{
    [Table("JobTagAT")]
    public class JobTagAt
    {
        [Key]
        public int TenantId { get; set; }
        [Key]
        public int JobId { get; set; }
        [Key]
        public int Version { get; set; }
        [Key]
        public int TagId { get; set; }

        [ForeignKey("TenantId,JobId,Version")]
        [InverseProperty("JobTagAts")]
        public JobAt JobAt { get; set; }
        [ForeignKey("TenantId,TagId")]
        [InverseProperty(nameof(Tag.JobTagAts))]
        public Tag T { get; set; }
    }
}
