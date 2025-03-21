﻿// <auto-generated />
using EmployeeListing.DataAccess;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Oracle.EntityFrameworkCore.Metadata;

#nullable disable

namespace EmployeeListing.DataAccess.Migrations
{
    [DbContext(typeof(DataContext))]
    partial class DataContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.6")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            OracleModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("EmployeeListing.Model.Employee.EmpDTO", b =>
                {
                    b.Property<int>("AutoId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("NUMBER(10)");

                    OraclePropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("AutoId"));

                    b.Property<string>("DOB")
                        .IsRequired()
                        .HasColumnType("NVARCHAR2(10)");

                    b.Property<int>("EmpId")
                        .HasColumnType("NUMBER(10)");

                    b.Property<string>("FirstName")
                        .HasColumnType("NVARCHAR2(2000)");

                    b.Property<string>("Gender")
                        .IsRequired()
                        .HasColumnType("NVARCHAR2(1)");

                    b.Property<string>("LastName")
                        .HasColumnType("NVARCHAR2(2000)");

                    b.Property<string>("NIC")
                        .HasColumnType("NVARCHAR2(2000)");

                    b.HasKey("AutoId");

                    b.ToTable("TBL_Employees");
                });

            modelBuilder.Entity("EmployeeListing.Service.DTO.AuthUserpropDTO", b =>
                {
                    b.Property<string>("UserName")
                        .HasColumnType("NVARCHAR2(450)");

                    b.Property<byte[]>("PasswordHash")
                        .IsRequired()
                        .HasColumnType("RAW(2000)");

                    b.Property<byte[]>("PasswordSalt")
                        .IsRequired()
                        .HasColumnType("RAW(2000)");

                    b.HasKey("UserName");

                    b.ToTable("TBL_UserAuthentication");
                });
#pragma warning restore 612, 618
        }
    }
}
