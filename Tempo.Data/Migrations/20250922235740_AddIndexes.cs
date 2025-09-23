using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Tempo.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddIndexes : Migration
    {
        const string TableName = "Tasks";

        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Tasks_CompletedAt",
                table: TableName,
                column: "CompletedAt"
            );

            migrationBuilder.CreateIndex(
                name: "IX_Tasks_CreatedAt",
                table: TableName,
                column: "CreatedAt"
            );

            migrationBuilder.CreateIndex(name: "IX_Tasks_Order", table: TableName, column: "Order");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(name: "IX_Tasks_CompletedAt", table: TableName);

            migrationBuilder.DropIndex(name: "IX_Tasks_CreatedAt", table: TableName);

            migrationBuilder.DropIndex(name: "IX_Tasks_Order", table: TableName);
        }
    }
}
