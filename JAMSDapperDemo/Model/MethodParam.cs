using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;



namespace JAMSDapperDemo.Model
{
    [Table("MethodParam")]
    public class MethodParam
    {
        public MethodParam()
        {
            MethodParamProperties = new HashSet<MethodParamProperty>();
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

        [ForeignKey("TenantId,MethodId")]
        [InverseProperty("MethodParams")]
        public Method Method { get; set; }
        [InverseProperty(nameof(MethodParamProperty.MethodParam))]
        public ICollection<MethodParamProperty> MethodParamProperties { get; set; }
    }
}
