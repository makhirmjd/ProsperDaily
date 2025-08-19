using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProsperDaily.Data.Migrations
{
    /// <inheritdoc />
    public partial class ChangedDateTimeGenerationStrategy : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTimeOffset>(
                name: "LastModified",
                table: "Transactions",
                type: "TEXT",
                nullable: false,
                defaultValueSql: "datetime('now')",
                oldClrType: typeof(DateTimeOffset),
                oldType: "TEXT",
                oldDefaultValueSql: "getutcdate()");

            migrationBuilder.AlterColumn<DateTimeOffset>(
                name: "Created",
                table: "Transactions",
                type: "TEXT",
                nullable: false,
                defaultValueSql: "datetime('now')",
                oldClrType: typeof(DateTimeOffset),
                oldType: "TEXT",
                oldDefaultValueSql: "getutcdate()");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTimeOffset>(
                name: "LastModified",
                table: "Transactions",
                type: "TEXT",
                nullable: false,
                defaultValueSql: "getutcdate()",
                oldClrType: typeof(DateTimeOffset),
                oldType: "TEXT",
                oldDefaultValueSql: "datetime('now')");

            migrationBuilder.AlterColumn<DateTimeOffset>(
                name: "Created",
                table: "Transactions",
                type: "TEXT",
                nullable: false,
                defaultValueSql: "getutcdate()",
                oldClrType: typeof(DateTimeOffset),
                oldType: "TEXT",
                oldDefaultValueSql: "datetime('now')");
        }
    }
}
