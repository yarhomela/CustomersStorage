﻿using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CustomerStorage.DataAccessLayer.Migrations
{
    /// <inheritdoc />
    public partial class RemoveNullableFieldName : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Customers",
                type: "nvarchar(150)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(150)",
                oldNullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Customers",
                type: "nvarchar(150)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(150)");
        }
    }
}
