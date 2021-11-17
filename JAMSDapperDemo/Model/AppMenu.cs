using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace JAMSDapperDemo.Model
{
    [Table("AppMenu")]
    public class AppMenu
    {
        public AppMenu()
        {
            AppMenuElements = new HashSet<AppMenuElement>();
            AppMenuUserPreferences = new HashSet<AppMenuUserPreference>();
        }

        [Key]
        public int TenantId { get; set; }
        [Key]
        public int AppMenuId { get; set; }
        public int? ParentAppMenuId { get; set; }
        [StringLength(64)]
        public string Label { get; set; }
        [StringLength(1024)]
        public string Title { get; set; }
        public string Description { get; set; }
        [StringLength(64)]
        public string Icon { get; set; }
        public int? ShowOn { get; set; }
        public int Sequence { get; set; }
        public bool IsFavorite { get; set; }
        public byte[] Acl { get; set; }
        [StringLength(1024)]
        public string PreferenceName { get; set; }

        [InverseProperty(nameof(AppMenuElement.AppMenu))]
        public ICollection<AppMenuElement> AppMenuElements { get; set; }
        [InverseProperty(nameof(AppMenuUserPreference.AppMenu))]
        public ICollection<AppMenuUserPreference> AppMenuUserPreferences { get; set; }
    }
}
