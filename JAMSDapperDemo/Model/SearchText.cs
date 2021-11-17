using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;



namespace JAMSDapperDemo.Model
{
    [Table("SearchText")]
    public class SearchText
    {
        [Key]
        public int SearchId { get; set; }
        public int TenantId { get; set; }
        public int ObjectId { get; set; }
        public int ObjectType { get; set; }
        public int? ParentFolderId { get; set; }
        [Required]
        [StringLength(256)]
        public string ObjectName { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        [Column("SearchText")]
        public string SearchText1 { get; set; }
        public string SearchSource { get; set; }
    }
}
