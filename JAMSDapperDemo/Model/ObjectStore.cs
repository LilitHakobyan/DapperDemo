using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;



namespace JAMSDapperDemo.Model
{
    [Table("ObjectStore")]
    public class ObjectStore
    {
        [Key]
        [Column("JAMSEntry")]
        public int Jamsentry { get; set; }
        [Key]
        public Guid ObjectId { get; set; }
        public byte[] RawObject { get; set; }
        [Key]
        public int TenantId { get; set; }

        [ForeignKey("TenantId,Jamsentry")]
        [InverseProperty("ObjectStores")]
        public Entry Entry { get; set; }
    }
}
