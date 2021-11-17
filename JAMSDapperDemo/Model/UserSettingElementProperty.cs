using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;



namespace JAMSDapperDemo.Model
{
    [Table("UserSettingElementProperty")]
    public class UserSettingElementProperty
    {
        [Key]
        public int TenantId { get; set; }
        [Key]
        [MaxLength(128)]
        public byte[] UniqueUserId { get; set; }
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

        [ForeignKey("TenantId,PropertyId")]
        [InverseProperty("UserSettingElementProperties")]
        public PropertyDefinition PropertyDefinition { get; set; }
        [ForeignKey("TenantId,UniqueUserId,ElementId")]
        [InverseProperty("UserSettingElementProperties")]
        public UserSettingElement UserSettingElement { get; set; }
    }
}
