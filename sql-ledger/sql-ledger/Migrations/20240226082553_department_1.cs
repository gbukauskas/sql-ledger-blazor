using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace sqlledger.Migrations
{
    /// <inheritdoc />
    public partial class department_1 : Migration
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

            migrationBuilder.AlterColumn<int>(
                name: "rn",
                table: "department",
                type: "int",
                nullable: true,
                oldClrType: typeof(short),
                oldType: "smallint",
                oldNullable: true);

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
            migrationBuilder.AlterColumn<string>(
                name: "role",
                table: "department",
                type: "char",
                nullable: false,
                defaultValue: "P",
                oldClrType: typeof(string),
                oldType: "char(1)",
                oldDefaultValue: "P");

            migrationBuilder.AlterColumn<short>(
                name: "rn",
                table: "department",
                type: "smallint",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

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
