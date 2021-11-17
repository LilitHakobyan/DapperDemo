﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;



namespace JAMSDapperDemo.Model
{
    [Table("FolderElementProperty")]
    public class FolderElementProperty
    {
        [Key]
        public int TenantId { get; set; }
        [Key]
        public int FolderId { get; set; }
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

        [ForeignKey("TenantId,FolderId,ElementId")]
        [InverseProperty("FolderElementProperties")]
        public FolderElement FolderElement { get; set; }
        [ForeignKey("TenantId,PropertyId")]
        [InverseProperty("FolderElementProperties")]
        public PropertyDefinition PropertyDefinition { get; set; }
    }
}
