using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BurnBuilder.Data.Migrations
{
    public partial class InitialCustomTableCreation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Card",
                columns: table => new
                {
                    CardId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    ManaCost = table.Column<string>(nullable: true),
                    Cmc = table.Column<decimal>(type: "decimal", nullable: false),
                    Colors = table.Column<string>(nullable: true),
                    ColorIdentity = table.Column<string>(nullable: true),
                    Type = table.Column<string>(nullable: true),
                    Supertypes = table.Column<string>(nullable: true),
                    Types = table.Column<string>(nullable: true),
                    Subtypes = table.Column<string>(nullable: true),
                    Rarity = table.Column<string>(nullable: true),
                    Set = table.Column<string>(nullable: true),
                    SetName = table.Column<string>(nullable: true),
                    Text = table.Column<string>(nullable: true),
                    Artist = table.Column<string>(nullable: true),
                    Number = table.Column<string>(nullable: true),
                    Layout = table.Column<string>(nullable: true),
                    MultiverseID = table.Column<int>(nullable: false),
                    ImageUrl = table.Column<string>(nullable: true),
                    Rulings = table.Column<string>(nullable: true),
                    ForeignNames = table.Column<string>(nullable: true),
                    Printings = table.Column<string>(nullable: true),
                    OriginalText = table.Column<string>(nullable: true),
                    OriginalType = table.Column<string>(nullable: true),
                    Legalities = table.Column<string>(nullable: true),
                    Id = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Card", x => x.CardId);
                });

            migrationBuilder.CreateTable(
                name: "CardSet",
                columns: table => new
                {
                    CardSetId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Code = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    Type = table.Column<string>(nullable: true),
                    Booster = table.Column<string>(nullable: true),
                    ReleaseDate = table.Column<string>(nullable: true),
                    Block = table.Column<string>(nullable: true),
                    OnlineOnly = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CardSet", x => x.CardSetId);
                });

            migrationBuilder.CreateTable(
                name: "Deck",
                columns: table => new
                {
                    DeckId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatorUserId = table.Column<int>(nullable: false),
                    DeckName = table.Column<string>(maxLength: 50, nullable: true),
                    Created = table.Column<DateTime>(nullable: false),
                    Description = table.Column<string>(maxLength: 500, nullable: true),
                    DeckColor = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Deck", x => x.DeckId);
                });

            migrationBuilder.CreateTable(
                name: "DeckCard",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CardId = table.Column<int>(nullable: false),
                    DeckId = table.Column<int>(nullable: false),
                    CardQuantity = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DeckCard", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    UserId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EmailAddress = table.Column<string>(nullable: true),
                    Password = table.Column<string>(nullable: true),
                    FirstName = table.Column<string>(maxLength: 500, nullable: true),
                    LastName = table.Column<string>(maxLength: 500, nullable: true),
                    Created = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.UserId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Card");

            migrationBuilder.DropTable(
                name: "CardSet");

            migrationBuilder.DropTable(
                name: "Deck");

            migrationBuilder.DropTable(
                name: "DeckCard");

            migrationBuilder.DropTable(
                name: "User");
        }
    }
}
