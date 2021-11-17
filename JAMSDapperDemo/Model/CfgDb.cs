using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;



namespace JAMSDapperDemo.Model
{
    [Table("CfgDb")]
    public class CfgDb
    {
        public DateTime LastChange { get; set; }
        [Required]
        [StringLength(256)]
        public string LastChangeBy { get; set; }
        [Key]
        [StringLength(64)]
        public string CfgName { get; set; }
        public string Description { get; set; }
        public int? CfgInt { get; set; }
        public bool? CfgBool { get; set; }
        public int? CfgDelta { get; set; }
        public int? CfgTime { get; set; }
        public DateTime? CfgDatetime { get; set; }
        public string CfgString { get; set; }
        public byte[] CfgBinary { get; set; }
    }
}
