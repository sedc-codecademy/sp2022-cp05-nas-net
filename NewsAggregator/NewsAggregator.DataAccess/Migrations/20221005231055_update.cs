using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NewsAggregator.DataAccess.Migrations
{
    public partial class update : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ApprovalRatingId1",
                table: "User",
                type: "int",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: 1,
                column: "DatePublished",
                value: new DateTime(2022, 10, 6, 1, 10, 54, 561, DateTimeKind.Local).AddTicks(6906));

            migrationBuilder.CreateIndex(
                name: "IX_User_ApprovalRatingId1",
                table: "User",
                column: "ApprovalRatingId1");

            migrationBuilder.AddForeignKey(
                name: "FK_User_ApprovalRatings_ApprovalRatingId1",
                table: "User",
                column: "ApprovalRatingId1",
                principalTable: "ApprovalRatings",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_User_ApprovalRatings_ApprovalRatingId1",
                table: "User");

            migrationBuilder.DropIndex(
                name: "IX_User_ApprovalRatingId1",
                table: "User");

            migrationBuilder.DropColumn(
                name: "ApprovalRatingId1",
                table: "User");

            migrationBuilder.UpdateData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: 1,
                column: "DatePublished",
                value: new DateTime(2022, 10, 5, 21, 18, 19, 471, DateTimeKind.Local).AddTicks(1494));
        }
    }
}
