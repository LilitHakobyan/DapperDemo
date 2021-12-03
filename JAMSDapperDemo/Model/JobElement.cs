using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace JAMSDapperDemo.Model
{
    [Table("JobElement")]
    public class JobElement
    {
        public JobElement()
        {
            JobElementProperties = new HashSet<JobElementProperty>();
        }

        [Key]
        public int TenantId { get; set; }
        [Key]
        public int JobId { get; set; }
        [Key]
        public int ElementId { get; set; }
        public int ElementTypeId { get; set; }
        public Guid ElementUid { get; set; }
        [Required]
        [StringLength(256)]
        public string ElementName { get; set; }
        public int ElementState { get; set; }
        public int? Override { get; set; }
        public Guid? OwnerUid { get; set; }

        [ForeignKey("TenantId,JobId")]
        [InverseProperty("JobElements")]
        public Job Job { get; set; }
        [InverseProperty(nameof(JobElementProperty.JobElement))]
        public ICollection<JobElementProperty> JobElementProperties { get; set; }
    }
}
