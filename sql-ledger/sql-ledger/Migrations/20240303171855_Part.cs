using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace sqlledger.Migrations
{
    /// <inheritdoc />
    public partial class Part : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "role",
                table: "department",
                type: "char(1)",
                nullable: false,
                defaultValue: "P",
                oldClrType: typeof(string),
                oldType: "char",
                oldDefaultValue: "P");

            migrationBuilder.AlterColumn<string>(
                name: "gender",
                table: "contact",
                type: "char(1)",
                nullable: false,
                defaultValue: "M",
                oldClrType: typeof(string),
                oldType: "char",
                oldDefaultValue: "M");

            migrationBuilder.AlterColumn<string>(
                name: "charttype",
                table: "chart",
                type: "char(1)",
                nullable: false,
                defaultValue: "A",
                oldClrType: typeof(string),
                oldType: "char",
                oldDefaultValue: "A");

            migrationBuilder.AlterColumn<string>(
                name: "category",
                table: "chart",
                type: "char(1)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "char");

            migrationBuilder.CreateTable(
                name: "parts",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false, defaultValueSql: "NEXT VALUE FOR public_id"),
                    partnumber = table.Column<string>(type: "nvarchar(4000)", nullable: true),
                    description = table.Column<string>(type: "nvarchar(4000)", nullable: true),
                    unit = table.Column<string>(type: "nvarchar(5)", maxLength: 5, nullable: true),
                    listprice = table.Column<decimal>(type: "decimal(28,6)", precision: 28, scale: 6, nullable: true),
                    sellprice = table.Column<decimal>(type: "decimal(28,6)", precision: 28, scale: 6, nullable: true),
                    lastcost = table.Column<decimal>(type: "decimal(28,6)", precision: 28, scale: 6, nullable: true),
                    priceupdate = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETUTCDATE()"),
                    weight = table.Column<decimal>(type: "decimal(28,6)", precision: 28, scale: 6, nullable: true),
                    onhand = table.Column<decimal>(type: "decimal(28,6)", precision: 28, scale: 6, nullable: true),
                    notes = table.Column<string>(type: "nvarchar(MAX)", nullable: true),
                    makemodel = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    assembly = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    alternate = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    rop = table.Column<decimal>(type: "decimal(28,6)", precision: 28, scale: 6, nullable: true),
                    inventory_accno_id = table.Column<int>(type: "int", nullable: true),
                    income_accno_id = table.Column<int>(type: "int", nullable: true),
                    expense_accno_id = table.Column<int>(type: "int", nullable: true),
                    bin = table.Column<string>(type: "nvarchar(MAX)", nullable: true),
                    obsolete = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    bom = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    image = table.Column<string>(type: "nvarchar(MAX)", nullable: true),
                    drawing = table.Column<string>(type: "nvarchar(MAX)", nullable: true),
                    microfiche = table.Column<string>(type: "nvarchar(MAX)", nullable: true),
                    partsgroup_id = table.Column<int>(type: "int", nullable: true),
                    project_id = table.Column<int>(type: "int", nullable: true),
                    avgcost = table.Column<decimal>(type: "decimal(28,6)", precision: 28, scale: 6, nullable: true),
                    tariff_hscode = table.Column<string>(type: "nvarchar(MAX)", nullable: true),
                    countryorigin = table.Column<string>(type: "nvarchar(MAX)", nullable: true),
                    barcode = table.Column<string>(type: "nvarchar(MAX)", nullable: true),
                    toolnumber = table.Column<string>(type: "nvarchar(MAX)", nullable: true),
                    lot = table.Column<string>(type: "nvarchar(MAX)", nullable: true),
                    expires = table.Column<DateTime>(type: "datetime2", nullable: false),
                    checkinventory = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    row_version = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: true)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateIndex(
                name: "parts_description_key",
                table: "parts",
                column: "description");

            migrationBuilder.CreateIndex(
                name: "parts_id_key",
                table: "parts",
                column: "id");

            migrationBuilder.CreateIndex(
                name: "parts_partnumber_key",
                table: "parts",
                column: "partnumber");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "parts");

            migrationBuilder.AlterColumn<string>(
                name: "role",
                table: "department",
                type: "char",
                nullable: false,
                defaultValue: "P",
                oldClrType: typeof(string),
                oldType: "char(1)",
                oldDefaultValue: "P");

            migrationBuilder.AlterColumn<string>(
                name: "gender",
                table: "contact",
                type: "char",
                nullable: false,
                defaultValue: "M",
                oldClrType: typeof(string),
                oldType: "char(1)",
                oldDefaultValue: "M");

            migrationBuilder.AlterColumn<string>(
                name: "charttype",
                table: "chart",
                type: "char",
                nullable: false,
                defaultValue: "A",
                oldClrType: typeof(string),
                oldType: "char(1)",
                oldDefaultValue: "A");

            migrationBuilder.AlterColumn<string>(
                name: "category",
                table: "chart",
                type: "char",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "char(1)");
        }
    }
}
