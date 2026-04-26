using System.ComponentModel.DataAnnotations;

namespace DnDManager.Models
{
    public class LogEntry
    {
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string Action { get; set; } // Attack, Heal, Spell, etc.

        [Required]
        [StringLength(255)]
        public string Description { get; set; } 
        // Example: "Rolled 18, dealt 7 damage"

        public int RoundNumber { get; set; } // Optional but VERY useful

        // 🔗 Foreign Key → Encounter
        public int EncounterId { get; set; }
        public Encounter Encounter { get; set; }
    }
}
