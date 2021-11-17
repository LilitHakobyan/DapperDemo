using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;



namespace JAMSDapperDemo.Model
{
    [Table("AppMenuUserPreference")]
    public class AppMenuUserPreference
    {
        [Key]
        public int TenantId { get; set; }
        [Key]
        [MaxLength(128)]
        public byte[] UniqueUserId { get; set; }
        [Key]
        public int AppMenuId { get; set; }
        public int Sequence { get; set; }
        public bool IsFavorite { get; set; }

        [ForeignKey("TenantId,AppMenuId")]
        [InverseProperty("AppMenuUserPreferences")]
        public AppMenu AppMenu { get; set; }
    }
}
