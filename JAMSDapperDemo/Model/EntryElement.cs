using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;



namespace JAMSDapperDemo.Model
{
    [Table("EntryElement")]
    public class EntryElement
    {
        public EntryElement()
        {
            EntryElementProperties = new HashSet<EntryElementProperty>();
        }

        [Key]
        public int TenantId { get; set; }
        [Key]
        [Column("JAMSEntry")]
        public int Jamsentry { get; set; }
        [Key]
        public int ElementId { get; set; }
        public int ElementTypeId { get; set; }
        public Guid ElementUid { get; set; }
        [Required]
        [StringLength(256)]
        public string ElementName { get; set; }
        public int ElementState { get; set; }
        public bool WriteToHistory { get; set; }
        public Guid? OwnerUid { get; set; }

        [ForeignKey("TenantId,Jamsentry")]
        [InverseProperty("EntryElements")]
        public Entry Entry { get; set; }
        [InverseProperty(nameof(EntryElementProperty.EntryElement))]
        public ICollection<EntryElementProperty> EntryElementProperties { get; set; }
    }
}
