// <auto-generated />
using System;
using Integrator;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Integrator.Migrations
{
    [DbContext(typeof(IntegratorContext))]
    [Migration("20211211165408_Add type to widget")]
    partial class Addtypetowidget
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 64)
                .HasAnnotation("ProductVersion", "5.0.12");

            modelBuilder.Entity("Integrator.Features.Settings.Models.Setting", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("varchar(255)");

                    b.Property<DateTime>("Created")
                        .HasColumnType("datetime(6)");

                    b.Property<DateTime>("Modified")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Name")
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("Settings");
                });

            modelBuilder.Entity("Integrator.Features.Widgets.Models.Widget", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd()
                        .HasMaxLength(128)
                        .HasColumnType("varchar(128)");

                    b.Property<DateTime>("Created")
                        .HasColumnType("datetime(6)");

                    b.Property<DateTime>("Modified")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Title")
                        .HasColumnType("longtext");

                    b.Property<int>("Type")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Widgets");

                    b.HasData(
                        new
                        {
                            Id = "a0cd214b-2067-47fc-9eaa-d3ac4b4f0353",
                            Created = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Modified = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Title = "Timesmart Registration",
                            Type = 1
                        },
                        new
                        {
                            Id = "78iu214b-2067-47fc-9eaa-d3ac4b4f0352",
                            Created = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Modified = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Title = "Timesmart List",
                            Type = 1
                        },
                        new
                        {
                            Id = "hy67214b-2067-47fc-9eaa-d3ac4b4f0351",
                            Created = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Modified = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Title = "SAP List",
                            Type = 0
                        });
                });

            modelBuilder.Entity("Integrator.Features.Workspaces.Models.Workspace", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd()
                        .HasMaxLength(128)
                        .HasColumnType("varchar(128)");

                    b.Property<DateTime>("Created")
                        .HasColumnType("datetime(6)");

                    b.Property<DateTime>("Modified")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Title")
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("Workspaces");
                });

            modelBuilder.Entity("Integrator.Features.Workspaces.Models.WorkspaceWidget", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd()
                        .HasMaxLength(128)
                        .HasColumnType("varchar(128)");

                    b.Property<DateTime>("Created")
                        .HasColumnType("datetime(6)");

                    b.Property<DateTime>("Modified")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("WidgetId")
                        .HasMaxLength(128)
                        .HasColumnType("varchar(128)");

                    b.Property<string>("WorkspaceId")
                        .HasMaxLength(128)
                        .HasColumnType("varchar(128)");

                    b.HasKey("Id");

                    b.HasIndex("WidgetId");

                    b.HasIndex("WorkspaceId");

                    b.ToTable("WorkspaceWidgets");
                });

            modelBuilder.Entity("Integrator.Features.Workspaces.Models.WorkspaceWidget", b =>
                {
                    b.HasOne("Integrator.Features.Widgets.Models.Widget", "Widget")
                        .WithMany()
                        .HasForeignKey("WidgetId");

                    b.HasOne("Integrator.Features.Workspaces.Models.Workspace", "Workspace")
                        .WithMany("Widgets")
                        .HasForeignKey("WorkspaceId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.Navigation("Widget");

                    b.Navigation("Workspace");
                });

            modelBuilder.Entity("Integrator.Features.Workspaces.Models.Workspace", b =>
                {
                    b.Navigation("Widgets");
                });
#pragma warning restore 612, 618
        }
    }
}
