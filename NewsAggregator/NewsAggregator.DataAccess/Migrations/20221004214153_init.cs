﻿using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NewsAggregator.DataAccess.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Username = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsAdmin = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "User",
                columns: new[] { "Id", "Email", "FirstName", "IsAdmin", "LastName", "Password", "Username" },
                values: new object[,]
                {
                    { 1, "bob@email.com", "Bob", false, "Bobsky", "H,?????mI??I8", "bBobsky" },
                    { 2, "john.doe@email.com", "Jon", false, "Doe", "H,?????mI??I8", "jDoe" },
                    { 3, "tom@admin.com", "Tom", true, "Admin", "?:{?s%?i?? ", "adminTon" },
                    { 4, "jill@admin.com", "Jill", true, "Admin", "?:{?s%?i?? ", "adminJill" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "User");
        }
    }
}
