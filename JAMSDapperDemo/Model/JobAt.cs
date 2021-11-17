using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;



namespace JAMSDapperDemo.Model
{
    [Table("JobAT")]
    public class JobAt
    {
        public JobAt()
        {
            JobElementAts = new HashSet<JobElementAt>();
            JobPropertyAts = new HashSet<JobPropertyAt>();
            JobTagAts = new HashSet<JobTagAt>();
            ParamAts = new HashSet<ParamAt>();
        }

        public DateTime AuditTime { get; set; }
        public DateTime LastChange { get; set; }
        [Required]
        [StringLength(64)]
        public string LastChangedBy { get; set; }
        [Key]
        public int TenantId { get; set; }
        public int ParentFolderId { get; set; }
        [Key]
        public int JobId { get; set; }
        [Key]
        public int Version { get; set; }
        [Required]
        [StringLength(256)]
        public string JobName { get; set; }
        public int MethodId { get; set; }
        public string Description { get; set; }
        public byte[] Acl { get; set; }
        public string Source { get; set; }
        public string ChangeComment { get; set; }

        [InverseProperty(nameof(JobElementAt.JobAt))]
        public ICollection<JobElementAt> JobElementAts { get; set; }
        [InverseProperty(nameof(JobPropertyAt.JobAt))]
        public ICollection<JobPropertyAt> JobPropertyAts { get; set; }
        [InverseProperty(nameof(JobTagAt.JobAt))]
        public ICollection<JobTagAt> JobTagAts { get; set; }
        [InverseProperty(nameof(ParamAt.JobAt))]
        public ICollection<ParamAt> ParamAts { get; set; }
    }
}
