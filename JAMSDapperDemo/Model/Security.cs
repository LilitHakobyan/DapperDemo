using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;



namespace JAMSDapperDemo.Model
{
    [Table("Security")]
    public class Security
    {
        public DateTime? LastChange { get; set; }
        [Key]
        public int TenantId { get; set; }
        [Key]
        public int Type { get; set; }
        public byte[] Acl { get; set; }
    }
}
