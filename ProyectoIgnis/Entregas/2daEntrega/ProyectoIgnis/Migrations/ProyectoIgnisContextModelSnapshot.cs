﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ProyectoIgnis.Models;

namespace ProyectoIgnis.Migrations
{
    [DbContext(typeof(ProyectoIgnisContext))]
    partial class ProyectoIgnisContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.4-servicing-10062");

            modelBuilder.Entity("ProyectoIgnis.Models.Especialidad", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Area");

                    b.Property<string>("Nivel");

                    b.HasKey("ID");

                    b.ToTable("Especialidad");
                });
#pragma warning restore 612, 618
        }
    }
}
