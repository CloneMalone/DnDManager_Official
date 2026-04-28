using System.ComponentModel.DataAnnotations;

namespace DnDManager.Models
{
    public class Encounter
    {
        public int EncounterId { get; set; }

        [Required]
        [StringLength(150)]
        public string Name { get; set; } = string.Empty;

        public string? Description { get; set; }

        public string? Outcome { get; set; }

        // Foreign key
        public int SessionLogId { get; set; }
        public SessionLog? SessionLog { get; set; }

        public List<LogEntry> LogEntries { get; set; } = new List<LogEntry>();
    }
}
