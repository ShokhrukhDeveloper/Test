using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Test.Api.Migrations
{
    /// <inheritdoc />
    public partial class initial2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Answers_Options_SelectedOpionId",
                table: "Answers");

            migrationBuilder.DropIndex(
                name: "IX_Answers_SelectedOpionId",
                table: "Answers");

            migrationBuilder.DropColumn(
                name: "SelectedOpionId",
                table: "Answers");

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Tests",
                type: "varchar(2048)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldMaxLength: 1023);

            migrationBuilder.AlterColumn<int>(
                name: "OpionId",
                table: "Answers",
                type: "integer",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "INTEGER");

            migrationBuilder.CreateIndex(
                name: "IX_Answers_OpionId",
                table: "Answers",
                column: "OpionId");

            migrationBuilder.AddForeignKey(
                name: "FK_Answers_Options_OpionId",
                table: "Answers",
                column: "OpionId",
                principalTable: "Options",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Answers_Options_OpionId",
                table: "Answers");

            migrationBuilder.DropIndex(
                name: "IX_Answers_OpionId",
                table: "Answers");

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Tests",
                type: "TEXT",
                maxLength: 1023,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(2048)");

            migrationBuilder.AlterColumn<int>(
                name: "OpionId",
                table: "Answers",
                type: "INTEGER",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AddColumn<int>(
                name: "SelectedOpionId",
                table: "Answers",
                type: "integer",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Answers_SelectedOpionId",
                table: "Answers",
                column: "SelectedOpionId");

            migrationBuilder.AddForeignKey(
                name: "FK_Answers_Options_SelectedOpionId",
                table: "Answers",
                column: "SelectedOpionId",
                principalTable: "Options",
                principalColumn: "Id");
        }
    }
}
