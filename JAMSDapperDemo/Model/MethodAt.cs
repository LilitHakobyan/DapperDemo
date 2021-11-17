using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;



namespace JAMSDapperDemo.Model
{
    [Table("MethodAT")]
    public class MethodAt
    {
        public MethodAt()
        {
            MethodJobPropertyAts = new HashSet<MethodJobPropertyAt>();
            MethodParamAts = new HashSet<MethodParamAt>();
            MethodPropertyAts = new HashSet<MethodPropertyAt>();
        }

        public DateTime? LastChange { get; set; }
        [Required]
        [StringLength(64)]
        public string LastChangedBy { get; set; }
        [Key]
        public int TenantId { get; set; }
        [Key]
        public int MethodId { get; set; }
        public int ElementTypeId { get; set; }
        [StringLength(256)]
        public string MethodName { get; set; }
        public string Description { get; set; }
        public string Template { get; set; }
        [Key]
        public int Version { get; set; }
        public string ChangeComment { get; set; }

        [InverseProperty(nameof(MethodJobPropertyAt.MethodAt))]
        public ICollection<MethodJobPropertyAt> MethodJobPropertyAts { get; set; }
        [InverseProperty(nameof(MethodParamAt.MethodAt))]
        public ICollection<MethodParamAt> MethodParamAts { get; set; }
        [InverseProperty(nameof(MethodPropertyAt.MethodAt))]
        public ICollection<MethodPropertyAt> MethodPropertyAts { get; set; }
    }
}
