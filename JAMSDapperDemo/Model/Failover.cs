using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;



namespace JAMSDapperDemo.Model
{
    [Table("Failover")]
    public class Failover
    {
        [Key]
        public int IdKey { get; set; }
        public Guid DatabaseId { get; set; }
        public Guid CurrentId { get; set; }
        public DateTime LastSeen { get; set; }
        public Guid TakingId { get; set; }
        public DateTime TakingAt { get; set; }
    }
}
