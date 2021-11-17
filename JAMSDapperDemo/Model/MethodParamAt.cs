using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;



namespace JAMSDapperDemo.Model
{
    [Table("MethodParamAT")]
    public class MethodParamAt
    {
        public MethodParamAt()
        {
            MethodParamPropertyAts = new HashSet<MethodParamPropertyAt>();
        }

        [Key]
        public int TenantId { get; set; }
        [Key]
        public int MethodId { get; set; }
        [Key]
        public int ParamId { get; set; }
        public Guid ParamUid { get; set; }
        [Required]
        [StringLength(256)]
        public string ParamName { get; set; }
        public byte DataType { get; set; }
        public int Length { get; set; }
        [Key]
        public int Version { get; set; }

        [ForeignKey("TenantId,MethodId,Version")]
        [InverseProperty("MethodParamAts")]
        public MethodAt MethodAt { get; set; }
        [InverseProperty(nameof(MethodParamPropertyAt.MethodParamAt))]
        public ICollection<MethodParamPropertyAt> MethodParamPropertyAts { get; set; }
    }
}
