﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;



namespace JAMSDapperDemo.Model
{
    [Table("MethodProperty")]
    public class MethodProperty
    {
        [Key]
        public int TenantId { get; set; }
        [Key]
        public int MethodId { get; set; }
        [Key]
        public int PropertyId { get; set; }
        public string StringValue { get; set; }
        public int? IntValue { get; set; }
        public DateTime? DateTimeValue { get; set; }
        public Guid? GuidValue { get; set; }
        public int? ReferenceId { get; set; }
        public bool? ReferenceRelative { get; set; }

        [ForeignKey("TenantId,MethodId")]
        [InverseProperty("MethodProperties")]
        public Method Method { get; set; }
        [ForeignKey("TenantId,PropertyId")]
        [InverseProperty("MethodProperties")]
        public PropertyDefinition PropertyDefinition { get; set; }
    }
}