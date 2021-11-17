using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;



namespace JAMSDapperDemo.Model
{
    [Table("WFTracking")]
    public class Wftracking
    {
        [Key]
        public int TenantId { get; set; }
        [Key]
        [Column("JAMSId")]
        public Guid Jamsid { get; set; }
        [Key]
        public int RestartCount { get; set; }
        [Key]
        public long RecordNumber { get; set; }
        public DateTime EventTime { get; set; }
        [Required]
        [StringLength(256)]
        public string ActivityId { get; set; }
        [Required]
        [StringLength(256)]
        public string ActivityName { get; set; }
        [Required]
        [StringLength(32)]
        public string ActivityState { get; set; }
        [StringLength(256)]
        public string BookmarkName { get; set; }
        public byte? BookmarkResponseType { get; set; }
        public string BookmarkResponseValues { get; set; }
        public byte? DisplayCategory { get; set; }
    }
}
