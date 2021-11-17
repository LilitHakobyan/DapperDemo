using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;



namespace JAMSDapperDemo.Model
{
    [Table("TimeZone")]
    public class TimeZone
    {
        [Key]
        public int TenantId { get; set; }
        [Key]
        public int TimeZoneId { get; set; }
        public int SortOrder { get; set; }
        public int UtcOffset { get; set; }
        [Required]
        [StringLength(32)]
        public string TimeZoneName { get; set; }
        [Required]
        [StringLength(64)]
        public string TimeZoneDisplayName { get; set; }
        [Required]
        [StringLength(4000)]
        public string TimeZoneSerialized { get; set; }
    }
}
