using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;



namespace JAMSDapperDemo.Model
{
    [Table("FolderParam")]
    public class FolderParam
    {
        public FolderParam()
        {
            FolderParamProperties = new HashSet<FolderParamProperty>();
        }

        [Key]
        public int TenantId { get; set; }
        [Key]
        public int FolderId { get; set; }
        [Key]
        public int ParamId { get; set; }
        public Guid ParamUid { get; set; }
        [Required]
        [StringLength(256)]
        public string ParamName { get; set; }
        public byte DataType { get; set; }
        public int Length { get; set; }
        public int? Override { get; set; }

        [ForeignKey("TenantId,FolderId")]
        [InverseProperty("FolderParams")]
        public Folder Folder { get; set; }
        [InverseProperty(nameof(FolderParamProperty.FolderParam))]
        public ICollection<FolderParamProperty> FolderParamProperties { get; set; }
    }
}
