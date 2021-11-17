using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;



namespace JAMSDapperDemo.Model
{
    [Table("DateM")]
    [Index(nameof(TenantId), nameof(Type), nameof(CalendarId), Name = "SK_DateM_Type", IsUnique = true)]
    public class DateM
    {
        public DateM()
        {
            LinkedDateTypeDateMNavigations = new HashSet<LinkedDateType>();
            LinkedDateTypeDateMs = new HashSet<LinkedDateType>();
        }

        public DateTime LastChange { get; set; }
        [Key]
        public int TenantId { get; set; }
        [Key]
        public int CalendarId { get; set; }
        [Key]
        public int DateId { get; set; }
        [StringLength(256)]
        public string Type { get; set; }
        public string Description { get; set; }
        public bool? Continuous { get; set; }

        [InverseProperty(nameof(LinkedDateType.DateMNavigation))]
        public ICollection<LinkedDateType> LinkedDateTypeDateMNavigations { get; set; }
        [InverseProperty(nameof(LinkedDateType.DateM))]
        public ICollection<LinkedDateType> LinkedDateTypeDateMs { get; set; }
    }
}
