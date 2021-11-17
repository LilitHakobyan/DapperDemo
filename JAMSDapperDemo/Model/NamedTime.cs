using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;



namespace JAMSDapperDemo.Model
{
    [Keyless]
    [Table("NamedTime")]
    public class NamedTime
    {
        public DateTime? LastChange { get; set; }
        public DateTime? LastAutoAction { get; set; }
        [StringLength(256)]
        public string TimeName { get; set; }
        public int TimeId { get; set; }
        public int? StartTime { get; set; }
        public int? EndTime { get; set; }
        public bool? Enabled { get; set; }
        public string Description { get; set; }
        public bool? AutoEnable { get; set; }
        public bool? AutoDisable { get; set; }
        public int TenantId { get; set; }
    }
}
