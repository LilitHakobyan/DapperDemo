using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;



namespace JAMSDapperDemo.Model
{
    [Table("Entry")]
    public class Entry
    {
        public Entry()
        {
            EntryAuditTrails = new HashSet<EntryAuditTrail>();
            EntryElements = new HashSet<EntryElement>();
            EntryParams = new HashSet<EntryParam>();
            EntryProperties = new HashSet<EntryProperty>();
            EntryTags = new HashSet<EntryTag>();
            ObjectStores = new HashSet<ObjectStore>();
        }

        [Key]
        public int TenantId { get; set; }
        [Key]
        [Column("JAMSEntry")]
        public int Jamsentry { get; set; }
        [Column("RON")]
        public long Ron { get; set; }
        public DateTime TodaysDate { get; set; }
        public DateTime ScheduledTime { get; set; }
        public DateTime? OriginalHoldTime { get; set; }
        public DateTime? HoldTime { get; set; }
        public DateTime? StartTime { get; set; }
        public DateTime? CompletionTime { get; set; }
        public int MethodId { get; set; }
        public int ParentFolderId { get; set; }
        public int JobId { get; set; }
        public int ExecutingAgentId { get; set; }
        public int InitiatorType { get; set; }
        public int InitiatorId { get; set; }
        public Guid InitiatorUid { get; set; }
        public int Pid { get; set; }
        public int SchedulingPriority { get; set; }
        public int ExecutionPriority { get; set; }
        public int FinalStatus { get; set; }
        public byte FinalSeverity { get; set; }
        public int RetainTime { get; set; }
        public int RestartCount { get; set; }
        public int CurrentState { get; set; }
        public bool Debug { get; set; }
        public bool Held { get; set; }
        public bool IconPermanent { get; set; }
        public int Icon { get; set; }
        [StringLength(256)]
        public string LogFilename { get; set; }
        [StringLength(256)]
        public string TempFilename { get; set; }
        [Required]
        [StringLength(64)]
        public string SubmittedBy { get; set; }
        [StringLength(256)]
        public string DisplayName { get; set; }
        [StringLength(256)]
        public string ReconnectAgentName { get; set; }
        public string FinalStatusText { get; set; }
        public string NoteText { get; set; }
        public string JobStatus { get; set; }
        public string IconMessage { get; set; }
        public string Source { get; set; }
        [Column("JAMSId")]
        public Guid Jamsid { get; set; }
        [Column("WFNextTimer")]
        public DateTime? WfnextTimer { get; set; }
        [Column("WFState")]
        public byte? Wfstate { get; set; }
        [Column("WFInstance")]
        public Guid? Wfinstance { get; set; }
        public int? InitiatorRestartCount { get; set; }

        [InverseProperty(nameof(EntryAuditTrail.Entry))]
        public ICollection<EntryAuditTrail> EntryAuditTrails { get; set; }
        [InverseProperty(nameof(EntryElement.Entry))]
        public ICollection<EntryElement> EntryElements { get; set; }
        [InverseProperty(nameof(EntryParam.Entry))]
        public ICollection<EntryParam> EntryParams { get; set; }
        [InverseProperty(nameof(EntryProperty.Entry))]
        public ICollection<EntryProperty> EntryProperties { get; set; }
        [InverseProperty(nameof(EntryTag.Entry))]
        public ICollection<EntryTag> EntryTags { get; set; }
        [InverseProperty(nameof(ObjectStore.Entry))]
        public ICollection<ObjectStore> ObjectStores { get; set; }
    }
}
