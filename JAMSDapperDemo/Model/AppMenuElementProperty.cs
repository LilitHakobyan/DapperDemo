using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;



namespace JAMSDapperDemo.Model
{
    [Table("AppMenuElementProperty")]
    public class AppMenuElementProperty
    {
        [Key]
        public int TenantId { get; set; }
        [Key]
        public int AppMenuId { get; set; }
        [Key]
        public int ElementId { get; set; }
        [Key]
        public int PropertyId { get; set; }
        public string StringValue { get; set; }
        public int? IntValue { get; set; }
        public DateTime? DateTimeValue { get; set; }
        public Guid? GuidValue { get; set; }
        public int? ReferenceId { get; set; }
        public bool? ReferenceRelative { get; set; }

        [ForeignKey("TenantId,AppMenuId,ElementId")]
        [InverseProperty("AppMenuElementProperties")]
        public AppMenuElement AppMenuElement { get; set; }
        [ForeignKey("TenantId,PropertyId")]
        [InverseProperty("AppMenuElementProperties")]
        public PropertyDefinition PropertyDefinition { get; set; }
    }
}
