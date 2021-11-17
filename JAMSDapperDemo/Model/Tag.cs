using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;



namespace JAMSDapperDemo.Model
{
    [Table("Tag")]
    public class Tag
    {
        public Tag()
        {
            EntryTags = new HashSet<EntryTag>();
            FolderTagAts = new HashSet<FolderTagAt>();
            FolderTags = new HashSet<FolderTag>();
            HistoryTags = new HashSet<HistoryTag>();
            JobTagAts = new HashSet<JobTagAt>();
            JobTags = new HashSet<JobTag>();
        }

        [Key]
        public int TenantId { get; set; }
        [Key]
        public int TagId { get; set; }
        [Required]
        [StringLength(256)]
        public string TagName { get; set; }

        [InverseProperty(nameof(EntryTag.T))]
        public ICollection<EntryTag> EntryTags { get; set; }
        [InverseProperty(nameof(FolderTagAt.T))]
        public ICollection<FolderTagAt> FolderTagAts { get; set; }
        [InverseProperty(nameof(FolderTag.T))]
        public ICollection<FolderTag> FolderTags { get; set; }
        [InverseProperty(nameof(HistoryTag.T))]
        public ICollection<HistoryTag> HistoryTags { get; set; }
        [InverseProperty(nameof(JobTagAt.T))]
        public ICollection<JobTagAt> JobTagAts { get; set; }
        [InverseProperty(nameof(JobTag.T))]
        public ICollection<JobTag> JobTags { get; set; }
    }
}
