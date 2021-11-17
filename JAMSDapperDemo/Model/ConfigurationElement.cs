using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;



namespace JAMSDapperDemo.Model
{
    [Table("ConfigurationElement")]
    public class ConfigurationElement
    {
        public ConfigurationElement()
        {
            ConfigurationElementProperties = new HashSet<ConfigurationElementProperty>();
        }

        [Key]
        public int TenantId { get; set; }
        [Key]
        public int ElementId { get; set; }
        public int ElementTypeId { get; set; }
        public Guid ElementUid { get; set; }
        [Required]
        [StringLength(256)]
        public string ElementName { get; set; }

        [InverseProperty(nameof(ConfigurationElementProperty.ConfigurationElement))]
        public ICollection<ConfigurationElementProperty> ConfigurationElementProperties { get; set; }
    }
}
