// <auto-generated />
using Catalog.Host.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Catalog.Host.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20220206192722_InitialMigration")]
    partial class InitialMigration
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.HasSequence("catalog_brand_hilo")
                .IncrementsBy(10);

            modelBuilder.HasSequence("catalog_hilo")
                .IncrementsBy(10);

            modelBuilder.HasSequence("specification_hilo")
                .IncrementsBy(10);

            modelBuilder.Entity("Catalog.Host.Data.Entities.CatalogBrand", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseHiLo(b.Property<int>("Id"), "catalog_brand_hilo");

                    b.Property<string>("Brand")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)");

                    b.HasKey("Id");

                    b.ToTable("CatalogBrand", (string)null);
                });

            modelBuilder.Entity("Catalog.Host.Data.Entities.CatalogItem", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseHiLo(b.Property<int>("Id"), "catalog_hilo");

                    b.Property<int>("CatalogBrandId")
                        .HasColumnType("integer");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)");

                    b.Property<string>("PictureFileName")
                        .HasColumnType("text");

                    b.Property<decimal>("Price")
                        .HasColumnType("numeric");

                    b.Property<int>("SpecificationId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("CatalogBrandId");

                    b.HasIndex("SpecificationId");

                    b.ToTable("Catalog", (string)null);
                });

            modelBuilder.Entity("Catalog.Host.Data.Entities.Specification", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseHiLo(b.Property<int>("Id"), "specification_hilo");

                    b.Property<double>("ClockFrequency")
                        .HasColumnType("double precision");

                    b.Property<double>("MaximumClockFrequency")
                        .HasColumnType("double precision");

                    b.Property<string>("MemoryType")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)");

                    b.Property<int>("NumberOfCores")
                        .HasColumnType("integer");

                    b.Property<int>("NumberOfThreads")
                        .HasColumnType("integer");

                    b.Property<string>("Socket")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)");

                    b.Property<string>("VideoLink")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Specification", (string)null);
                });

            modelBuilder.Entity("Catalog.Host.Data.Entities.CatalogItem", b =>
                {
                    b.HasOne("Catalog.Host.Data.Entities.CatalogBrand", "CatalogBrand")
                        .WithMany()
                        .HasForeignKey("CatalogBrandId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Catalog.Host.Data.Entities.Specification", "Specification")
                        .WithMany()
                        .HasForeignKey("SpecificationId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("CatalogBrand");

                    b.Navigation("Specification");
                });
#pragma warning restore 612, 618
        }
    }
}
