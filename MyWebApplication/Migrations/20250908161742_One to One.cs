using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MyWebApplication.Migrations
{
    /// <inheritdoc />
    public partial class OnetoOne : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "SerialNumberId",
                table: "Items",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "SerialNumbers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SerialNumbers", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "SerialNumbers",
                columns: new[] { "Id", "Name" },
                values: new object[] { 1, "SerialNumber1" });

            migrationBuilder.InsertData(
                table: "Items",
                columns: new[] { "Id", "Name", "Price", "SerialNumberId" },
                values: new object[] { 1, "Item1", 10.0, 1 });

            migrationBuilder.CreateIndex(
                name: "IX_Items_SerialNumberId",
                table: "Items",
                column: "SerialNumberId",
                unique: true,
                filter: "[SerialNumberId] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_Items_SerialNumbers_SerialNumberId",
                table: "Items",
                column: "SerialNumberId",
                principalTable: "SerialNumbers",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Items_SerialNumbers_SerialNumberId",
                table: "Items");

            migrationBuilder.DropTable(
                name: "SerialNumbers");

            migrationBuilder.DropIndex(
                name: "IX_Items_SerialNumberId",
                table: "Items");

            migrationBuilder.DeleteData(
                table: "Items",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DropColumn(
                name: "SerialNumberId",
                table: "Items");
        }
    }
}
