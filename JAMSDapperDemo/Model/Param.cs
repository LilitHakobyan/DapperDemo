using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;



namespace JAMSDapperDemo.Model
{
    [Table("Param")]
    public class Param
    {
        public Param()
        {
            ParamProperties = new HashSet<ParamProperty>();
        }

        [Key]
        public int TenantId { get; set; }
        [Key]
        public int JobId { get; set; }
        [Key]
        public int ParamId { get; set; }
        public Guid ParamUid { get; set; }
        [Required]
        [StringLength(256)]
        public string ParamName { get; set; }
        public byte DataType { get; set; }
        public int Length { get; set; }
        public int? Override { get; set; }

        [ForeignKey("TenantId,JobId")]
        [InverseProperty("Params")]
        public Job Job { get; set; }
        [InverseProperty(nameof(ParamProperty.Param))]
        public ICollection<ParamProperty> ParamProperties { get; set; }
    }
}
