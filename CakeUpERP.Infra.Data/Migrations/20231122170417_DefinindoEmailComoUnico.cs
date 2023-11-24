using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CakeUpERP.Infra.Data.Migrations
{
    public partial class DefinindoEmailComoUnico : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "usuario",
                type: "varchar(255)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(256)",
                oldMaxLength: 256)
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.UpdateData(
                table: "companhia",
                keyColumn: "Id",
                keyValue: 1,
                column: "DataCriacao",
                value: new DateTime(2023, 11, 22, 14, 4, 16, 690, DateTimeKind.Local).AddTicks(966));

            migrationBuilder.CreateIndex(
                name: "IX_usuario_Email",
                table: "usuario",
                column: "Email",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_usuario_Email",
                table: "usuario");

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "usuario",
                type: "varchar(256)",
                maxLength: 256,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(255)")
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.UpdateData(
                table: "companhia",
                keyColumn: "Id",
                keyValue: 1,
                column: "DataCriacao",
                value: new DateTime(2023, 10, 15, 18, 33, 53, 203, DateTimeKind.Local).AddTicks(9874));
        }
    }
}
