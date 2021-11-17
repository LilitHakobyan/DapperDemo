using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;



namespace JAMSDapperDemo.Model
{
    [Table("UserSettingElement")]
    public class UserSettingElement
    {
        public UserSettingElement()
        {
            UserSettingElementProperties = new HashSet<UserSettingElementProperty>();
        }

        [Key]
        public int TenantId { get; set; }
        [Key]
        [MaxLength(128)]
        public byte[] UniqueUserId { get; set; }
        [Key]
        public int ElementId { get; set; }
        public int ElementTypeId { get; set; }
        public Guid ElementUid { get; set; }
        [Required]
        [StringLength(256)]
        public string ElementName { get; set; }

        [InverseProperty(nameof(UserSettingElementProperty.UserSettingElement))]
        public ICollection<UserSettingElementProperty> UserSettingElementProperties { get; set; }
    }
}
