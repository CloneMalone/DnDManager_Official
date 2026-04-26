using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace DnDManager.Models
{
    public class Encounter
    {
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string Name { get; set; } // Example: "Goblin Fight"

        public string Outcome { get; set; } // Win / Loss / Escaped

        //  Foreign Key → SessionLog
        public int SessionLogId { get; set; }
        public SessionLog SessionLog { get; set; }

        //  One Encounter has many LogEntries
        public List<LogEntry> LogEntries { get; set; } = new List<LogEntry>();
    }
}
