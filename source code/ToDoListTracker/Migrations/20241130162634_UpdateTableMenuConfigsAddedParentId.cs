﻿using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Web.Migrations
{
    /// <inheritdoc />
    public partial class UpdateTableMenuConfigsAddedParentId : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ParentId",
                table: "MenuConfigs",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ParentId",
                table: "MenuConfigs");
        }
    }
}
