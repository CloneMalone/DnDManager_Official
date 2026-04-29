using System.ComponentModel.DataAnnotations;

namespace DnDManager.Models
{
    public class Character
    {
        // Properties go here
        [Key]
public int CharacterId { get; set; }   // Primary Key

[Required]
public int CampaignId { get; set; }    // Foreign Key

[Required]
[MaxLength(100)]
public string Name { get; set; } = string.Empty;

[Required]
[MaxLength(50)]
public string Class { get; set; } = string.Empty;

[Required]
[MaxLength(50)]
public string Race { get; set; } = string.Empty;

[Range(1, 20)]
public int Level { get; set; }

[Range(0, int.MaxValue)]
public int CurrentHp { get; set; }

[Range(1, int.MaxValue)]
public int MaxHp { get; set; }

[Range(0, 50)]
public int ArmorClass { get; set; }

public int InitiativeBonus { get; set; }

[MaxLength(100)]
public string? Status { get; set; }
    }
}
