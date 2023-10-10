using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EshopOnVue.js.Infrastructure.Data.Migrations
{
    /// <inheritdoc />
    public partial class Size : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "MemberPrice",
                table: "CatalogItems",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.CreateTable(
                name: "Size",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Size", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ItemSizesWithStock",
                columns: table => new
                {
                    CatalogItemId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SizeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    StockNumber = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ItemSizesWithStock", x => new { x.CatalogItemId, x.SizeId });
                    table.ForeignKey(
                        name: "FK_ItemSizesWithStock_CatalogItems_CatalogItemId",
                        column: x => x.CatalogItemId,
                        principalTable: "CatalogItems",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ItemSizesWithStock_Size_SizeId",
                        column: x => x.SizeId,
                        principalTable: "Size",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ItemSizesWithStock_SizeId",
                table: "ItemSizesWithStock",
                column: "SizeId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ItemSizesWithStock");

            migrationBuilder.DropTable(
                name: "Size");

            migrationBuilder.DropColumn(
                name: "MemberPrice",
                table: "CatalogItems");
        }
    }
}
