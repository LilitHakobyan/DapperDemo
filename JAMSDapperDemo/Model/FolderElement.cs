using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;



namespace JAMSDapperDemo.Model
{
    [Table("FolderElement")]
    public class FolderElement
    {
        public FolderElement()
        {
            FolderElementProperties = new HashSet<FolderElementProperty>();
        }

        [Key]
        public int TenantId { get; set; }
        [Key]
        public int FolderId { get; set; }
        [Key]
        public int ElementId { get; set; }
        public int ElementTypeId { get; set; }
        public Guid ElementUid { get; set; }
        [Required]
        [StringLength(256)]
        public string ElementName { get; set; }
        public int ElementState { get; set; }
        public int? Override { get; set; }

        [ForeignKey("TenantId,FolderId")]
        [InverseProperty("FolderElements")]
        public Folder Folder { get; set; }
        [InverseProperty(nameof(FolderElementProperty.FolderElement))]
        public ICollection<FolderElementProperty> FolderElementProperties { get; set; }
    }
}
