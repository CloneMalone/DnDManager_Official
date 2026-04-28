using Microsoft.EntityFrameworkCore;

namespace DnDManager.Models
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Campaign> Campaigns { get; set; } = null!;
        public DbSet<Character> Characters { get; set; } = null!;
        public DbSet<SessionLog> SessionLogs { get; set; } = null!;
        public DbSet<Combatant> Combatants { get; set; } = null!;
        public DbSet<Encounter> Encounters { get; set; } = null!;
        public DbSet<LogEntry> LogEntries { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Seed Campaign
            modelBuilder.Entity<Campaign>().HasData(
                new Campaign
                {
                    CampaignId = 1,
                    Name = "The Lost Mines of Phandelver",
                    Description = "A classic starter campaign set in the Forgotten Realms.",
                    DmName = "Jared"
                }
            );

            // Seed Characters
            modelBuilder.Entity<Character>().HasData(
                new Character
                {
                    CharacterId = 1,
                    CampaignId = 1,
                    Name = "Aldric Brightblade",
                    Class = "Fighter",
                    Race = "Human",
                    Level = 3,
                    MaxHP = 34,
                    CurrentHP = 34,
                    AC = 18,
                    InitiativeBonus = 2,
                    Status = "Active"
                },
                new Character
                {
                    CharacterId = 2,
                    CampaignId = 1,
                    Name = "Sylvara Moonwhisper",
                    Class = "Wizard",
                    Race = "Elf",
                    Level = 3,
                    MaxHP = 20,
                    CurrentHP = 20,
                    AC = 13,
                    InitiativeBonus = 3,
                    Status = "Active"
                },
                new Character
                {
                    CharacterId = 3,
                    CampaignId = 1,
                    Name = "Bram Thistlewick",
                    Class = "Rogue",
                    Race = "Halfling",
                    Level = 3,
                    MaxHP = 24,
                    CurrentHP = 18,
                    AC = 14,
                    InitiativeBonus = 4,
                    Status = "Active"
                }
            );

            // Seed Combatants
            modelBuilder.Entity<Combatant>().HasData(
                new Combatant
                {
                    CombatantId = 1,
                    CampaignId = 1,
                    Name = "Goblin Scout",
                    Type = "Enemy",
                    MaxHP = 7,
                    CurrentHP = 0,
                    ArmorClass = 13,
                    Initiative = 14,
                    IsDefeated = true
                },
                new Combatant
                {
                    CombatantId = 2,
                    CampaignId = 1,
                    Name = "Goblin Archer",
                    Type = "Enemy",
                    MaxHP = 7,
                    CurrentHP = 7,
                    ArmorClass = 13,
                    Initiative = 11,
                    IsDefeated = false
                }
            );

            // Seed SessionLog
            modelBuilder.Entity<SessionLog>().HasData(
                new SessionLog
                {
                    SessionLogId = 1,
                    CampaignId = 1,
                    SessionNumber = 1,
                    Title = "Ambush on the Triboar Trail",
                    SessionDate = new DateTime(2024, 3, 15),
                    Summary = "The party was ambushed by goblins on the road to Phandalin.",
                    Notes = "Bram took 6 damage from a goblin arrow.",
                    MajorOutcome = "One goblin defeated; one escaped into the woods."
                }
            );

            // Seed Encounter
            modelBuilder.Entity<Encounter>().HasData(
                new Encounter
                {
                    EncounterId = 1,
                    SessionLogId = 1,
                    Name = "Goblin Ambush",
                    Description = "Two goblins leap from the bushes along the trail.",
                    Outcome = "One goblin slain, one fled. Party took minor damage."
                }
            );

            // Seed LogEntries (one round of combat)
            modelBuilder.Entity<LogEntry>().HasData(
                new LogEntry
                {
                    LogEntryId = 1,
                    EncounterId = 1,
                    RoundNumber = 1,
                    TurnOrder = 1,
                    ActorName = "Goblin Scout",
                    TargetName = "Bram Thistlewick",
                    ActionType = "Attack",
                    ActionDescription = "Goblin Scout fires a shortbow at Bram.",
                    AttackRoll = 14,
                    DamageDealt = 6,
                    HealingDone = null,
                    ConditionApplied = null,
                    HpAfterAction = 18,
                    Notes = "Hit! Bram drops to 18 HP."
                },
                new LogEntry
                {
                    LogEntryId = 2,
                    EncounterId = 1,
                    RoundNumber = 1,
                    TurnOrder = 2,
                    ActorName = "Bram Thistlewick",
                    TargetName = "Goblin Scout",
                    ActionType = "Attack",
                    ActionDescription = "Bram retaliates with a sneak attack using his shortsword.",
                    AttackRoll = 18,
                    DamageDealt = 9,
                    HealingDone = null,
                    ConditionApplied = null,
                    HpAfterAction = 0,
                    Notes = "Critical sneak attack! Goblin Scout is defeated."
                },
                new LogEntry
                {
                    LogEntryId = 3,
                    EncounterId = 1,
                    RoundNumber = 1,
                    TurnOrder = 3,
                    ActorName = "Sylvara Moonwhisper",
                    TargetName = "Goblin Archer",
                    ActionType = "Spell",
                    ActionDescription = "Sylvara casts Fire Bolt at the Goblin Archer.",
                    AttackRoll = 12,
                    DamageDealt = 5,
                    HealingDone = null,
                    ConditionApplied = null,
                    HpAfterAction = 2,
                    Notes = "Hit for 5 fire damage."
                },
                new LogEntry
                {
                    LogEntryId = 4,
                    EncounterId = 1,
                    RoundNumber = 1,
                    TurnOrder = 4,
                    ActorName = "Aldric Brightblade",
                    TargetName = "Goblin Archer",
                    ActionType = "Attack",
                    ActionDescription = "Aldric charges and swings his longsword.",
                    AttackRoll = 16,
                    DamageDealt = 8,
                    HealingDone = null,
                    ConditionApplied = null,
                    HpAfterAction = 0,
                    Notes = "Goblin Archer is slain."
                }
            );
        }
    }
}
