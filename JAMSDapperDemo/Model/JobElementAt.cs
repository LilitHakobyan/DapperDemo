using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;



namespace JAMSDapperDemo.Model
{
    [Table("JobElementAT")]
    public class JobElementAt
    {
        public JobElementAt()
        {
            JobElementPropertyAts = new HashSet<JobElementPropertyAt>();
        }

        [Key]
        public int TenantId { get; set; }
        [Key]
        public int JobId { get; set; }
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
        public Guid? OwnerUid { get; set; }

        [ForeignKey("TenantId,JobId,Version")]
        [InverseProperty("JobElementAts")]
        public JobAt JobAt { get; set; }
        [InverseProperty(nameof(JobElementPropertyAt.JobElementAt))]
        public ICollection<JobElementPropertyAt> JobElementPropertyAts { get; set; }
    }
}
