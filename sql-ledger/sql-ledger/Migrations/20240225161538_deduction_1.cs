using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace sqlledger.Migrations
{
    /// <inheritdoc />
    public partial class deduction_1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_deduct_deduction_deduction_id",
                table: "deduct");

            migrationBuilder.DropForeignKey(
                name: "FK_deduct_deductionrate_trans_id",
                table: "deduct");

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

            migrationBuilder.AddForeignKey(
                name: "FK_deduct_deduction_trans_id",
                table: "deduct",
                column: "trans_id",
                principalTable: "deduction",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_deduct_deductionrate_deduction_id",
                table: "deduct",
                column: "deduction_id",
                principalTable: "deductionrate",
                principalColumn: "trans_id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_deduct_deduction_trans_id",
                table: "deduct");

            migrationBuilder.DropForeignKey(
                name: "FK_deduct_deductionrate_deduction_id",
                table: "deduct");

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

            migrationBuilder.AddForeignKey(
                name: "FK_deduct_deduction_deduction_id",
                table: "deduct",
                column: "deduction_id",
                principalTable: "deduction",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_deduct_deductionrate_trans_id",
                table: "deduct",
                column: "trans_id",
                principalTable: "deductionrate",
                principalColumn: "trans_id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
