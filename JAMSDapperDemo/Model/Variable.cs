using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;



namespace JAMSDapperDemo.Model
{
    [Table("Variable")]
    [Index(nameof(TenantId), nameof(FolderId), nameof(VariableName), Name = "SK_Variable_Name", IsUnique = true)]
    public class Variable
    {
        public DateTime LastChange { get; set; }
        [Required]
        [StringLength(256)]
        public string VariableName { get; set; }
        [Key]
        public int VariableId { get; set; }
        public int? DataType { get; set; }
        public string Description { get; set; }
        public byte[] Value { get; set; }
        public byte[] Acl { get; set; }
        [StringLength(64)]
        public string LastChangedBy { get; set; }
        public int FolderId { get; set; }
        [Key]
        public int TenantId { get; set; }
        public int? EncryptionId { get; set; }

        [ForeignKey("TenantId,FolderId")]
        [InverseProperty("Variables")]
        public Folder Folder { get; set; }
    }
}
