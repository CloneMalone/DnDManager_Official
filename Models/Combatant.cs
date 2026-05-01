using System.ComponentModel.DataAnnotations;

namespace DnDManager.Models
{
    public class Combatant
    {
        public int CombatantId { get; set; }

        [Required]
        [StringLength(100)]
        public string Name { get; set; } = string.Empty;

        [StringLength(50)]
        public string? Type { get; set; } = "Enemy";

        [Required]
        [Range(1, 999)]
        [Display(Name = "Max HP")]
        public int MaxHP { get; set; }

        [Range(0, 999)]
        [Display(Name = "Current HP")]
        public int CurrentHP { get; set; }

        [Range(0, 30)]
        [Display(Name = "Armor Class")]
        public int ArmorClass { get; set; }

        [Range(0, 99)]
        public int Initiative { get; set; }

        [Display(Name = "Defeated?")]
        public bool IsDefeated { get; set; }

        // Foreign key
        public int CampaignId { get; set; }
        public Campaign? Campaign { get; set; }
    }
}
