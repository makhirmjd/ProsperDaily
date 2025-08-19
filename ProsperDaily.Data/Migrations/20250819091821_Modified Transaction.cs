using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProsperDaily.Data.Migrations
{
    /// <inheritdoc />
    public partial class ModifiedTransaction : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "OperationDate",
                table: "Transactions",
                newName: "TransactionDate");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "TransactionDate",
                table: "Transactions",
                newName: "OperationDate");
        }
    }
}
