﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using UserTree.Infrastructure.Persistence;

#nullable disable

namespace UserTree.Infrastructure.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.16")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("UserTree.Domain.Entities.JournalEvent", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Data")
                        .HasMaxLength(4000)
                        .HasColumnType("character varying(4000)");

                    b.Property<string>("RequestData")
                        .HasMaxLength(4000)
                        .HasColumnType("character varying(4000)");

                    b.Property<string>("StackTrace")
                        .HasMaxLength(4000)
                        .HasColumnType("character varying(4000)");

                    b.Property<DateTimeOffset>("TimeOffset")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Type")
                        .HasMaxLength(4000)
                        .HasColumnType("character varying(4000)");

                    b.HasKey("Id");

                    b.ToTable("JournalEvents");
                });

            modelBuilder.Entity("UserTree.Domain.Entities.Tree", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(2048)
                        .HasColumnType("character varying(2048)");

                    b.HasKey("Id");

                    b.HasIndex("Name")
                        .IsUnique();

                    b.ToTable("Trees");
                });

            modelBuilder.Entity("UserTree.Domain.Entities.TreeNode", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(2048)
                        .HasColumnType("character varying(2048)");

                    b.Property<int?>("ParentNodeId")
                        .HasColumnType("integer");

                    b.Property<int>("TreeId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("ParentNodeId");

                    b.HasIndex("TreeId");

                    b.ToTable("TreeNodes");
                });

            modelBuilder.Entity("UserTree.Domain.Entities.TreeNode", b =>
                {
                    b.HasOne("UserTree.Domain.Entities.TreeNode", "ParentNode")
                        .WithMany("ChildrenNodes")
                        .HasForeignKey("ParentNodeId");

                    b.HasOne("UserTree.Domain.Entities.Tree", "Tree")
                        .WithMany("Nodes")
                        .HasForeignKey("TreeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ParentNode");

                    b.Navigation("Tree");
                });

            modelBuilder.Entity("UserTree.Domain.Entities.Tree", b =>
                {
                    b.Navigation("Nodes");
                });

            modelBuilder.Entity("UserTree.Domain.Entities.TreeNode", b =>
                {
                    b.Navigation("ChildrenNodes");
                });
#pragma warning restore 612, 618
        }
    }
}
