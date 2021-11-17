using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;



namespace JAMSDapperDemo.Model
{
    [Table("HistoryParam")]
    public class HistoryParam
    {
        [Key]
        public int TenantId { get; set; }
        public int JobId { get; set; }
        [Key]
        public long HistoryId { get; set; }
        [Key]
        public int ParamId { get; set; }
        [Required]
        [StringLength(256)]
        public string ParamName { get; set; }
        public byte? DataType { get; set; }
        public string ParamValue { get; set; }
        [StringLength(1024)]
        public string DefaultFormat { get; set; }
        public int Length { get; set; }
        public int? ParamOrigin { get; set; }
        public int? EncryptionId { get; set; }

        [ForeignKey("TenantId,JobId,HistoryId")]
        [InverseProperty("HistoryParams")]
        public History History { get; set; }
    }
}
