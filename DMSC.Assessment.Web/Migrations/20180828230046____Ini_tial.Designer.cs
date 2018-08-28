﻿// <auto-generated />
using System;
using DMSC.Assessment.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace DMSC.Assessment.Web.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20180828230046____Ini_tial")]
    partial class ___Ini_tial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.2-rtm-30932")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("DMSC.Assessment.Data.Model.Article", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("Active");

                    b.Property<string>("Content");

                    b.Property<DateTime>("CreatedAt");

                    b.Property<string>("CreatedBy");

                    b.Property<DateTime>("Published");

                    b.Property<string>("Title");

                    b.Property<int>("UserId");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("Articles");
                });

            modelBuilder.Entity("DMSC.Assessment.Data.Model.Like", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("ArticleId");

                    b.Property<DateTime>("CreatedAt");

                    b.Property<string>("CreatedBy");

                    b.Property<int>("UserId");

                    b.HasKey("Id");

                    b.HasIndex("ArticleId");

                    b.HasIndex("UserId");

                    b.ToTable("Likes");
                });

            modelBuilder.Entity("DMSC.Assessment.Data.Model.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("CreatedAt");

                    b.Property<string>("CreatedBy");

                    b.Property<string>("Email");

                    b.Property<string>("FirstName");

                    b.Property<string>("LastName");

                    b.Property<string>("Mobile");

                    b.Property<string>("Password");

                    b.Property<string>("Role");

                    b.Property<string>("UserName");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("DMSC.Assessment.Data.Model.Article", b =>
                {
                    b.HasOne("DMSC.Assessment.Data.Model.User", "Author")
                        .WithMany("Articles")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("DMSC.Assessment.Data.Model.Like", b =>
                {
                    b.HasOne("DMSC.Assessment.Data.Model.Article", "Article")
                        .WithMany("Likes")
                        .HasForeignKey("ArticleId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("DMSC.Assessment.Data.Model.User", "User")
                        .WithMany("Likes")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Restrict);
                });
#pragma warning restore 612, 618
        }
    }
}
