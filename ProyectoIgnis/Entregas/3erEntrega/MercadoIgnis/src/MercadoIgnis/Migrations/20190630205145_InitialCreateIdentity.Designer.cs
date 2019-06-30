﻿// <auto-generated />
using System;
using MercadoIgnis.Areas.Identity.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace MercadoIgnis.Migrations
{
    [DbContext(typeof(IdentityContext))]
    [Migration("20190630205145_InitialCreateIdentity")]
    partial class InitialCreateIdentity
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.4-servicing-10062");

            modelBuilder.Entity("MercadoIgnis.Areas.Identity.Data.ApplicationUser", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("AccessFailedCount");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<DateTime>("DOB");

                    b.Property<string>("Email")
                        .HasMaxLength(256);

                    b.Property<bool>("EmailConfirmed");

                    b.Property<bool>("LockoutEnabled");

                    b.Property<DateTimeOffset?>("LockoutEnd");

                    b.Property<string>("Name");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256);

                    b.Property<string>("PasswordHash");

                    b.Property<string>("PhoneNumber");

                    b.Property<bool>("PhoneNumberConfirmed");

                    b.Property<string>("Role");

                    b.Property<string>("SecurityStamp");

                    b.Property<bool>("TwoFactorEnabled");

                    b.Property<string>("UserName")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasName("UserNameIndex");

                    b.ToTable("ApplicationUser");
                });

            modelBuilder.Entity("MercadoIgnis.Models.Calificacion", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Descripcion");

                    b.Property<int>("Nota");

                    b.HasKey("ID");

                    b.ToTable("Calificacion");
                });

            modelBuilder.Entity("MercadoIgnis.Models.Cliente", b =>
                {
                    b.Property<string>("ID");

                    b.HasKey("ID");

                    b.ToTable("Cliente");
                });

            modelBuilder.Entity("MercadoIgnis.Models.Especialidad", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Area");

                    b.Property<string>("Nivel");

                    b.Property<string>("TecnicoID");

                    b.HasKey("ID");

                    b.HasIndex("TecnicoID");

                    b.ToTable("Especialidad");
                });

            modelBuilder.Entity("MercadoIgnis.Models.Proyecto", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Descripcion");

                    b.Property<string>("Discriminator")
                        .IsRequired();

                    b.Property<DateTime>("FechaComienzo");

                    b.Property<DateTime>("FechaFinalizacion");

                    b.Property<string>("TecnicoID");

                    b.HasKey("ID");

                    b.HasIndex("TecnicoID");

                    b.ToTable("Proyecto");

                    b.HasDiscriminator<string>("Discriminator").HasValue("Proyecto");
                });

            modelBuilder.Entity("MercadoIgnis.Models.ProyectosIgnisClientes", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ClienteID");

                    b.Property<int>("ProyectoIgnisID");

                    b.HasKey("ID");

                    b.HasIndex("ClienteID");

                    b.HasIndex("ProyectoIgnisID")
                        .IsUnique();

                    b.ToTable("ProyectosIgnisClientes");
                });

            modelBuilder.Entity("MercadoIgnis.Models.Puesto", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("EspecialidadID");

                    b.Property<int>("ProyectoIgnisID");

                    b.HasKey("ID");

                    b.HasIndex("EspecialidadID");

                    b.HasIndex("ProyectoIgnisID");

                    b.ToTable("Puesto");
                });

            modelBuilder.Entity("MercadoIgnis.Models.Tecnico", b =>
                {
                    b.Property<string>("ID");

                    b.Property<bool>("EsEgresado");

                    b.HasKey("ID");

                    b.ToTable("Tecnico");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("Name")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasName("RoleNameIndex");

                    b.ToTable("AspNetRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<string>("RoleId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasMaxLength(128);

                    b.Property<string>("ProviderKey")
                        .HasMaxLength(128);

                    b.Property<string>("ProviderDisplayName");

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId");

                    b.Property<string>("RoleId");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId");

                    b.Property<string>("LoginProvider")
                        .HasMaxLength(128);

                    b.Property<string>("Name")
                        .HasMaxLength(128);

                    b.Property<string>("Value");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens");
                });

            modelBuilder.Entity("MercadoIgnis.Models.ProyectoIgnis", b =>
                {
                    b.HasBaseType("MercadoIgnis.Models.Proyecto");

                    b.Property<int>("Estado");

                    b.HasDiscriminator().HasValue("ProyectoIgnis");
                });

            modelBuilder.Entity("MercadoIgnis.Models.ProyectoPersonal", b =>
                {
                    b.HasBaseType("MercadoIgnis.Models.Proyecto");

                    b.Property<int>("Tipos");

                    b.HasDiscriminator().HasValue("ProyectoPersonal");
                });

            modelBuilder.Entity("MercadoIgnis.Models.Especialidad", b =>
                {
                    b.HasOne("MercadoIgnis.Models.Tecnico")
                        .WithMany("Especialidades")
                        .HasForeignKey("TecnicoID");
                });

            modelBuilder.Entity("MercadoIgnis.Models.Proyecto", b =>
                {
                    b.HasOne("MercadoIgnis.Models.Tecnico")
                        .WithMany("Proyectos")
                        .HasForeignKey("TecnicoID");
                });

            modelBuilder.Entity("MercadoIgnis.Models.ProyectosIgnisClientes", b =>
                {
                    b.HasOne("MercadoIgnis.Models.Cliente", "Cliente")
                        .WithMany("ProyectosIgnisClientes")
                        .HasForeignKey("ClienteID");

                    b.HasOne("MercadoIgnis.Models.ProyectoIgnis", "ProyectoIgnis")
                        .WithOne("ProyectosIgnisClientes")
                        .HasForeignKey("MercadoIgnis.Models.ProyectosIgnisClientes", "ProyectoIgnisID")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("MercadoIgnis.Models.Puesto", b =>
                {
                    b.HasOne("MercadoIgnis.Models.Especialidad", "Especialidad")
                        .WithMany()
                        .HasForeignKey("EspecialidadID")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("MercadoIgnis.Models.ProyectoIgnis", "ProyectoIgnis")
                        .WithMany("Puestos")
                        .HasForeignKey("ProyectoIgnisID")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("MercadoIgnis.Areas.Identity.Data.ApplicationUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("MercadoIgnis.Areas.Identity.Data.ApplicationUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("MercadoIgnis.Areas.Identity.Data.ApplicationUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("MercadoIgnis.Areas.Identity.Data.ApplicationUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
