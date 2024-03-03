using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace sqlledger.Migrations
{
    /// <inheritdoc />
    public partial class OrderItem : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateSequence<int>(
                name: "orderitems_id");

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
                name: "orderitems",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false, defaultValueSql: "NEXT VALUE FOR orderitems_id"),
                    trans_id = table.Column<int>(type: "int", nullable: true),
                    parts_id = table.Column<int>(type: "int", nullable: true),
                    description = table.Column<string>(type: "nvarchar(MAX)", nullable: true),
                    qty = table.Column<decimal>(type: "decimal(28,6)", precision: 28, scale: 6, nullable: true),
                    sellprice = table.Column<decimal>(type: "decimal(28,6)", precision: 28, scale: 6, nullable: true),
                    discount = table.Column<float>(type: "real", nullable: true),
                    unit = table.Column<string>(type: "nvarchar(5)", maxLength: 5, nullable: true),
                    project_id = table.Column<int>(type: "int", nullable: true),
                    reqdate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ship = table.Column<decimal>(type: "decimal(28,6)", precision: 28, scale: 6, nullable: true),
                    serialnumber = table.Column<string>(type: "nvarchar(MAX)", nullable: true),
                    itemnotes = table.Column<string>(type: "nvarchar(MAX)", nullable: true),
                    lineitemdetail = table.Column<bool>(type: "bit", nullable: true),
                    ordernumber = table.Column<string>(type: "nvarchar(MAX)", nullable: true),
                    ponumber = table.Column<string>(type: "nvarchar(MAX)", nullable: true),
                    cost = table.Column<decimal>(type: "decimal(28,6)", precision: 28, scale: 6, nullable: true),
                    vendor = table.Column<string>(type: "nvarchar(MAX)", nullable: true),
                    vendor_id = table.Column<int>(type: "int", nullable: true),
                    row_version = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("orderitems_id_pkey", x => x.id);
                });

            migrationBuilder.CreateIndex(
                name: "orderitems_trans_id_key",
                table: "orderitems",
                column: "trans_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "orderitems");

            migrationBuilder.DropSequence(
                name: "orderitems_id");

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
