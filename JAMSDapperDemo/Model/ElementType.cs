using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace JAMSDapperDemo.Model
{
    [Table("ElementType")]
    public class ElementType
    {
        public ElementType()
        {
            ElementTypeProperties = new HashSet<ElementTypeProperty>();
            Methods = new HashSet<Method>();
        }

        [Key]
        public int TenantId { get; set; }
        [Key]
        public int ElementTypeId { get; set; }
        [Required]
        [StringLength(256)]
        public string ElementTypeName { get; set; }
        [Required]
        [StringLength(256)]
        public string DefinitionClassName { get; set; }
        [Required]
        [StringLength(256)]
        public string ImplementationClassName { get; set; }
        [Required]
        [StringLength(256)]
        public string ExecutionClassName { get; set; }
        [Required]
        [StringLength(256)]
        public string DisplayName { get; set; }
        public int CategoryId { get; set; }
        public int ElementKind { get; set; }
        public int ElementOf { get; set; }
        [Required]
        public string Description { get; set; }
        public bool WriteToEntry { get; set; }
        public bool WriteToHistory { get; set; }
        [StringLength(256)]
        public string ImageName { get; set; }
        [StringLength(256)]
        public string TabName { get; set; }
        public int? SortOrder { get; set; }
        public string FormatString { get; set; }
        public string AddMenuText { get; set; }
        [Column("ValidateTypeNameSSO")]
        [StringLength(256)]
        public string ValidateTypeNameSso { get; set; }

        [InverseProperty(nameof(ElementTypeProperty.ElementType))]
        public ICollection<ElementTypeProperty> ElementTypeProperties { get; set; }
        [InverseProperty(nameof(Method.ElementType))]
        public ICollection<Method> Methods { get; set; }
    }
}
