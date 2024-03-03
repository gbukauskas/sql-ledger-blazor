using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace sqlledger.Migrations
{
    /// <inheritdoc />
    public partial class Oe : Migration
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
                name: "mimetype",
                columns: table => new
                {
                    extension = table.Column<string>(type: "nvarchar(32)", maxLength: 32, nullable: false),
                    contenttype = table.Column<string>(type: "nvarchar(64)", nullable: true),
                    row_version = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("mimetypr_pkey", x => x.extension);
                });

            migrationBuilder.CreateTable(
                name: "oe",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false, defaultValueSql: "NEXT VALUE FOR public_id"),
                    ordnumber = table.Column<string>(type: "nvarchar(4000)", nullable: true),
                    transdate = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETUTCDATE()"),
                    vendor_id = table.Column<int>(type: "int", nullable: true),
                    customer_id = table.Column<int>(type: "int", nullable: true),
                    amount = table.Column<decimal>(type: "decimal(28,6)", precision: 28, scale: 6, nullable: true),
                    netamount = table.Column<decimal>(type: "decimal(28,6)", precision: 28, scale: 6, nullable: true),
                    reqdate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    taxincluded = table.Column<bool>(type: "bit", nullable: false),
                    shippingpoint = table.Column<string>(type: "nvarchar(MAX)", nullable: true),
                    notes = table.Column<string>(type: "nvarchar(MAX)", nullable: true),
                    curr = table.Column<string>(type: "char(3)", maxLength: 3, nullable: true),
                    employee_id = table.Column<int>(type: "int", nullable: true),
                    closed = table.Column<bool>(type: "bit", nullable: true, defaultValue: false),
                    quotation = table.Column<bool>(type: "bit", nullable: true, defaultValue: false),
                    quonumber = table.Column<string>(type: "nvarchar(4000)", nullable: true),
                    intnotes = table.Column<string>(type: "nvarchar(MAX)", nullable: true),
                    department_id = table.Column<int>(type: "int", nullable: true, defaultValue: 0),
                    shipvia = table.Column<string>(type: "nvarchar(MAX)", nullable: true),
                    language_code = table.Column<string>(type: "nvarchar(6)", maxLength: 6, nullable: true),
                    ponumber = table.Column<string>(type: "nvarchar(MAX)", nullable: true),
                    terms = table.Column<short>(type: "smallint", nullable: false, defaultValue: (short)0),
                    waybill = table.Column<string>(type: "nvarchar(MAX)", nullable: true),
                    warehouse_id = table.Column<int>(type: "int", nullable: true),
                    description = table.Column<string>(type: "nvarchar(MAX)", nullable: true),
                    aa_id = table.Column<int>(type: "int", nullable: true),
                    exchangerate = table.Column<double>(type: "float", nullable: true),
                    backorder = table.Column<bool>(type: "bit", nullable: true, defaultValue: false),
                    row_version = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: true)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateIndex(
                name: "oe_employee_id_key",
                table: "oe",
                column: "employee_id");

            migrationBuilder.CreateIndex(
                name: "oe_id_key",
                table: "oe",
                column: "id");

            migrationBuilder.CreateIndex(
                name: "oe_ordnumber_key",
                table: "oe",
                column: "ordnumber");

            migrationBuilder.CreateIndex(
                name: "oe_transdate_key",
                table: "oe",
                column: "transdate");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "mimetype");

            migrationBuilder.DropTable(
                name: "oe");

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
