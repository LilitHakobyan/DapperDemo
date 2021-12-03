using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace JAMSDapperDemo.Model
{
    [Table("PropertyDefinition")]
    public class PropertyDefinition
    {
        public PropertyDefinition()
        {
            AgentProperties = new HashSet<AgentProperty>();
            AppMenuElementProperties = new HashSet<AppMenuElementProperty>();
            ConfigurationElementProperties = new HashSet<ConfigurationElementProperty>();
            EntryElementProperties = new HashSet<EntryElementProperty>();
            EntryProperties = new HashSet<EntryProperty>();
            FolderElementProperties = new HashSet<FolderElementProperty>();
            FolderElementPropertyAts = new HashSet<FolderElementPropertyAt>();
            FolderProperties = new HashSet<FolderProperty>();
            JobElementProperties = new HashSet<JobElementProperty>();
            JobElementPropertyAts = new HashSet<JobElementPropertyAt>();
            JobProperties = new HashSet<JobProperty>();
            JobPropertyAts = new HashSet<JobPropertyAt>();
            MethodJobProperties = new HashSet<MethodJobProperty>();
            MethodJobPropertyAts = new HashSet<MethodJobPropertyAt>();
            MethodProperties = new HashSet<MethodProperty>();
            MethodPropertyAts = new HashSet<MethodPropertyAt>();
            UserSettingElementProperties = new HashSet<UserSettingElementProperty>();
        }

        [Key]
        public int TenantId { get; set; }
        [Key]
        public int PropertyId { get; set; }
        public DateTime LastChange { get; set; }
        [Required]
        [StringLength(256)]
        public string PropertyName { get; set; }
        [Required]
        [StringLength(256)]
        public string DisplayName { get; set; }
        public int PropertyOf { get; set; }
        public int CategoryId { get; set; }
        public int ReferenceTo { get; set; }
        public int MergeOption { get; set; }
        public int SortOrder { get; set; }
        public int Options { get; set; }
        public bool WriteToEntry { get; set; }
        public bool WriteToHistory { get; set; }
        public bool Browsable { get; set; }
        public bool ReadOnly { get; set; }
        [Required]
        [StringLength(256)]
        public string TypeName { get; set; }
        [Column("TypeNameSSO")]
        [StringLength(256)]
        public string TypeNameSso { get; set; }
        [StringLength(256)]
        public string Editor { get; set; }
        public string Description { get; set; }
        public string ToolTip { get; set; }

        [ForeignKey("TenantId,CategoryId")]
        [InverseProperty("PropertyDefinitions")]
        public Category Category { get; set; }

        [InverseProperty("PropertyDefinition")]
        public TenantProperty TenantProperty { get; set; }

        [InverseProperty(nameof(AgentProperty.PropertyDefinition))]
        public ICollection<AgentProperty> AgentProperties { get; set; }

        [InverseProperty(nameof(AppMenuElementProperty.PropertyDefinition))]
        public ICollection<AppMenuElementProperty> AppMenuElementProperties { get; set; }

        [InverseProperty(nameof(ConfigurationElementProperty.PropertyDefinition))]
        public ICollection<ConfigurationElementProperty> ConfigurationElementProperties { get; set; }

        [InverseProperty(nameof(EntryElementProperty.PropertyDefinition))]
        public ICollection<EntryElementProperty> EntryElementProperties { get; set; }

        [InverseProperty(nameof(EntryProperty.PropertyDefinition))]
        public ICollection<EntryProperty> EntryProperties { get; set; }

        [InverseProperty(nameof(FolderElementProperty.PropertyDefinition))]
        public ICollection<FolderElementProperty> FolderElementProperties { get; set; }

        [InverseProperty(nameof(FolderElementPropertyAt.PropertyDefinition))]
        public ICollection<FolderElementPropertyAt> FolderElementPropertyAts { get; set; }

        [InverseProperty(nameof(FolderProperty.PropertyDefinition))]
        public ICollection<FolderProperty> FolderProperties { get; set; }

        [InverseProperty(nameof(JobElementProperty.PropertyDefinition))]
        public ICollection<JobElementProperty> JobElementProperties { get; set; }

        [InverseProperty(nameof(JobElementPropertyAt.PropertyDefinition))]
        public ICollection<JobElementPropertyAt> JobElementPropertyAts { get; set; }

        [InverseProperty(nameof(JobProperty.PropertyDefinition))]
        public ICollection<JobProperty> JobProperties { get; set; }

        [InverseProperty(nameof(JobPropertyAt.PropertyDefinition))]
        public ICollection<JobPropertyAt> JobPropertyAts { get; set; }

        [InverseProperty(nameof(MethodJobProperty.PropertyDefinition))]
        public ICollection<MethodJobProperty> MethodJobProperties { get; set; }

        [InverseProperty(nameof(MethodJobPropertyAt.PropertyDefinition))]
        public ICollection<MethodJobPropertyAt> MethodJobPropertyAts { get; set; }

        [InverseProperty(nameof(MethodProperty.PropertyDefinition))]
        public ICollection<MethodProperty> MethodProperties { get; set; }

        [InverseProperty(nameof(MethodPropertyAt.PropertyDefinition))]
        public ICollection<MethodPropertyAt> MethodPropertyAts { get; set; }

        [InverseProperty(nameof(UserSettingElementProperty.PropertyDefinition))]
        public ICollection<UserSettingElementProperty> UserSettingElementProperties { get; set; }
    }
}
