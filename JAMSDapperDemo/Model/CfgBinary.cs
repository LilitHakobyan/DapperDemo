using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;



namespace JAMSDapperDemo.Model
{
    [Table("CfgBinary")]
    public class CfgBinary
    {
        [Key]
        public int TenantId { get; set; }
        [Key]
        [StringLength(256)]
        public string CfgName { get; set; }
        public DateTime LastChange { get; set; }
        [Required]
        [StringLength(256)]
        public string LastChangeBy { get; set; }
        public byte[] BinaryValue { get; set; }
    }
}
