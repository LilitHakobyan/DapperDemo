using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;



namespace JAMSDapperDemo.Model
{
    [Table("ResourceD")]
    public class ResourceD
    {
        [Key]
        public int TenantId { get; set; }
        [Key]
        public int ResourceId { get; set; }
        [Key]
        public int AgentId { get; set; }
        public int? QtyAvailable { get; set; }
    }
}
