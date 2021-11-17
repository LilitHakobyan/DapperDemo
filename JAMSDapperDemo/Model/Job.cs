using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;



namespace JAMSDapperDemo.Model
{
    [Table("Job")]
    public class Job
    {
        public Job()
        {
            JobAuditTrails = new HashSet<JobAuditTrail>();
            JobElements = new HashSet<JobElement>();
            JobProperties = new HashSet<JobProperty>();
            JobTags = new HashSet<JobTag>();
            Params = new HashSet<Param>();
        }

        public DateTime LastChange { get; set; }
        [Required]
        [StringLength(64)]
        public string LastChangedBy { get; set; }
        [Key]
        public int TenantId { get; set; }
        public int ParentFolderId { get; set; }
        [Key]
        public int JobId { get; set; }
        public int Version { get; set; }
        [Required]
        [StringLength(256)]
        public string JobName { get; set; }
        public int MethodId { get; set; }
        public DateTime? LastAutosubmit { get; set; }
        public DateTime? LastReset { get; set; }
        public DateTime? LastSuccess { get; set; }
        public DateTime? LastInfo { get; set; }
        public DateTime? LastWarning { get; set; }
        public DateTime? LastError { get; set; }
        public DateTime? LastFatal { get; set; }
        public int? AvgCount { get; set; }
        public int? AvgElapsed { get; set; }
        public int? AvgCpuTime { get; set; }
        public int? AvgPageFaults { get; set; }
        public int? AvgWorkingSetPeak { get; set; }
        [Column("AvgBufferedIOCount")]
        public int? AvgBufferedIocount { get; set; }
        [Column("AvgDirectIOCount")]
        public int? AvgDirectIocount { get; set; }
        public int? MinCount { get; set; }
        public int? MinElapsed { get; set; }
        public int? MinCpuTime { get; set; }
        public int? MinPageFaults { get; set; }
        public int? MinWorkingSetPeak { get; set; }
        [Column("MinBufferedIOCount")]
        public int? MinBufferedIocount { get; set; }
        [Column("MinDirectIOCount")]
        public int? MinDirectIocount { get; set; }
        public int? MaxCount { get; set; }
        public int? MaxElapsed { get; set; }
        public int? MaxCpuTime { get; set; }
        public int? MaxPageFaults { get; set; }
        public int? MaxWorkingSetPeak { get; set; }
        [Column("MaxBufferedIOCount")]
        public int? MaxBufferedIocount { get; set; }
        [Column("MaxDirectIOCount")]
        public int? MaxDirectIocount { get; set; }
        public string Description { get; set; }
        public byte[] Acl { get; set; }
        public string Source { get; set; }

        [ForeignKey("TenantId,ParentFolderId")]
        [InverseProperty("Jobs")]
        public Folder Folder { get; set; }
        [ForeignKey("TenantId,MethodId")]
        [InverseProperty("Jobs")]
        public Method Method { get; set; }
        [InverseProperty(nameof(JobAuditTrail.Job))]
        public ICollection<JobAuditTrail> JobAuditTrails { get; set; }
        [InverseProperty(nameof(JobElement.Job))]
        public ICollection<JobElement> JobElements { get; set; }
        [InverseProperty(nameof(JobProperty.Job))]
        public ICollection<JobProperty> JobProperties { get; set; }
        [InverseProperty(nameof(JobTag.Job))]
        public ICollection<JobTag> JobTags { get; set; }
        [InverseProperty(nameof(Param.Job))]
        public ICollection<Param> Params { get; set; }
    }
}
