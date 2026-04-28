using System.ComponentModel.DataAnnotations;

namespace DnDManager.Models
{
    public class LogEntry
    {
        public int LogEntryId { get; set; }

        [Required]
        [Range(1, 999)]
        [Display(Name = "Round #")]
        public int RoundNumber { get; set; }

        [Required]
        [Range(1, 999)]
        [Display(Name = "Turn Order")]
        public int TurnOrder { get; set; }

        [Required]
        [StringLength(100)]
        [Display(Name = "Actor")]
        public string ActorName { get; set; } = string.Empty;

        [StringLength(100)]
        [Display(Name = "Target")]
        public string? TargetName { get; set; }

        [Required]
        [StringLength(50)]
        [Display(Name = "Action Type")]
        public string ActionType { get; set; } = "Other";

        [Display(Name = "Description")]
        public string? ActionDescription { get; set; }

        [Display(Name = "Attack Roll")]
        public int? AttackRoll { get; set; }

        [Display(Name = "Damage Dealt")]
        public int? DamageDealt { get; set; }

        [Display(Name = "Healing Done")]
        public int? HealingDone { get; set; }

        [StringLength(100)]
        [Display(Name = "Condition Applied")]
        public string? ConditionApplied { get; set; }

        [Display(Name = "HP After Action")]
        public int? HpAfterAction { get; set; }

        public string? Notes { get; set; }

        // Foreign key
        public int EncounterId { get; set; }
        public Encounter? Encounter { get; set; }
    }
}
