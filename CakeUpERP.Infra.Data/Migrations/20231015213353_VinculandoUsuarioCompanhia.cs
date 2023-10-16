using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CakeUpERP.Infra.Data.Migrations
{
    public partial class VinculandoUsuarioCompanhia : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_usuario_companhia_CompanhiaId",
                table: "usuario");

            migrationBuilder.DropIndex(
                name: "IX_usuario_CompanhiaId",
                table: "usuario");

            migrationBuilder.DropColumn(
                name: "CompanhiaId",
                table: "usuario");

            migrationBuilder.UpdateData(
                table: "companhia",
                keyColumn: "Id",
                keyValue: 1,
                column: "DataCriacao",
                value: new DateTime(2023, 10, 15, 18, 33, 53, 203, DateTimeKind.Local).AddTicks(9874));

            migrationBuilder.CreateIndex(
                name: "IX_usuario_IdCompanhia",
                table: "usuario",
                column: "IdCompanhia");

            migrationBuilder.AddForeignKey(
                name: "FK_usuario_companhia_IdCompanhia",
                table: "usuario",
                column: "IdCompanhia",
                principalTable: "companhia",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_usuario_companhia_IdCompanhia",
                table: "usuario");

            migrationBuilder.DropIndex(
                name: "IX_usuario_IdCompanhia",
                table: "usuario");

            migrationBuilder.AddColumn<int>(
                name: "CompanhiaId",
                table: "usuario",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "companhia",
                keyColumn: "Id",
                keyValue: 1,
                column: "DataCriacao",
                value: new DateTime(2023, 10, 12, 1, 40, 27, 661, DateTimeKind.Local).AddTicks(1702));

            migrationBuilder.CreateIndex(
                name: "IX_usuario_CompanhiaId",
                table: "usuario",
                column: "CompanhiaId");

            migrationBuilder.AddForeignKey(
                name: "FK_usuario_companhia_CompanhiaId",
                table: "usuario",
                column: "CompanhiaId",
                principalTable: "companhia",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
