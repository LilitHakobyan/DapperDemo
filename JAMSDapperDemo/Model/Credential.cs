using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;


namespace JAMSDapperDemo.Model
{
    [Table("Credential")]
    [Index(nameof(TenantId), nameof(CredentialName), Name = "SK_Credential_Name", IsUnique = true)]
    public class Credential
    {
        public DateTime? LastChange { get; set; }
        public int? Type { get; set; }
        [Required]
        [StringLength(64)]
        public string CredentialName { get; set; }
        [MaxLength(1024)]
        public byte[] EncryptedPassword { get; set; }
        public byte[] Acl { get; set; }
        [StringLength(64)]
        public string LogonUsername { get; set; }
        [MaxLength(4096)]
        public byte[] EncryptedPrivateKey { get; set; }
        [Key]
        public int CredentialId { get; set; }
        public string Description { get; set; }
        [Key]
        public int TenantId { get; set; }
    }
}
