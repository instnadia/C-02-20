﻿// <auto-generated />
using System;
using Day_3.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Day_3.Migrations
{
    [DbContext(typeof(MyContext))]
    [Migration("20200212183527_TrailMig")]
    partial class TrailMig
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.4-servicing-10062")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("Day_3.Models.Trail", b =>
                {
                    b.Property<int>("TrailId")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("CreatedAt");

                    b.Property<string>("Desc")
                        .IsRequired();

                    b.Property<int>("Elv");

                    b.Property<int>("Len");

                    b.Property<string>("Name")
                        .IsRequired();

                    b.Property<DateTime>("UpdatedAt");

                    b.HasKey("TrailId");

                    b.ToTable("Trails");
                });
#pragma warning restore 612, 618
        }
    }
}
