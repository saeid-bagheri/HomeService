using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HomeService.Migrations
{
    /// <inheritdoc />
    public partial class ServiceImages : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ServiceId",
                table: "Images",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Images_ServiceId",
                table: "Images",
                column: "ServiceId");

            migrationBuilder.AddForeignKey(
                name: "FK_Images_Services_ServiceId",
                table: "Images",
                column: "ServiceId",
                principalTable: "Services",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Images_Services_ServiceId",
                table: "Images");

            migrationBuilder.DropIndex(
                name: "IX_Images_ServiceId",
                table: "Images");

            migrationBuilder.DropColumn(
                name: "ServiceId",
                table: "Images");
        }
    }
}
