using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;



namespace JAMSDapperDemo.Model
{
    [Table("EntryNumberInfo")]
    public class EntryNumberInfo
    {
        [Key]
        public int TenantId { get; set; }
        public long NextRon { get; set; }
        public int NextEntry { get; set; }
        public int WrapAfter { get; set; }
    }
}
