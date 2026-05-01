using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace DnDManager.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Campaigns",
                columns: table => new
                {
                    CampaignId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DmName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Campaigns", x => x.CampaignId);
                });

            migrationBuilder.CreateTable(
                name: "Characters",
                columns: table => new
                {
                    CharacterId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Class = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Race = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Level = table.Column<int>(type: "int", nullable: false),
                    MaxHP = table.Column<int>(type: "int", nullable: false),
                    CurrentHP = table.Column<int>(type: "int", nullable: false),
                    AC = table.Column<int>(type: "int", nullable: false),
                    InitiativeBonus = table.Column<int>(type: "int", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    CampaignId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Characters", x => x.CharacterId);
                    table.ForeignKey(
                        name: "FK_Characters_Campaigns_CampaignId",
                        column: x => x.CampaignId,
                        principalTable: "Campaigns",
                        principalColumn: "CampaignId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Combatants",
                columns: table => new
                {
                    CombatantId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Type = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    MaxHP = table.Column<int>(type: "int", nullable: false),
                    CurrentHP = table.Column<int>(type: "int", nullable: false),
                    ArmorClass = table.Column<int>(type: "int", nullable: false),
                    Initiative = table.Column<int>(type: "int", nullable: false),
                    IsDefeated = table.Column<bool>(type: "bit", nullable: false),
                    CampaignId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Combatants", x => x.CombatantId);
                    table.ForeignKey(
                        name: "FK_Combatants_Campaigns_CampaignId",
                        column: x => x.CampaignId,
                        principalTable: "Campaigns",
                        principalColumn: "CampaignId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SessionLogs",
                columns: table => new
                {
                    SessionLogId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    SessionDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    SessionNumber = table.Column<int>(type: "int", nullable: false),
                    Summary = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Notes = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MajorOutcome = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CampaignId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SessionLogs", x => x.SessionLogId);
                    table.ForeignKey(
                        name: "FK_SessionLogs_Campaigns_CampaignId",
                        column: x => x.CampaignId,
                        principalTable: "Campaigns",
                        principalColumn: "CampaignId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Encounters",
                columns: table => new
                {
                    EncounterId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Outcome = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SessionLogId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Encounters", x => x.EncounterId);
                    table.ForeignKey(
                        name: "FK_Encounters_SessionLogs_SessionLogId",
                        column: x => x.SessionLogId,
                        principalTable: "SessionLogs",
                        principalColumn: "SessionLogId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "LogEntries",
                columns: table => new
                {
                    LogEntryId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoundNumber = table.Column<int>(type: "int", nullable: false),
                    TurnOrder = table.Column<int>(type: "int", nullable: false),
                    ActorName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    TargetName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    ActionType = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    ActionDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AttackRoll = table.Column<int>(type: "int", nullable: true),
                    DamageDealt = table.Column<int>(type: "int", nullable: true),
                    HealingDone = table.Column<int>(type: "int", nullable: true),
                    ConditionApplied = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    HpAfterAction = table.Column<int>(type: "int", nullable: true),
                    Notes = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EncounterId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LogEntries", x => x.LogEntryId);
                    table.ForeignKey(
                        name: "FK_LogEntries_Encounters_EncounterId",
                        column: x => x.EncounterId,
                        principalTable: "Encounters",
                        principalColumn: "EncounterId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Campaigns",
                columns: new[] { "CampaignId", "Description", "DmName", "Name" },
                values: new object[] { 1, "A classic starter campaign set in the Forgotten Realms.", "Jared", "The Lost Mines of Phandelver" });

            migrationBuilder.InsertData(
                table: "Characters",
                columns: new[] { "CharacterId", "AC", "CampaignId", "Class", "CurrentHP", "InitiativeBonus", "Level", "MaxHP", "Name", "Race", "Status" },
                values: new object[,]
                {
                    { 1, 18, 1, "Fighter", 34, 2, 3, 34, "Aldric Brightblade", "Human", "Active" },
                    { 2, 13, 1, "Wizard", 20, 3, 3, 20, "Sylvara Moonwhisper", "Elf", "Active" },
                    { 3, 14, 1, "Rogue", 18, 4, 3, 24, "Bram Thistlewick", "Halfling", "Active" }
                });

            migrationBuilder.InsertData(
                table: "Combatants",
                columns: new[] { "CombatantId", "ArmorClass", "CampaignId", "CurrentHP", "Initiative", "IsDefeated", "MaxHP", "Name", "Type" },
                values: new object[,]
                {
                    { 1, 13, 1, 0, 14, true, 7, "Goblin Scout", "Enemy" },
                    { 2, 13, 1, 7, 11, false, 7, "Goblin Archer", "Enemy" }
                });

            migrationBuilder.InsertData(
                table: "SessionLogs",
                columns: new[] { "SessionLogId", "CampaignId", "MajorOutcome", "Notes", "SessionDate", "SessionNumber", "Summary", "Title" },
                values: new object[] { 1, 1, "One goblin defeated; one escaped into the woods.", "Bram took 6 damage from a goblin arrow.", new DateTime(2024, 3, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "The party was ambushed by goblins on the road to Phandalin.", "Ambush on the Triboar Trail" });

            migrationBuilder.InsertData(
                table: "Encounters",
                columns: new[] { "EncounterId", "Description", "Name", "Outcome", "SessionLogId" },
                values: new object[] { 1, "Two goblins leap from the bushes along the trail.", "Goblin Ambush", "One goblin slain, one fled. Party took minor damage.", 1 });

            migrationBuilder.InsertData(
                table: "LogEntries",
                columns: new[] { "LogEntryId", "ActionDescription", "ActionType", "ActorName", "AttackRoll", "ConditionApplied", "DamageDealt", "EncounterId", "HealingDone", "HpAfterAction", "Notes", "RoundNumber", "TargetName", "TurnOrder" },
                values: new object[,]
                {
                    { 1, "Goblin Scout fires a shortbow at Bram.", "Attack", "Goblin Scout", 14, null, 6, 1, null, 18, "Hit! Bram drops to 18 HP.", 1, "Bram Thistlewick", 1 },
                    { 2, "Bram retaliates with a sneak attack using his shortsword.", "Attack", "Bram Thistlewick", 18, null, 9, 1, null, 0, "Critical sneak attack! Goblin Scout is defeated.", 1, "Goblin Scout", 2 },
                    { 3, "Sylvara casts Fire Bolt at the Goblin Archer.", "Spell", "Sylvara Moonwhisper", 12, null, 5, 1, null, 2, "Hit for 5 fire damage.", 1, "Goblin Archer", 3 },
                    { 4, "Aldric charges and swings his longsword.", "Attack", "Aldric Brightblade", 16, null, 8, 1, null, 0, "Goblin Archer is slain.", 1, "Goblin Archer", 4 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Characters_CampaignId",
                table: "Characters",
                column: "CampaignId");

            migrationBuilder.CreateIndex(
                name: "IX_Combatants_CampaignId",
                table: "Combatants",
                column: "CampaignId");

            migrationBuilder.CreateIndex(
                name: "IX_Encounters_SessionLogId",
                table: "Encounters",
                column: "SessionLogId");

            migrationBuilder.CreateIndex(
                name: "IX_LogEntries_EncounterId",
                table: "LogEntries",
                column: "EncounterId");

            migrationBuilder.CreateIndex(
                name: "IX_SessionLogs_CampaignId",
                table: "SessionLogs",
                column: "CampaignId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Characters");

            migrationBuilder.DropTable(
                name: "Combatants");

            migrationBuilder.DropTable(
                name: "LogEntries");

            migrationBuilder.DropTable(
                name: "Encounters");

            migrationBuilder.DropTable(
                name: "SessionLogs");

            migrationBuilder.DropTable(
                name: "Campaigns");
        }
    }
}
