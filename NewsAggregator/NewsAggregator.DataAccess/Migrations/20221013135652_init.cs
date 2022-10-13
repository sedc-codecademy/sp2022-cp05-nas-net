using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NewsAggregator.DataAccess.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Ad",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AdName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BannerImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RedirectUrl = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsAdActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ad", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Category",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Category", x => x.Id);
                });

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

            migrationBuilder.CreateTable(
                name: "Article",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    OriginalArticleUrl = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SourceUrl = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SourceLogo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CategoryId = table.Column<int>(type: "int", nullable: false),
                    DatePublished = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Article", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Article_Category_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Category",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RSSFeed",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FeedUrl = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    CategoryId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RSSFeed", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RSSFeed_Category_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Category",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Comment",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Content = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ArticleId = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Comment", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Comment_Article_ArticleId",
                        column: x => x.ArticleId,
                        principalTable: "Article",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Comment_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Ad",
                columns: new[] { "Id", "AdName", "BannerImageUrl", "ImageUrl", "IsAdActive", "RedirectUrl" },
                values: new object[,]
                {
                    { 1, "Netflix", "https://res.cloudinary.com/practicaldev/image/fetch/s--THrf5Yjw--/c_imagga_scale,f_auto,fl_progressive,h_420,q_auto,w_1000/https://dev-to-uploads.s3.amazonaws.com/uploads/articles/n6brz4p7iq7j1mulo1nv.jpg", "https://variety.com/wp-content/uploads/2019/03/netflix-logo-n-icon.png", true, "https://www.netflix.com" },
                    { 2, "Hbo", "https://cdnb.artstation.com/p/assets/images/images/027/198/593/large/mikhail-villarreal-bannerhbodceu-byalde.jpg?1590863405", "https://s3.amazonaws.com/media.mediapost.com/dam/cropped/2021/06/02/hbomax-plansstartat999-600_4vXDoJJ.jpg", true, "https://www.hbomax.com/" },
                    { 3, "Nike", "https://uploads-ssl.webflow.com/5e72757e442fcb191b4823c0/5ea8b5ddeffbba465d0d010f_nike-lunar3.jpg", "https://www.marketing91.com/wp-content/uploads/2020/06/Growth-of-Nike-Advertising.jpg", true, "https://www.nike.com/" },
                    { 4, "Razer Huntsman V2", "https://assets2.razerzone.com/images/pnx.assets/1ab71e5ea9f9b8db8fc014cf8d767732/razer-huntsman-v2-hero-desktop.jpg", "https://g-h.sgp1.digitaloceanspaces.com/wp-content/uploads/2021/10/11105246/RAZER-LANDING-PAGE_1TOP-BANNER-MOB-copy-5-800x800.png", true, "https://www.razer.com/gaming-keyboards/razer-huntsman-v2" },
                    { 5, "WizzAir", "https://pbs.twimg.com/media/DdT-s6NW4AAEOEi.jpg", "https://mir-s3-cdn-cf.behance.net/project_modules/max_1200/d9b02f1619767.560d88eed515a.jpg", true, "https://wizzair.com/en-gb" },
                    { 6, "Asus ROG strix", "https://dlcdnwebimgs.asus.com/gain/F9741FD2-725D-4134-B0EB-C3E6F0FA7FF0/fwebp", "https://cdn.dribbble.com/users/5349551/screenshots/12021171/media/99c46cd52abd90cf754f5d0bba81f08b.png?compress=1&resize=400x300", true, "https://rog.asus.com/my/laptops/rog-strix/rog-strix-scar-17-2022-series/" }
                });

            migrationBuilder.InsertData(
                table: "Category",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Politics" },
                    { 2, "Business" },
                    { 3, "Science" },
                    { 4, "Tech" },
                    { 5, "Gaming" },
                    { 6, "Showbiz" },
                    { 7, "Sport" },
                    { 8, "Other" }
                });

            migrationBuilder.InsertData(
                table: "User",
                columns: new[] { "Id", "Email", "FirstName", "IsAdmin", "LastName", "Password", "Username" },
                values: new object[,]
                {
                    { 1, "bob@email.com", "Bob", false, "Bobsky", "H,?????mI??I8", "bBobsky" },
                    { 2, "john.doe@email.com", "Jon", false, "Doe", "H,?????mI??I8", "jDoe" },
                    { 3, "tom@admin.com", "Tom", true, "Admin", "?:{?s%?i?? ", "adminTom" },
                    { 4, "jill@admin.com", "Jill", true, "Admin", "?:{?s%?i?? ", "adminJill" }
                });

            migrationBuilder.InsertData(
                table: "RSSFeed",
                columns: new[] { "Id", "CategoryId", "FeedUrl", "IsActive", "Name" },
                values: new object[,]
                {
                    { 1, 1, "https://moxie.foxnews.com/google-publisher/politics.xml", true, "Fox news - bussines" },
                    { 2, 3, "https://moxie.foxnews.com/google-publisher/science.xml", true, "Fox news - science" },
                    { 3, 4, "https://moxie.foxnews.com/google-publisher/tech.xml", true, "Fox news - technology" },
                    { 4, 7, "https://moxie.foxnews.com/google-publisher/sports.xml", true, "Fox news - sports" },
                    { 5, 8, " https://moxie.foxnews.com/google-publisher/travel.xml", true, "Fox news - travel" },
                    { 6, 8, " https://moxie.foxnews.com/google-publisher/health.xml", true, "Fox news - health" },
                    { 7, 2, "https://rss.nytimes.com/services/xml/rss/nyt/Business.xml", true, "New York Times - bussines" },
                    { 8, 3, "https://rss.nytimes.com/services/xml/rss/nyt/Science.xml", true, "New York Times - science" },
                    { 9, 4, "https://rss.nytimes.com/services/xml/rss/nyt/Technology.xml", true, "New York Times - tehcnology" },
                    { 10, 7, "https://rss.nytimes.com/services/xml/rss/nyt/Sports.xml", true, "New York Times - sports" },
                    { 11, 8, "https://rss.nytimes.com/services/xml/rss/nyt/Health.xml", true, "New York Times - health" },
                    { 12, 8, "https://rss.nytimes.com/services/xml/rss/nyt/Travel.xml", true, "New York Times - travel" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Article_CategoryId",
                table: "Article",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Comment_ArticleId",
                table: "Comment",
                column: "ArticleId");

            migrationBuilder.CreateIndex(
                name: "IX_Comment_UserId",
                table: "Comment",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_RSSFeed_CategoryId",
                table: "RSSFeed",
                column: "CategoryId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Ad");

            migrationBuilder.DropTable(
                name: "Comment");

            migrationBuilder.DropTable(
                name: "RSSFeed");

            migrationBuilder.DropTable(
                name: "Article");

            migrationBuilder.DropTable(
                name: "User");

            migrationBuilder.DropTable(
                name: "Category");
        }
    }
}
