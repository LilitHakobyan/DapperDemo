using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;



namespace JAMSDapperDemo.Model
{
    [Table("MenuM")]
    [Index(nameof(TenantId), nameof(MenuName), Name = "SK_MenuM_Name", IsUnique = true)]
    public class MenuM
    {
        public MenuM()
        {
            MenuDs = new HashSet<MenuD>();
        }

        public DateTime? LastChange { get; set; }
        [StringLength(256)]
        public string MenuName { get; set; }
        [Key]
        public int MenuId { get; set; }
        public string Description { get; set; }
        public int Version { get; set; }
        [Key]
        public int TenantId { get; set; }

        [InverseProperty(nameof(MenuD.MenuM))]
        public ICollection<MenuD> MenuDs { get; set; }
    }
}
