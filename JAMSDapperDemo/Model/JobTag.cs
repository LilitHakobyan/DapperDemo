using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;



namespace JAMSDapperDemo.Model
{
    [Table("JobTag")]
    public class JobTag
    {
        [Key]
        public int TenantId { get; set; }
        [Key]
        public int JobId { get; set; }
        [Key]
        public int TagId { get; set; }

        [ForeignKey("TenantId,JobId")]
        [InverseProperty("JobTags")]
        public Job Job { get; set; }
        [ForeignKey("TenantId,TagId")]
        [InverseProperty(nameof(Tag.JobTags))]
        public Tag T { get; set; }
    }
}
