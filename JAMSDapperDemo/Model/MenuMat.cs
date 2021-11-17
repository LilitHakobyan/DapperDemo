using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;



namespace JAMSDapperDemo.Model
{
    [Table("MenuMAT")]
    public class MenuMat
    {
        public MenuMat()
        {
            MenuDats = new HashSet<MenuDat>();
        }

        public DateTime? LastChange { get; set; }
        [StringLength(256)]
        public string MenuName { get; set; }
        [Key]
        public int MenuId { get; set; }
        public string Description { get; set; }
        [Key]
        public int Version { get; set; }
        [Key]
        public int TenantId { get; set; }
        public string ChangeComment { get; set; }

        [InverseProperty(nameof(MenuDat.MenuMat))]
        public ICollection<MenuDat> MenuDats { get; set; }
    }
}
