using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace JAMSDapperDemo.Model
{
    [Table("Method")]
    public class Method
    {
        public Method()
        {
            Jobs = new HashSet<Job>();
            MethodJobProperties = new HashSet<MethodJobProperty>();
            MethodParams = new HashSet<MethodParam>();
            MethodProperties = new HashSet<MethodProperty>();
        }

        public DateTime LastChange { get; set; }
        [Required]
        [StringLength(64)]
        public string LastChangedBy { get; set; }
        [Key]
        public int TenantId { get; set; }
        [Key]
        public int MethodId { get; set; }
        public int Version { get; set; }
        [Required]
        [StringLength(256)]
        public string MethodName { get; set; }
        public int ElementTypeId { get; set; }
        public string Description { get; set; }
        public string Template { get; set; }

        [ForeignKey("TenantId,ElementTypeId")]
        [InverseProperty("Methods")]
        public ElementType ElementType { get; set; }
        [InverseProperty(nameof(Job.Method))]
        public ICollection<Job> Jobs { get; set; }
        [InverseProperty(nameof(MethodJobProperty.Method))]
        public ICollection<MethodJobProperty> MethodJobProperties { get; set; }
        [InverseProperty(nameof(MethodParam.Method))]
        public ICollection<MethodParam> MethodParams { get; set; }
        [InverseProperty(nameof(MethodProperty.Method))]
        public ICollection<MethodProperty> MethodProperties { get; set; }
    }
}
