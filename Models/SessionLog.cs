using System.ComponentModel.DataAnnotations;

namespace DnDManager.Models
{
    public class SessionLog
    {
        public int SessionLogId { get; set; }

        [Required]
        [StringLength(150)]
        public string Title { get; set; } = string.Empty;

        [Required]
        [DataType(DataType.Date)]
        [Display(Name = "Session Date")]
        public DateTime SessionDate { get; set; }

        [Display(Name = "Session #")]
        public int SessionNumber { get; set; }

        public string? Summary { get; set; }

        public string? Notes { get; set; }

        [Display(Name = "Major Outcome")]
        public string? MajorOutcome { get; set; }

        // Foreign key
        public int CampaignId { get; set; }
        public Campaign? Campaign { get; set; }

        public List<Encounter> Encounters { get; set; } = new List<Encounter>();
    }
}
