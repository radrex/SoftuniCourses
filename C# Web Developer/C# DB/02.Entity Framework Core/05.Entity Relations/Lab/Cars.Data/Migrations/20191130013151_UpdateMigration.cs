using Microsoft.EntityFrameworkCore.Migrations;

namespace Cars.Data.Migrations
{
    public partial class UpdateMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CarDealerships_Cars_CarId",
                table: "CarDealerships");

            migrationBuilder.DropForeignKey(
                name: "FK_CarDealerships_Dealerships_DealershipId",
                table: "CarDealerships");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CarDealerships",
                table: "CarDealerships");

            migrationBuilder.RenameTable(
                name: "CarDealerships",
                newName: "CarsDealerships");

            migrationBuilder.RenameIndex(
                name: "IX_CarDealerships_DealershipId",
                table: "CarsDealerships",
                newName: "IX_CarsDealerships_DealershipId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CarsDealerships",
                table: "CarsDealerships",
                columns: new[] { "CarId", "DealershipId" });

            migrationBuilder.AddForeignKey(
                name: "FK_CarsDealerships_Cars_CarId",
                table: "CarsDealerships",
                column: "CarId",
                principalTable: "Cars",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CarsDealerships_Dealerships_DealershipId",
                table: "CarsDealerships",
                column: "DealershipId",
                principalTable: "Dealerships",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CarsDealerships_Cars_CarId",
                table: "CarsDealerships");

            migrationBuilder.DropForeignKey(
                name: "FK_CarsDealerships_Dealerships_DealershipId",
                table: "CarsDealerships");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CarsDealerships",
                table: "CarsDealerships");

            migrationBuilder.RenameTable(
                name: "CarsDealerships",
                newName: "CarDealerships");

            migrationBuilder.RenameIndex(
                name: "IX_CarsDealerships_DealershipId",
                table: "CarDealerships",
                newName: "IX_CarDealerships_DealershipId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CarDealerships",
                table: "CarDealerships",
                columns: new[] { "CarId", "DealershipId" });

            migrationBuilder.AddForeignKey(
                name: "FK_CarDealerships_Cars_CarId",
                table: "CarDealerships",
                column: "CarId",
                principalTable: "Cars",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CarDealerships_Dealerships_DealershipId",
                table: "CarDealerships",
                column: "DealershipId",
                principalTable: "Dealerships",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
