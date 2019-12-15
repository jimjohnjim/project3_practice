using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace PBJProject.Storing.Migrations
{
    public partial class nmigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Account",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    UserName = table.Column<string>(nullable: true),
                    FirstName = table.Column<string>(nullable: true),
                    LastName = table.Column<string>(nullable: true),
                    Password = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    Path = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Account", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Character",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
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
                    FileName = table.Column<string>(nullable: true),
                    AccountID = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Character", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Character_Account_AccountID",
                        column: x => x.AccountID,
                        principalTable: "Account",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "Account",
                columns: new[] { "ID", "Email", "FirstName", "LastName", "Password", "Path", "UserName" },
                values: new object[,]
                {
                    { 1, "joshua@familiar.com", "Joshua", "Guillory", "revature7", null, "jguillo" },
                    { 2, "phillip@familiar.com", "Phillip", "Krawetz", "revature8", null, "phillip" },
                    { 3, "benjamin@familiar.com", "Benjamin", "Clegg", "revature9", null, "sven" },
                    { 4, "phillip@familiar.com", "Phillip", "Krawetz", "revature8", null, "lisa" }
                });

            migrationBuilder.InsertData(
                table: "Character",
                columns: new[] { "ID", "AccountID", "CharacterClass", "Charisma", "Constitution", "Dexterity", "FileName", "Intelligence", "Level", "Name", "Race", "Strength", "Wisdom" },
                values: new object[] { 1, null, "Fighter", 10, 16, 12, null, 8, 1, "Dummy", "Human", 18, 10 });

            migrationBuilder.CreateIndex(
                name: "IX_Character_AccountID",
                table: "Character",
                column: "AccountID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Character");

            migrationBuilder.DropTable(
                name: "Account");
        }
    }
}
