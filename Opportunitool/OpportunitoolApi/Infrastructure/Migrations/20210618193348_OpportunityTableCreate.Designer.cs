// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using OpportunitoolApi.Persistence;

namespace OpportunitoolApi.Infrastructure.Migrations
{
    [DbContext(typeof(OpportunitoolDbContext))]
    [Migration("20210618193348_OpportunityTableCreate")]
    partial class OpportunityTableCreate
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "5.0.7");

            modelBuilder.Entity("OpportunitoolApi.Core.Models.Opportunity", b =>
                {
                    b.Property<long?>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Location")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("OrganizerEmail")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("OrganizerName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("OrganizerPhone")
                        .HasColumnType("TEXT");

                    b.Property<DateTime?>("RegistrationDeadline")
                        .HasColumnType("TEXT");

                    b.Property<string>("RegistrationLink")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Opportunities");
                });
#pragma warning restore 612, 618
        }
    }
}
