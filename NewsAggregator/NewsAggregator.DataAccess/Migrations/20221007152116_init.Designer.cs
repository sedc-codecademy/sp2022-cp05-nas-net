﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using NewsAggregator.DataAccess;

#nullable disable

namespace NewsAggregator.DataAccess.Migrations
{
    [DbContext(typeof(NewsAggregatorDbContext))]
    [Migration("20221007152116_init")]
    partial class init
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.9")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("ArticleCategory", b =>
                {
                    b.Property<int>("ArticlesId")
                        .HasColumnType("int");

                    b.Property<int>("CategoriesId")
                        .HasColumnType("int");

                    b.HasKey("ArticlesId", "CategoriesId");

                    b.HasIndex("CategoriesId");

                    b.ToTable("ArticleCategory");
                });

            modelBuilder.Entity("NewsAggregator.Domain.Entities.Article", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Content")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("DatePublished")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ImageUrl")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("OriginalArticleUrl")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SourceLogo")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SourceUrl")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Articles");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Content = "testestestestestes",
                            DatePublished = new DateTime(2022, 10, 7, 17, 21, 15, 905, DateTimeKind.Local).AddTicks(8471),
                            Description = "test",
                            ImageUrl = "https://cdn.theathletic.com/cdn-cgi/image/width=770,format=auto/https://cdn.theathletic.com/app/uploads/2022/09/07021831/ERLING-HAALAND-MANCHESTER-CITY-scaled-e1662531544452-1024x683.jpg",
                            OriginalArticleUrl = "https://theathletic.com/3571283/2022/09/07/manchester-city-erling-haaland-one-touch/",
                            SourceLogo = "https://theathletic.com/app/themes/athletic/assets/img/open-graph-asset.png",
                            SourceUrl = "https://theathletic.com",
                            Title = "test"
                        });
                });

            modelBuilder.Entity("NewsAggregator.Domain.Entities.Category", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Categories");
                });

            modelBuilder.Entity("NewsAggregator.Domain.Entities.Comment", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("ArticleId")
                        .HasColumnType("int");

                    b.Property<string>("Content")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("DateCreated")
                        .HasColumnType("datetime2");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ArticleId");

                    b.HasIndex("UserId");

                    b.ToTable("Comments");
                });

            modelBuilder.Entity("NewsAggregator.Domain.Entities.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsAdmin")
                        .HasColumnType("bit");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("User", (string)null);

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Email = "bob@email.com",
                            FirstName = "Bob",
                            IsAdmin = false,
                            LastName = "Bobsky",
                            Password = "H,?????mI??I8",
                            Username = "bBobsky"
                        },
                        new
                        {
                            Id = 2,
                            Email = "john.doe@email.com",
                            FirstName = "Jon",
                            IsAdmin = false,
                            LastName = "Doe",
                            Password = "H,?????mI??I8",
                            Username = "jDoe"
                        },
                        new
                        {
                            Id = 3,
                            Email = "tom@admin.com",
                            FirstName = "Tom",
                            IsAdmin = true,
                            LastName = "Admin",
                            Password = "?:{?s%?i?? ",
                            Username = "adminTom"
                        },
                        new
                        {
                            Id = 4,
                            Email = "jill@admin.com",
                            FirstName = "Jill",
                            IsAdmin = true,
                            LastName = "Admin",
                            Password = "?:{?s%?i?? ",
                            Username = "adminJill"
                        });
                });

            modelBuilder.Entity("ArticleCategory", b =>
                {
                    b.HasOne("NewsAggregator.Domain.Entities.Article", null)
                        .WithMany()
                        .HasForeignKey("ArticlesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("NewsAggregator.Domain.Entities.Category", null)
                        .WithMany()
                        .HasForeignKey("CategoriesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("NewsAggregator.Domain.Entities.Comment", b =>
                {
                    b.HasOne("NewsAggregator.Domain.Entities.Article", "Article")
                        .WithMany("ArticleComments")
                        .HasForeignKey("ArticleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("NewsAggregator.Domain.Entities.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Article");

                    b.Navigation("User");
                });

            modelBuilder.Entity("NewsAggregator.Domain.Entities.Article", b =>
                {
                    b.Navigation("ArticleComments");
                });
#pragma warning restore 612, 618
        }
    }
}