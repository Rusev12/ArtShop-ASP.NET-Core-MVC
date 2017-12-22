using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace ArtShop.Data.Migrations
{
    public partial class ChangePropertyName : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "IssAvailable",
                table: "ArtProducts",
                newName: "IsAvailable");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "IsAvailable",
                table: "ArtProducts",
                newName: "IssAvailable");
        }
    }
}
