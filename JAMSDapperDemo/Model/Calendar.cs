using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;



namespace JAMSDapperDemo.Model
{
    [Table("Calendar")]
    public class Calendar
    {
        public Calendar()
        {
            LinkedDateTypeCalendarNavigations = new HashSet<LinkedDateType>();
            LinkedDateTypeCalendars = new HashSet<LinkedDateType>();
        }

        [Key]
        public int TenantId { get; set; }
        [Key]
        public int CalendarId { get; set; }
        [Required]
        [StringLength(256)]
        public string CalendarName { get; set; }
        public DateTime LastChange { get; set; }
        [Required]
        [StringLength(64)]
        public string LastChangedBy { get; set; }
        public byte[] Acl { get; set; }
        public string Description { get; set; }
        [StringLength(64)]
        public string ColorName { get; set; }

        [InverseProperty(nameof(LinkedDateType.CalendarNavigation))]
        public ICollection<LinkedDateType> LinkedDateTypeCalendarNavigations { get; set; }
        [InverseProperty(nameof(LinkedDateType.Calendar))]
        public ICollection<LinkedDateType> LinkedDateTypeCalendars { get; set; }
    }
}
