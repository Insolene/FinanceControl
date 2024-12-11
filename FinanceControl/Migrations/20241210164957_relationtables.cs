using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FinanceControl.Migrations
{
    /// <inheritdoc />
    public partial class relationtables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Transactions_Categories_CategoryEntitiesId",
                table: "Transactions");

            migrationBuilder.DropForeignKey(
                name: "FK_Users_Transactions_transactionId",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_Users_transactionId",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_Transactions_CategoryEntitiesId",
                table: "Transactions");

            migrationBuilder.DropColumn(
                name: "transactionId",
                table: "Users");

            migrationBuilder.RenameColumn(
                name: "CategoryEntitiesId",
                table: "Transactions",
                newName: "UserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "Transactions",
                newName: "CategoryEntitiesId");

            migrationBuilder.AddColumn<int>(
                name: "transactionId",
                table: "Users",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Users_transactionId",
                table: "Users",
                column: "transactionId");

            migrationBuilder.CreateIndex(
                name: "IX_Transactions_CategoryEntitiesId",
                table: "Transactions",
                column: "CategoryEntitiesId");

            migrationBuilder.AddForeignKey(
                name: "FK_Transactions_Categories_CategoryEntitiesId",
                table: "Transactions",
                column: "CategoryEntitiesId",
                principalTable: "Categories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Transactions_transactionId",
                table: "Users",
                column: "transactionId",
                principalTable: "Transactions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
