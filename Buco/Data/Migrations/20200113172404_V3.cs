using Microsoft.EntityFrameworkCore.Migrations;

namespace Buco.Data.Migrations
{
    public partial class V3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ActivityEntries_ActivityTypes_ActivityTypeId",
                table: "ActivityEntries");

            migrationBuilder.DropForeignKey(
                name: "FK_ActivityEntries_Pets_PetId",
                table: "ActivityEntries");

            migrationBuilder.DropForeignKey(
                name: "FK_MealEntries_Pets_PetId",
                table: "MealEntries");

            migrationBuilder.DropForeignKey(
                name: "FK_Pets_PetTypes_PetTypeId",
                table: "Pets");

            migrationBuilder.DropForeignKey(
                name: "FK_Pets_AspNetUsers_UserId",
                table: "Pets");

            migrationBuilder.DropForeignKey(
                name: "FK_WeightEntries_Pets_PetId",
                table: "WeightEntries");

            migrationBuilder.AddForeignKey(
                name: "FK_ActivityEntries_ActivityTypes_ActivityTypeId",
                table: "ActivityEntries",
                column: "ActivityTypeId",
                principalTable: "ActivityTypes",
                principalColumn: "ActivityTypeId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ActivityEntries_Pets_PetId",
                table: "ActivityEntries",
                column: "PetId",
                principalTable: "Pets",
                principalColumn: "PetId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_MealEntries_Pets_PetId",
                table: "MealEntries",
                column: "PetId",
                principalTable: "Pets",
                principalColumn: "PetId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Pets_PetTypes_PetTypeId",
                table: "Pets",
                column: "PetTypeId",
                principalTable: "PetTypes",
                principalColumn: "PetTypeId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Pets_AspNetUsers_UserId",
                table: "Pets",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_WeightEntries_Pets_PetId",
                table: "WeightEntries",
                column: "PetId",
                principalTable: "Pets",
                principalColumn: "PetId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ActivityEntries_ActivityTypes_ActivityTypeId",
                table: "ActivityEntries");

            migrationBuilder.DropForeignKey(
                name: "FK_ActivityEntries_Pets_PetId",
                table: "ActivityEntries");

            migrationBuilder.DropForeignKey(
                name: "FK_MealEntries_Pets_PetId",
                table: "MealEntries");

            migrationBuilder.DropForeignKey(
                name: "FK_Pets_PetTypes_PetTypeId",
                table: "Pets");

            migrationBuilder.DropForeignKey(
                name: "FK_Pets_AspNetUsers_UserId",
                table: "Pets");

            migrationBuilder.DropForeignKey(
                name: "FK_WeightEntries_Pets_PetId",
                table: "WeightEntries");

            migrationBuilder.AddForeignKey(
                name: "FK_ActivityEntries_ActivityTypes_ActivityTypeId",
                table: "ActivityEntries",
                column: "ActivityTypeId",
                principalTable: "ActivityTypes",
                principalColumn: "ActivityTypeId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ActivityEntries_Pets_PetId",
                table: "ActivityEntries",
                column: "PetId",
                principalTable: "Pets",
                principalColumn: "PetId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_MealEntries_Pets_PetId",
                table: "MealEntries",
                column: "PetId",
                principalTable: "Pets",
                principalColumn: "PetId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Pets_PetTypes_PetTypeId",
                table: "Pets",
                column: "PetTypeId",
                principalTable: "PetTypes",
                principalColumn: "PetTypeId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Pets_AspNetUsers_UserId",
                table: "Pets",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_WeightEntries_Pets_PetId",
                table: "WeightEntries",
                column: "PetId",
                principalTable: "Pets",
                principalColumn: "PetId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
