using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AgroMart.Data.Migrations
{
    public partial class AddOrderOrderedItemModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "OrderOrderedItems",
                columns: table => new
                {
                    OrderId = table.Column<int>(type: "INTEGER", nullable: false),
                    OrderedItemId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderOrderedItems", x => new { x.OrderId, x.OrderedItemId });
                    table.ForeignKey(
                        name: "FK_OrderOrderedItems_OrderedItems_OrderedItemId",
                        column: x => x.OrderedItemId,
                        principalTable: "OrderedItems",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OrderOrderedItems_Orders_OrderId",
                        column: x => x.OrderId,
                        principalTable: "Orders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_OrderOrderedItems_OrderedItemId",
                table: "OrderOrderedItems",
                column: "OrderedItemId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "OrderOrderedItems");
        }
    }
}
