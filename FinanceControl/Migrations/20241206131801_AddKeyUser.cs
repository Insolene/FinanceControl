using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FinanceControl.Migrations
{
    /// <inheritdoc />
    public partial class AddKeyUser : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Users_Transactions_TransactionEntitiesId",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_Users_TransactionEntitiesId",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "TransactionEntitiesId",
                table: "Users");

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

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Transactions_transactionId",
                table: "Users",
                column: "transactionId",
                principalTable: "Transactions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Users_Transactions_transactionId",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_Users_transactionId",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "transactionId",
                table: "Users");

            migrationBuilder.AddColumn<int>(
                name: "TransactionEntitiesId",
                table: "Users",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Users_TransactionEntitiesId",
                table: "Users",
                column: "TransactionEntitiesId");

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Transactions_TransactionEntitiesId",
                table: "Users",
                column: "TransactionEntitiesId",
                principalTable: "Transactions",
                principalColumn: "Id");
        }
    }
}
