using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;



namespace JAMSDapperDemo.Model
{
    [Table("Folder")]
    public class Folder
    {
        public Folder()
        {
            FolderElements = new HashSet<FolderElement>();
            FolderParams = new HashSet<FolderParam>();
            FolderProperties = new HashSet<FolderProperty>();
            FolderTags = new HashSet<FolderTag>();
            InverseFolderNavigation = new HashSet<Folder>();
            Jobs = new HashSet<Job>();
            Variables = new HashSet<Variable>();
        }

        public DateTime LastChange { get; set; }
        [Required]
        [StringLength(64)]
        public string LastChangedBy { get; set; }
        [Key]
        public int TenantId { get; set; }
        [Key]
        public int FolderId { get; set; }
        [Required]
        [StringLength(256)]
        public string FolderName { get; set; }
        public int Version { get; set; }
        public int? ParentFolderId { get; set; }
        public string Description { get; set; }
        public byte[] Acl { get; set; }

        [ForeignKey("TenantId,ParentFolderId")]
        [InverseProperty(nameof(Folder.InverseFolderNavigation))]
        public Folder FolderNavigation { get; set; }
        [InverseProperty(nameof(FolderElement.Folder))]
        public ICollection<FolderElement> FolderElements { get; set; }
        [InverseProperty(nameof(FolderParam.Folder))]
        public ICollection<FolderParam> FolderParams { get; set; }
        [InverseProperty(nameof(FolderProperty.Folder))]
        public ICollection<FolderProperty> FolderProperties { get; set; }
        [InverseProperty(nameof(FolderTag.Folder))]
        public ICollection<FolderTag> FolderTags { get; set; }
        [InverseProperty(nameof(Folder.FolderNavigation))]
        public ICollection<Folder> InverseFolderNavigation { get; set; }
        [InverseProperty(nameof(Job.Folder))]
        public ICollection<Job> Jobs { get; set; }
        [InverseProperty(nameof(Variable.Folder))]
        public ICollection<Variable> Variables { get; set; }
    }
}
