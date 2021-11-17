using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;



namespace JAMSDapperDemo.Model
{
    public class LinkedDateType
    {
        [Key]
        public int TenantId { get; set; }
        [Key]
        public int CalendarId { get; set; }
        [Key]
        public int DateTypeId { get; set; }
        [Key]
        public int LinkedCalendarId { get; set; }
        [Key]
        public int LinkedDateTypeId { get; set; }

        [ForeignKey("TenantId,CalendarId")]
        [InverseProperty("LinkedDateTypeCalendars")]
        public Calendar Calendar { get; set; }
        [ForeignKey("TenantId,LinkedCalendarId")]
        [InverseProperty("LinkedDateTypeCalendarNavigations")]
        public Calendar CalendarNavigation { get; set; }
        [ForeignKey("TenantId,CalendarId,DateTypeId")]
        [InverseProperty("LinkedDateTypeDateMs")]
        public DateM DateM { get; set; }
        [ForeignKey("TenantId,LinkedCalendarId,LinkedDateTypeId")]
        [InverseProperty("LinkedDateTypeDateMNavigations")]
        public DateM DateMNavigation { get; set; }
    }
}
