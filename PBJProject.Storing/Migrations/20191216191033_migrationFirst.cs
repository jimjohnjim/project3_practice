using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace PBJProject.Storing.Migrations
{
    public partial class migrationFirst : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateSequence<int>(
                name: "PrimaryId");

            migrationBuilder.CreateTable(
                name: "Account",
                columns: table => new
                {
                    AccountId = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    UserName = table.Column<string>(nullable: true),
                    FirstName = table.Column<string>(nullable: true),
                    LastName = table.Column<string>(nullable: true),
                    Password = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Account", x => x.AccountId);
                });

            migrationBuilder.CreateTable(
                name: "DiceEntity",
                columns: table => new
                {
                    PrimaryId = table.Column<int>(nullable: false, defaultValueSql: "nextval('\"PrimaryId\"')"),
                    Value = table.Column<int>(nullable: false),
                    Sum = table.Column<int>(nullable: false),
                    Highest = table.Column<int>(nullable: false),
                    RollId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DiceEntity", x => x.PrimaryId);
                });

            migrationBuilder.CreateTable(
                name: "Character",
                columns: table => new
                {
                    CharacterId = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    Level = table.Column<int>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Race = table.Column<string>(nullable: true),
                    Strength = table.Column<int>(nullable: false),
                    Intelligence = table.Column<int>(nullable: false),
                    Dexterity = table.Column<int>(nullable: false),
                    Wisdom = table.Column<int>(nullable: false),
                    Charisma = table.Column<int>(nullable: false),
                    Constitution = table.Column<int>(nullable: false),
                    CharacterClass = table.Column<string>(nullable: true),
                    AccountId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Character", x => x.CharacterId);
                    table.ForeignKey(
                        name: "FK_Character_Account_AccountId",
                        column: x => x.AccountId,
                        principalTable: "Account",
                        principalColumn: "AccountId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "Account",
                columns: new[] { "AccountId", "Email", "FirstName", "LastName", "Password", "UserName" },
                values: new object[,]
                {
                    { 1, "joshua@familiar.com", "Joshua", "Guillory", "revature7", "jguillo" },
                    { 2, "phillip@familiar.com", "Phillip", "Krawetz", "revature8", "phillip" },
                    { 3, "benjamin@familiar.com", "Benjamin", "Clegg", "revature9", "sven" },
                    { 4, "phillip@familiar.com", "Phillip", "Krawetz", "revature8", "lisa" }
                });

            migrationBuilder.InsertData(
                table: "Character",
                columns: new[] { "CharacterId", "AccountId", "CharacterClass", "Charisma", "Constitution", "Dexterity", "Intelligence", "Level", "Name", "Race", "Strength", "Wisdom" },
                values: new object[,]
                {
                    { 2, 2, "Rogue", 10, 10, 10, 10, 1, "Silly", "Human", 10, 10 },
                    { 3, 2, "Bard", 10, 10, 10, 10, 1, "Testing", "Human", 10, 10 },
                    { 1, 3, "Fighter", 10, 16, 12, 8, 1, "Dummy", "Human", 18, 10 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Character_AccountId",
                table: "Character",
                column: "AccountId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Character");

            migrationBuilder.DropTable(
                name: "DiceEntity");

            migrationBuilder.DropTable(
                name: "Account");

            migrationBuilder.DropSequence(
                name: "PrimaryId");
        }
    }
}
