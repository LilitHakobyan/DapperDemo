using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;



namespace JAMSDapperDemo.Model
{
    [Table("DateD")]
    public class DateD
    {
        public DateTime? LastChange { get; set; }
        [Key]
        public int TenantId { get; set; }
        [Key]
        public int CalendarId { get; set; }
        [Key]
        public int TypeId { get; set; }
        [Key]
        public DateTime StartDate { get; set; }
        [StringLength(256)]
        public string Specific { get; set; }
        public string Description { get; set; }
        public byte? Working { get; set; }
    }
}
