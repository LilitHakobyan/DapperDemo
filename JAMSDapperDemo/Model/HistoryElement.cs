using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;



namespace JAMSDapperDemo.Model
{
    [Table("HistoryElement")]
    public class HistoryElement
    {
        public HistoryElement()
        {
            HistoryElementProperties = new HashSet<HistoryElementProperty>();
        }

        [Key]
        public int TenantId { get; set; }
        public int JobId { get; set; }
        [Key]
        public long HistoryId { get; set; }
        [Key]
        public int ElementId { get; set; }
        public int ElementTypeId { get; set; }
        public Guid ElementUid { get; set; }
        [Required]
        [StringLength(256)]
        public string ElementName { get; set; }
        public int ElementState { get; set; }

        [ForeignKey("TenantId,JobId,HistoryId")]
        [InverseProperty("HistoryElements")]
        public History History { get; set; }
        [InverseProperty(nameof(HistoryElementProperty.HistoryElement))]
        public ICollection<HistoryElementProperty> HistoryElementProperties { get; set; }
    }
}
