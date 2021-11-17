using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;



namespace JAMSDapperDemo.Model
{
    [Table("History")]
    public class History
    {
        public History()
        {
            HistoryAuditTrails = new HashSet<HistoryAuditTrail>();
            HistoryElements = new HashSet<HistoryElement>();
            HistoryParams = new HashSet<HistoryParam>();
            HistoryProperties = new HashSet<HistoryProperty>();
            HistoryTags = new HashSet<HistoryTag>();
        }

        [Key]
        public int TenantId { get; set; }
        [Key]
        public int JobId { get; set; }
        [Key]
        public long HistoryId { get; set; }
        public DateTime ScheduledTime { get; set; }
        [Column("RON")]
        public long Ron { get; set; }
        public int RestartCount { get; set; }
        [Column("JAMSEntry")]
        public int Jamsentry { get; set; }
        public DateTime? OriginalHoldTime { get; set; }
        public DateTime? HoldTime { get; set; }
        public DateTime? StartTime { get; set; }
        public DateTime? CompletionTime { get; set; }
        public int CpuTime { get; set; }
        public int PageFaults { get; set; }
        public long WorkingSetPeak { get; set; }
        [Column("BufferedIOCount")]
        public int BufferedIocount { get; set; }
        [Column("DirectIOCount")]
        public int DirectIocount { get; set; }
        public int MethodId { get; set; }
        public int ParentFolderId { get; set; }
        public int InitiatorType { get; set; }
        public int InitiatorId { get; set; }
        public Guid InitiatorUid { get; set; }
        public int Pid { get; set; }
        public int SchedulingPriority { get; set; }
        public int ExecutionPriority { get; set; }
        public int FinalStatus { get; set; }
        public byte FinalSeverity { get; set; }
        public bool Debug { get; set; }
        public bool Held { get; set; }
        [StringLength(256)]
        public string LogFilename { get; set; }
        [Required]
        [StringLength(64)]
        public string SubmittedBy { get; set; }
        [StringLength(256)]
        public string JobName { get; set; }
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
        [Column("ParentRRON")]
        public long? ParentRron { get; set; }
        public int? ExecutingAgentId { get; set; }
        public int? InitiatorRestartCount { get; set; }

        [InverseProperty(nameof(HistoryAuditTrail.History))]
        public ICollection<HistoryAuditTrail> HistoryAuditTrails { get; set; }
        [InverseProperty(nameof(HistoryElement.History))]
        public ICollection<HistoryElement> HistoryElements { get; set; }
        [InverseProperty(nameof(HistoryParam.History))]
        public ICollection<HistoryParam> HistoryParams { get; set; }
        [InverseProperty(nameof(HistoryProperty.History))]
        public ICollection<HistoryProperty> HistoryProperties { get; set; }
        [InverseProperty(nameof(HistoryTag.History))]
        public ICollection<HistoryTag> HistoryTags { get; set; }
    }
}
