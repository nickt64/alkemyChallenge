﻿using Microsoft.EntityFrameworkCore.Migrations;

namespace AlkemyChallenge.Migrations
{
    public partial class PersonajePeso : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Peso",
                table: "Personajes",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Peso",
                table: "Personajes");
        }
    }
}
