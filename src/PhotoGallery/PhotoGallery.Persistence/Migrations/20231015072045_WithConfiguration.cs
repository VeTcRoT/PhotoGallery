using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PhotoGallery.Persistence.Migrations
{
    public partial class WithConfiguration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Rates_ImageId",
                table: "Rates");

            migrationBuilder.CreateIndex(
                name: "IX_Rates_ImageId_UserId",
                table: "Rates",
                columns: new[] { "ImageId", "UserId" },
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Rates_ImageId_UserId",
                table: "Rates");

            migrationBuilder.CreateIndex(
                name: "IX_Rates_ImageId",
                table: "Rates",
                column: "ImageId");
        }
    }
}
