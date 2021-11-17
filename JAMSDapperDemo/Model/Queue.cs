using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;



namespace JAMSDapperDemo.Model
{
    [Table("Queue")]
    [Index(nameof(TenantId), nameof(QueueName), Name = "SK_Queue_Name", IsUnique = true)]
    public class Queue
    {
        public DateTime LastChange { get; set; }
        [Required]
        [StringLength(64)]
        public string LastChangedBy { get; set; }
        [Key]
        public int TenantId { get; set; }
        [Key]
        public int QueueId { get; set; }
        [Required]
        [StringLength(256)]
        public string QueueName { get; set; }
        public int JobLimit { get; set; }
        public bool Started { get; set; }
        public string Description { get; set; }
        public byte[] Acl { get; set; }
    }
}
