using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;



namespace JAMSDapperDemo.Model
{
    [Table("ParamAT")]
    public class ParamAt
    {
        public ParamAt()
        {
            ParamPropertyAts = new HashSet<ParamPropertyAt>();
        }

        [Key]
        public int TenantId { get; set; }
        [Key]
        public int JobId { get; set; }
        [Key]
        public int ParamId { get; set; }
        [Key]
        public int Version { get; set; }
        public Guid ParamUid { get; set; }
        [Required]
        [StringLength(256)]
        public string ParamName { get; set; }
        public byte DataType { get; set; }
        public int Length { get; set; }
        public int? Override { get; set; }

        [ForeignKey("TenantId,JobId,Version")]
        [InverseProperty("ParamAts")]
        public JobAt JobAt { get; set; }
        [InverseProperty(nameof(ParamPropertyAt.ParamAt))]
        public ICollection<ParamPropertyAt> ParamPropertyAts { get; set; }
    }
}
