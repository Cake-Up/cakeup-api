using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CakeUpERP.Infra.Data.Migrations
{
    public partial class AjustandoCriacaoCompanhia : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropUniqueConstraint(
                name: "AK_companhia_Cnpj",
                table: "companhia");

            migrationBuilder.AlterColumn<string>(
                name: "Cnpj",
                table: "companhia",
                type: "varchar(14)",
                maxLength: 14,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(14)",
                oldMaxLength: 14)
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.UpdateData(
                table: "companhia",
                keyColumn: "Id",
                keyValue: 1,
                column: "DataCriacao",
                value: new DateTime(2023, 5, 10, 23, 34, 7, 456, DateTimeKind.Local).AddTicks(6364));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "companhia",
                keyColumn: "Cnpj",
                keyValue: null,
                column: "Cnpj",
                value: "");

            migrationBuilder.AlterColumn<string>(
                name: "Cnpj",
                table: "companhia",
                type: "varchar(14)",
                maxLength: 14,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(14)",
                oldMaxLength: 14,
                oldNullable: true)
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddUniqueConstraint(
                name: "AK_companhia_Cnpj",
                table: "companhia",
                column: "Cnpj");

            migrationBuilder.UpdateData(
                table: "companhia",
                keyColumn: "Id",
                keyValue: 1,
                column: "DataCriacao",
                value: new DateTime(2023, 5, 10, 23, 23, 32, 710, DateTimeKind.Local).AddTicks(8477));
        }
    }
}
