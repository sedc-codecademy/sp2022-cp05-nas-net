using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NewsAggregator.DataAccess.Migrations
{
    public partial class delete_user_fk_approval_rating : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_User_ApprovalRatings_ApprovalRatingId",
                table: "User");

            migrationBuilder.DropForeignKey(
                name: "FK_User_ApprovalRatings_ApprovalRatingId1",
                table: "User");

            migrationBuilder.DropIndex(
                name: "IX_User_ApprovalRatingId",
                table: "User");

            migrationBuilder.DropIndex(
                name: "IX_User_ApprovalRatingId1",
                table: "User");

            migrationBuilder.DropColumn(
                name: "ApprovalRatingId",
                table: "User");

            migrationBuilder.DropColumn(
                name: "ApprovalRatingId1",
                table: "User");

            migrationBuilder.UpdateData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: 1,
                column: "DatePublished",
                value: new DateTime(2022, 10, 6, 17, 4, 29, 804, DateTimeKind.Local).AddTicks(2827));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ApprovalRatingId",
                table: "User",
                type: "int",
                nullable: true);

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
                name: "IX_User_ApprovalRatingId",
                table: "User",
                column: "ApprovalRatingId");

            migrationBuilder.CreateIndex(
                name: "IX_User_ApprovalRatingId1",
                table: "User",
                column: "ApprovalRatingId1");

            migrationBuilder.AddForeignKey(
                name: "FK_User_ApprovalRatings_ApprovalRatingId",
                table: "User",
                column: "ApprovalRatingId",
                principalTable: "ApprovalRatings",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_User_ApprovalRatings_ApprovalRatingId1",
                table: "User",
                column: "ApprovalRatingId1",
                principalTable: "ApprovalRatings",
                principalColumn: "Id");
        }
    }
}
