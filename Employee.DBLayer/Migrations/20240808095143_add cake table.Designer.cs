﻿// <auto-generated />
using System;
using Employee.DBLayer;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Employee.DBLayer.Migrations
{
    [DbContext(typeof(EmployeeDbContext))]
    [Migration("20240808095143_add cake table")]
    partial class addcaketable
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.32")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("Employee.DBLayer.DBModel.Cake", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("price")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("Id");

                    b.ToTable("cakes");
                });

            modelBuilder.Entity("Employee.DBLayer.DBModel.ClsDepartment", b =>
                {
                    b.Property<int>("departmentid")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("departmentid"), 1L, 1);

                    b.Property<string>("departmentname")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("departmentid");

                    b.ToTable("mstDepartment");
                });

            modelBuilder.Entity("Employee.DBLayer.DBModel.ClsEmpCountBaseDep", b =>
                {
                    b.Property<int>("Count")
                        .HasColumnType("int");

                    b.Property<string>("EmployeeName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.ToTable("ClsEmpCountBaseDep");
                });

            modelBuilder.Entity("Employee.DBLayer.DBModel.ClsEmployee", b =>
                {
                    b.Property<int>("EmployeeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("EmployeeId"), 1L, 1);

                    b.Property<DateTime>("CreatedDt")
                        .HasColumnType("datetime2");

                    b.Property<string>("EmployeeName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<int>("departmentid")
                        .HasColumnType("int");

                    b.HasKey("EmployeeId");

                    b.HasIndex("departmentid");

                    b.ToTable("mstEmployee");
                });

            modelBuilder.Entity("Employee.DBLayer.DBModel.ClsEmployee", b =>
                {
                    b.HasOne("Employee.DBLayer.DBModel.ClsDepartment", "clsDepartment")
                        .WithMany("employees")
                        .HasForeignKey("departmentid")
                        .IsRequired();

                    b.Navigation("clsDepartment");
                });

            modelBuilder.Entity("Employee.DBLayer.DBModel.ClsDepartment", b =>
                {
                    b.Navigation("employees");
                });
#pragma warning restore 612, 618
        }
    }
}
