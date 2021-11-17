using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;



namespace JAMSDapperDemo.Model
{
    [Table("AppMenuElement")]
    public class AppMenuElement
    {
        public AppMenuElement()
        {
            AppMenuElementProperties = new HashSet<AppMenuElementProperty>();
        }

        [Key]
        public int TenantId { get; set; }
        [Key]
        public int AppMenuId { get; set; }
        [Key]
        public int ElementId { get; set; }
        public int ElementTypeId { get; set; }
        public Guid ElementUid { get; set; }
        [Required]
        [StringLength(256)]
        public string ElementName { get; set; }

        [ForeignKey("TenantId,AppMenuId")]
        [InverseProperty("AppMenuElements")]
        public AppMenu AppMenu { get; set; }
        [InverseProperty(nameof(AppMenuElementProperty.AppMenuElement))]
        public ICollection<AppMenuElementProperty> AppMenuElementProperties { get; set; }
    }
}
