using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace welcome_api.Migrations
{
    /// <inheritdoc />
    public partial class Topar : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ToparId",
                table: "Students",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Toparlar",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Toparlar", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Students_ToparId",
                table: "Students",
                column: "ToparId");

            migrationBuilder.AddForeignKey(
                name: "FK_Students_Toparlar_ToparId",
                table: "Students",
                column: "ToparId",
                principalTable: "Toparlar",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Students_Toparlar_ToparId",
                table: "Students");

            migrationBuilder.DropTable(
                name: "Toparlar");

            migrationBuilder.DropIndex(
                name: "IX_Students_ToparId",
                table: "Students");

            migrationBuilder.DropColumn(
                name: "ToparId",
                table: "Students");
        }
    }
}
