using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace sqlledger.Migrations
{
    /// <inheritdoc />
    public partial class Part_2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<decimal>(
                name: "onhand",
                table: "parts",
                type: "decimal(28,6)",
                precision: 28,
                scale: 6,
                nullable: false,
                defaultValue: 0m,
                oldClrType: typeof(decimal),
                oldType: "decimal(28,6)",
                oldPrecision: 28,
                oldScale: 6,
                oldNullable: true);

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
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<decimal>(
                name: "onhand",
                table: "parts",
                type: "decimal(28,6)",
                precision: 28,
                scale: 6,
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "decimal(28,6)",
                oldPrecision: 28,
                oldScale: 6,
                oldDefaultValue: 0m);

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
