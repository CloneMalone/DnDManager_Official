using System.ComponentModel.DataAnnotations;

namespace DnDManager.Models
{
    public class Campaign
    {
        public int CampaignId { get; set; }

        [Required(ErrorMessage = "Campaign name is required.")]
        [StringLength(100)]
        public string Name { get; set; } = string.Empty;

        [Required(ErrorMessage = "Description is required.")]
        [StringLength(500)]
        public string Description { get; set; } = string.Empty;

        [Display(Name = "Dungeon Master")]
        [StringLength(100)]
        public string? DmName { get; set; }

        public ICollection<Character>? Characters { get; set; }
        public ICollection<SessionLog>? SessionLogs { get; set; }
        public ICollection<Combatant>? Combatants { get; set; }
    }
}
