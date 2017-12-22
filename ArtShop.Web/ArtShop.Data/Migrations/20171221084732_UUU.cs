using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace ArtShop.Data.Migrations
{
    public partial class UUU : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ArtProducts_AspNetUsers_CustomerId",
                table: "ArtProducts");

            migrationBuilder.AddForeignKey(
                name: "FK_ArtProducts_AspNetUsers_CustomerId",
                table: "ArtProducts",
                column: "CustomerId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ArtProducts_AspNetUsers_CustomerId",
                table: "ArtProducts");

            migrationBuilder.AddForeignKey(
                name: "FK_ArtProducts_AspNetUsers_CustomerId",
                table: "ArtProducts",
                column: "CustomerId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
