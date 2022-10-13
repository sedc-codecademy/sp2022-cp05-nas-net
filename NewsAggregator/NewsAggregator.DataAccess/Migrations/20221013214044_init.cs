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
                    { 6, "Asus ROG strix", "https://dlcdnwebimgs.asus.com/gain/F9741FD2-725D-4134-B0EB-C3E6F0FA7FF0/fwebp", "https://cdn.dribbble.com/users/5349551/screenshots/12021171/media/99c46cd52abd90cf754f5d0bba81f08b.png?compress=1&resize=400x300", true, "https://rog.asus.com/my/laptops/rog-strix/rog-strix-scar-17-2022-series/" },
                    { 7, "Plural Sight", "https://www.sec.gov/Archives/edgar/data/1725579/000162828019002420/pluralsightlogob01.jpg", "https://hmgstrategy1.blob.core.windows.net/hmgfiles/images/default-source/default-album/29482-17_pluralsightad_bl_vf48e7ddc52aed6fb2b0cbff05006a1c82.jpg?sfvrsn=9d0ab2f5_0", true, "https://www.pluralsight.com" },
                    { 8, "Seavus Education and Development Center", "https://www.cpdstandards.com/wp-content/uploads/2021/08/SEDC-Logo.png", "https://masit.org.mk/wp-content/uploads/2019/12/sedc.jpg", true, "https://www.sedc.mk/" },
                    { 9, "Spotify", "https://www.techadvisor.com/wp-content/uploads/2022/06/best-spotify-tips-and-tricks-banner.png", "https://static-prod.adweek.com/wp-content/uploads/2022/01/spotify-podcast-ads-cta-2022-652x342.jpg", true, "https://open.spotify.com/" },
                    { 10, "IPhone 14 Pro", "https://store.storeimages.cdn-apple.com/4982/as-images.apple.com/is/iphone-14-model-unselect-gallery-2-202209_FMT_WHH?wid=1280&hei=492&fmt=p-jpg&qlt=80&.v=1660745126020", "https://www.apple.com/newsroom/images/product/iphone/standard/Apple-iPhone-14-Pro-iPhone-14-Pro-Max-hero-220907.jpg.og.jpg?202209271408", true, "https://www.apple.com/iphone-14-pro/" },
                    { 11, "Unity", "https://1000logos.net/wp-content/uploads/2021/10/Unity-logo.png", "https://eu-images.contentstack.com/v3/assets/blt95b381df7c12c15d/bltbad33f5fea52f290/615c93d89aad297e10087704/Screen_Shot_2021-10-05_at_2.04.58_PM.png", true, "https://unity.com" },
                    { 12, "Coca Cola", "https://thumbs.dreamstime.com/b/large-famous-coca-cola-advertisement-banner-letters-minsk-belarus-june-red-colour-white-bottle-sign-under-bright-192933328.jpg", "https://media-assets-02.thedrum.com/cache/images/thedrum-prod/s3-news-tmp-304828-coco-cola_brand--default--968.jpg", true, "https://www.coca-cola.com/" },
                    { 13, "Nintendo Switch", "https://assets.nintendo.com/image/upload/f_auto/q_auto/dpr_2.625/c_scale/ncom/en_US/switch/site-design-update/switch-family", "https://preview.redd.it/4sf8pdnbd2v01.jpg?width=640&crop=smart&auto=webp&s=81b0573ebac985ea222ab5029216c14c39230c80", true, "https://www.nintendo.com/switch/" },
                    { 14, "Sony Playstation 5", "https://cdn.vox-cdn.com/thumbor/s0V50B4OAK9K05tKM0IOEXcSFn0=/0x0:2450x1628/1400x788/filters:focal(1225x814:1226x815)/cdn.vox-cdn.com/uploads/chorus_asset/file/20081590/ps5.png", "https://www.slashgear.com/img/gallery/watch-sonys-first-playstation-5-tv-ad-talk-dualsense-and-3d-audio/intro-import.jpg", true, "https://www.playstation.com/en-us/ps5/" },
                    { 15, "Mc'Donalds", "https://i.kinja-img.com/gawker-media/image/upload/c_fill,f_auto,fl_progressive,g_center,h_675,pg_1,q_80,w_1200/qt1pq58r827iyyvugjfr.jpg", "https://pbs.twimg.com/profile_images/1579916871654117376/Dxd2l1sN_400x400.png", true, "https://www.mcdonalds.com/us/en-us.html" }
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
