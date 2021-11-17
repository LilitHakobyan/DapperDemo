using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;



namespace JAMSDapperDemo.Model
{
    [Table("DateST")]
    public class DateSt
    {
        [Key]
        public int TenantId { get; set; }
        [Key]
        public int CalendarId { get; set; }
        [Key]
        public int DateId { get; set; }
        [Key]
        public int Sequence { get; set; }
        [Key]
        [StringLength(256)]
        public string SpecificType { get; set; }
    }
}
