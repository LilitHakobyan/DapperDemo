using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;



namespace JAMSDapperDemo.Model
{
    [Table("EncryptedValue")]
    public class EncryptedValue
    {
        [Key]
        public int TenantId { get; set; }
        [Key]
        public int EncryptionId { get; set; }
        [Column("EncryptedValue")]
        public byte[] EncryptedValue1 { get; set; }
        public DateTime LastChange { get; set; }
        [Required]
        [StringLength(64)]
        public string LastChangedBy { get; set; }
    }
}
