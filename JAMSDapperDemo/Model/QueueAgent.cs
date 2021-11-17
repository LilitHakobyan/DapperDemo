using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;



namespace JAMSDapperDemo.Model
{
    [Table("QueueAgent")]
    public class QueueAgent
    {
        [Key]
        public int QueueId { get; set; }
        [Key]
        public int AgentId { get; set; }
        [Key]
        public int TenantId { get; set; }
    }
}
