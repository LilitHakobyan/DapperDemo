using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;



namespace JAMSDapperDemo.Model
{
    [Table("Category")]
    public class Category
    {
        public Category()
        {
            PropertyDefinitions = new HashSet<PropertyDefinition>();
        }

        [Key]
        public int TenantId { get; set; }
        [Key]
        public int CategoryId { get; set; }
        [Required]
        [StringLength(256)]
        public string CategoryName { get; set; }
        public int SortOrder { get; set; }
        public string AddMenuText { get; set; }

        [InverseProperty(nameof(PropertyDefinition.Category))]
        public ICollection<PropertyDefinition> PropertyDefinitions { get; set; }
    }
}
