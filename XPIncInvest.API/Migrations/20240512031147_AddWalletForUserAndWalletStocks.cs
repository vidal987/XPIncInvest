using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace XPIncInvest.API.Migrations
{
    /// <inheritdoc />
    public partial class AddWalletForUserAndWalletStocks : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Wallets",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    UserId = table.Column<Guid>(type: "uuid", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Wallets", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Wallets_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "WallerStock",
                columns: table => new
                {
                    StocksId = table.Column<Guid>(type: "uuid", nullable: false),
                    WalletsId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WallerStock", x => new { x.StocksId, x.WalletsId });
                    table.ForeignKey(
                        name: "FK_WallerStock_Stocks_StocksId",
                        column: x => x.StocksId,
                        principalTable: "Stocks",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_WallerStock_Wallets_WalletsId",
                        column: x => x.WalletsId,
                        principalTable: "Wallets",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_WallerStock_WalletsId",
                table: "WallerStock",
                column: "WalletsId");

            migrationBuilder.CreateIndex(
                name: "IX_Wallets_UserId",
                table: "Wallets",
                column: "UserId",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "WallerStock");

            migrationBuilder.DropTable(
                name: "Wallets");
        }
    }
}
