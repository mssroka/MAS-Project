﻿// <auto-generated />
using System;
using MAS;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace MAS.Data.Migrations
{
    [DbContext(typeof(MasContext))]
    [Migration("20230607232900_addedNames5")]
    partial class addedNames5
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("MAS.Data.Car", b =>
                {
                    b.Property<int>("IdCar")
                        .HasColumnType("int")
                        .HasColumnName("idCar");

                    b.Property<string>("Brand")
                        .IsRequired()
                        .HasMaxLength(30)
                        .IsUnicode(false)
                        .HasColumnType("varchar(30)")
                        .HasColumnName("brand");

                    b.Property<int>("IdPerson")
                        .HasColumnType("int")
                        .HasColumnName("idPerson");

                    b.Property<string>("Model")
                        .IsRequired()
                        .HasMaxLength(30)
                        .IsUnicode(false)
                        .HasColumnType("varchar(30)")
                        .HasColumnName("model");

                    b.Property<string>("Plates")
                        .IsRequired()
                        .HasMaxLength(9)
                        .IsUnicode(false)
                        .HasColumnType("varchar(9)")
                        .HasColumnName("plates");

                    b.HasKey("IdCar")
                        .HasName("Car_pk");

                    b.HasIndex("IdPerson");

                    b.ToTable("Car", (string)null);
                });

            modelBuilder.Entity("MAS.Data.Client", b =>
                {
                    b.Property<int>("IdPerson")
                        .HasColumnType("int")
                        .HasColumnName("idPerson");

                    b.Property<string>("Notes")
                        .HasMaxLength(255)
                        .IsUnicode(false)
                        .HasColumnType("varchar(255)")
                        .HasColumnName("notes");

                    b.HasKey("IdPerson")
                        .HasName("Client_pk");

                    b.ToTable("Client", (string)null);
                });

            modelBuilder.Entity("MAS.Data.Diagnosis", b =>
                {
                    b.Property<int>("IdJob")
                        .HasColumnType("int")
                        .HasColumnName("idJob");

                    b.Property<int>("IdPerson")
                        .HasColumnType("int")
                        .HasColumnName("idPerson");

                    b.Property<string>("DiagText")
                        .IsRequired()
                        .HasMaxLength(255)
                        .IsUnicode(false)
                        .HasColumnType("varchar(255)")
                        .HasColumnName("diagText");

                    b.HasKey("IdJob", "IdPerson")
                        .HasName("Diagnosis_pk");

                    b.HasIndex("IdPerson");

                    b.ToTable("Diagnosis", (string)null);
                });

            modelBuilder.Entity("MAS.Data.Element", b =>
                {
                    b.Property<int>("IdElement")
                        .HasColumnType("int")
                        .HasColumnName("idElement");

                    b.Property<int>("Cost")
                        .HasColumnType("int")
                        .HasColumnName("cost");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)")
                        .HasColumnName("name");

                    b.HasKey("IdElement")
                        .HasName("Element_pk");

                    b.ToTable("Element", (string)null);
                });

            modelBuilder.Entity("MAS.Data.Job", b =>
                {
                    b.Property<int>("IdJob")
                        .HasColumnType("int")
                        .HasColumnName("idJob");

                    b.Property<int>("Cost")
                        .HasColumnType("int")
                        .HasColumnName("cost");

                    b.Property<DateTime>("End")
                        .HasColumnType("date")
                        .HasColumnName("end");

                    b.Property<int>("IdCar")
                        .HasColumnType("int")
                        .HasColumnName("idCar");

                    b.Property<int>("IdPerson")
                        .HasColumnType("int")
                        .HasColumnName("idPerson");

                    b.Property<string>("Note")
                        .HasMaxLength(255)
                        .IsUnicode(false)
                        .HasColumnType("varchar(255)")
                        .HasColumnName("note");

                    b.Property<DateTime>("Start")
                        .HasColumnType("date")
                        .HasColumnName("start");

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasMaxLength(20)
                        .IsUnicode(false)
                        .HasColumnType("varchar(20)")
                        .HasColumnName("status");

                    b.HasKey("IdJob")
                        .HasName("Job_pk");

                    b.HasIndex("IdCar");

                    b.HasIndex("IdPerson");

                    b.ToTable("Job", (string)null);
                });

            modelBuilder.Entity("MAS.Data.Manager", b =>
                {
                    b.Property<int>("IdPerson")
                        .HasColumnType("int")
                        .HasColumnName("idPerson");

                    b.Property<DateTime>("HireDate")
                        .HasColumnType("date")
                        .HasColumnName("hireDate");

                    b.Property<int>("IdService")
                        .HasColumnType("int")
                        .HasColumnName("idService");

                    b.Property<int>("Pesel")
                        .HasColumnType("int")
                        .HasColumnName("pesel");

                    b.Property<DateTime>("PromotionDate")
                        .HasColumnType("date")
                        .HasColumnName("promotionDate");

                    b.HasKey("IdPerson")
                        .HasName("Manager_pk");

                    b.HasIndex("IdService");

                    b.ToTable("Manager", (string)null);
                });

            modelBuilder.Entity("MAS.Data.Overview", b =>
                {
                    b.Property<int>("IdOverview")
                        .HasColumnType("int")
                        .HasColumnName("idOverview");

                    b.Property<int>("Cost")
                        .HasColumnType("int")
                        .HasColumnName("cost");

                    b.Property<int>("IdJob")
                        .HasColumnType("int")
                        .HasColumnName("idJob");

                    b.HasKey("IdOverview")
                        .HasName("Overview_pk");

                    b.HasIndex("IdJob");

                    b.ToTable("Overview", (string)null);
                });

            modelBuilder.Entity("MAS.Data.Painting", b =>
                {
                    b.Property<int>("IdPainting")
                        .HasColumnType("int")
                        .HasColumnName("idPainting");

                    b.Property<string>("Colour")
                        .IsRequired()
                        .HasMaxLength(7)
                        .IsUnicode(false)
                        .HasColumnType("varchar(7)")
                        .HasColumnName("colour");

                    b.HasKey("IdPainting")
                        .HasName("Painting_pk");

                    b.ToTable("Painting", (string)null);
                });

            modelBuilder.Entity("MAS.Data.PaintingElement", b =>
                {
                    b.Property<int>("IdElement")
                        .HasColumnType("int")
                        .HasColumnName("idElement");

                    b.Property<int>("IdPainting")
                        .HasColumnType("int")
                        .HasColumnName("idPainting");

                    b.Property<int>("IdJob")
                        .HasColumnType("int")
                        .HasColumnName("idJob");

                    b.HasKey("IdElement", "IdPainting", "IdJob")
                        .HasName("PaintingElement_pk");

                    b.HasIndex("IdJob");

                    b.HasIndex("IdPainting");

                    b.ToTable("PaintingElement", (string)null);
                });

            modelBuilder.Entity("MAS.Data.Part", b =>
                {
                    b.Property<int>("IdPart")
                        .HasColumnType("int")
                        .HasColumnName("idPart");

                    b.Property<int>("Cost")
                        .HasColumnType("int")
                        .HasColumnName("cost");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(20)
                        .IsUnicode(false)
                        .HasColumnType("varchar(20)")
                        .HasColumnName("name");

                    b.HasKey("IdPart")
                        .HasName("Part_pk");

                    b.ToTable("Part", (string)null);
                });

            modelBuilder.Entity("MAS.Data.PartsExchange", b =>
                {
                    b.Property<int>("IdPartsExchange")
                        .HasColumnType("int")
                        .HasColumnName("idPartsExchange");

                    b.HasKey("IdPartsExchange")
                        .HasName("PartsExchange_pk");

                    b.ToTable("PartsExchange", (string)null);
                });

            modelBuilder.Entity("MAS.Data.Person", b =>
                {
                    b.Property<int>("IdPerson")
                        .HasColumnType("int")
                        .HasColumnName("idPerson");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(30)
                        .IsUnicode(false)
                        .HasColumnType("varchar(30)")
                        .HasColumnName("firstName");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(30)
                        .IsUnicode(false)
                        .HasColumnType("varchar(30)")
                        .HasColumnName("lastName");

                    b.Property<int>("PhoneNumber")
                        .HasColumnType("int")
                        .HasColumnName("phoneNumber");

                    b.HasKey("IdPerson")
                        .HasName("Person_pk");

                    b.ToTable("Person", (string)null);
                });

            modelBuilder.Entity("MAS.Data.Replacement", b =>
                {
                    b.Property<int>("IdPartsExchange")
                        .HasColumnType("int")
                        .HasColumnName("idPartsExchange");

                    b.Property<int>("IdJob")
                        .HasColumnType("int")
                        .HasColumnName("idJob");

                    b.Property<int>("IdPart")
                        .HasColumnType("int")
                        .HasColumnName("idPart");

                    b.HasKey("IdPartsExchange", "IdJob", "IdPart")
                        .HasName("Replacement_pk");

                    b.HasIndex("IdJob");

                    b.HasIndex("IdPart");

                    b.ToTable("Replacement", (string)null);
                });

            modelBuilder.Entity("MAS.Data.Service", b =>
                {
                    b.Property<int>("IdService")
                        .HasColumnType("int")
                        .HasColumnName("idService");

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)")
                        .HasColumnName("address");

                    b.Property<DateTime>("Closing")
                        .HasColumnType("datetime")
                        .HasColumnName("closing");

                    b.Property<int>("EmpAmount")
                        .HasColumnType("int")
                        .HasColumnName("empAmount");

                    b.Property<int>("MaxEmpAmount")
                        .HasColumnType("int")
                        .HasColumnName("maxEmpAmount");

                    b.Property<DateTime>("Opening")
                        .HasColumnType("datetime")
                        .HasColumnName("opening");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasMaxLength(15)
                        .IsUnicode(false)
                        .HasColumnType("varchar(15)")
                        .HasColumnName("phoneNumber");

                    b.HasKey("IdService")
                        .HasName("Service_pk");

                    b.ToTable("Service", (string)null);
                });

            modelBuilder.Entity("MAS.Data.ServiceActivity", b =>
                {
                    b.Property<int>("IdServiceActivity")
                        .HasColumnType("int")
                        .HasColumnName("idServiceActivity");

                    b.Property<int>("DifficultyLevel")
                        .HasColumnType("int")
                        .HasColumnName("difficultyLevel");

                    b.Property<int?>("IdOverview")
                        .HasColumnType("int")
                        .HasColumnName("idOverview");

                    b.Property<int?>("IdPainting")
                        .HasColumnType("int")
                        .HasColumnName("idPainting");

                    b.Property<int?>("IdPartsExchange")
                        .HasColumnType("int")
                        .HasColumnName("idPartsExchange");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("name");

                    b.Property<DateTime>("ServiceDate")
                        .HasColumnType("datetime2")
                        .HasColumnName("serviceDate");

                    b.HasKey("IdServiceActivity")
                        .HasName("ServiceActivity_pk");

                    b.HasIndex("IdOverview");

                    b.HasIndex("IdPainting");

                    b.HasIndex("IdPartsExchange");

                    b.ToTable("ServiceActivity", (string)null);
                });

            modelBuilder.Entity("MAS.Data.Serviceman", b =>
                {
                    b.Property<int>("IdPerson")
                        .HasColumnType("int")
                        .HasColumnName("idPerson");

                    b.Property<DateTime>("HireDate")
                        .HasColumnType("date")
                        .HasColumnName("hireDate");

                    b.Property<int>("IdService")
                        .HasColumnType("int")
                        .HasColumnName("idService");

                    b.Property<int>("Pesel")
                        .HasColumnType("int")
                        .HasColumnName("pesel");

                    b.Property<int>("RepairAmount")
                        .HasColumnType("int")
                        .HasColumnName("repairAmount");

                    b.Property<int>("Skills")
                        .HasColumnType("int")
                        .HasColumnName("skills");

                    b.HasKey("IdPerson")
                        .HasName("Serviceman_pk");

                    b.HasIndex("IdService");

                    b.ToTable("Serviceman", (string)null);
                });

            modelBuilder.Entity("MAS.Data.Trainee", b =>
                {
                    b.Property<int>("IdPerson")
                        .HasColumnType("int")
                        .HasColumnName("idPerson");

                    b.Property<int>("IdService")
                        .HasColumnType("int")
                        .HasColumnName("idService");

                    b.Property<DateTime>("InternshipStartDate")
                        .HasColumnType("date")
                        .HasColumnName("internshipStartDate");

                    b.Property<int>("LengthOfInternship")
                        .HasColumnType("int")
                        .HasColumnName("lengthOfInternship");

                    b.Property<int>("Salary")
                        .HasColumnType("int")
                        .HasColumnName("salary");

                    b.HasKey("IdPerson")
                        .HasName("Trainee_pk");

                    b.HasIndex("IdService");

                    b.ToTable("Trainee", (string)null);
                });

            modelBuilder.Entity("MAS.Data.Car", b =>
                {
                    b.HasOne("MAS.Data.Client", "IdPersonNavigation")
                        .WithMany("Cars")
                        .HasForeignKey("IdPerson")
                        .IsRequired()
                        .HasConstraintName("Car_Client");

                    b.Navigation("IdPersonNavigation");
                });

            modelBuilder.Entity("MAS.Data.Client", b =>
                {
                    b.HasOne("MAS.Data.Person", "IdPersonNavigation")
                        .WithOne("Client")
                        .HasForeignKey("MAS.Data.Client", "IdPerson")
                        .IsRequired()
                        .HasConstraintName("Client_Person");

                    b.Navigation("IdPersonNavigation");
                });

            modelBuilder.Entity("MAS.Data.Diagnosis", b =>
                {
                    b.HasOne("MAS.Data.Job", "IdJobNavigation")
                        .WithMany("Diagnoses")
                        .HasForeignKey("IdJob")
                        .IsRequired()
                        .HasConstraintName("Diagnosis_Job");

                    b.HasOne("MAS.Data.Manager", "IdPersonNavigation")
                        .WithMany("Diagnoses")
                        .HasForeignKey("IdPerson")
                        .IsRequired()
                        .HasConstraintName("Diagnosis_Manager");

                    b.Navigation("IdJobNavigation");

                    b.Navigation("IdPersonNavigation");
                });

            modelBuilder.Entity("MAS.Data.Job", b =>
                {
                    b.HasOne("MAS.Data.Car", "IdCarNavigation")
                        .WithMany("Jobs")
                        .HasForeignKey("IdCar")
                        .IsRequired()
                        .HasConstraintName("Job_Car");

                    b.HasOne("MAS.Data.Serviceman", "ServicemanIdPersonNavigation")
                        .WithMany("Jobs")
                        .HasForeignKey("IdPerson")
                        .IsRequired()
                        .HasConstraintName("Job_Serviceman");

                    b.Navigation("IdCarNavigation");

                    b.Navigation("ServicemanIdPersonNavigation");
                });

            modelBuilder.Entity("MAS.Data.Manager", b =>
                {
                    b.HasOne("MAS.Data.Person", "IdPersonNavigation")
                        .WithOne("Manager")
                        .HasForeignKey("MAS.Data.Manager", "IdPerson")
                        .IsRequired()
                        .HasConstraintName("Manager_Person");

                    b.HasOne("MAS.Data.Service", "IdServiceNavigation")
                        .WithMany("Managers")
                        .HasForeignKey("IdService")
                        .IsRequired()
                        .HasConstraintName("Manager_Service");

                    b.Navigation("IdPersonNavigation");

                    b.Navigation("IdServiceNavigation");
                });

            modelBuilder.Entity("MAS.Data.Overview", b =>
                {
                    b.HasOne("MAS.Data.Job", "IdJobNavigation")
                        .WithMany("Overviews")
                        .HasForeignKey("IdJob")
                        .IsRequired()
                        .HasConstraintName("Overview_Job");

                    b.Navigation("IdJobNavigation");
                });

            modelBuilder.Entity("MAS.Data.PaintingElement", b =>
                {
                    b.HasOne("MAS.Data.Element", "IdElementNavigation")
                        .WithMany("PaintingElements")
                        .HasForeignKey("IdElement")
                        .IsRequired()
                        .HasConstraintName("PaintingElement_Copy_of_Element");

                    b.HasOne("MAS.Data.Job", "IdJobNavigation")
                        .WithMany("PaintingElements")
                        .HasForeignKey("IdJob")
                        .IsRequired()
                        .HasConstraintName("PaintingElement_Job");

                    b.HasOne("MAS.Data.Painting", "IdPaintingNavigation")
                        .WithMany("PaintingElements")
                        .HasForeignKey("IdPainting")
                        .IsRequired()
                        .HasConstraintName("PaintingElement_Copy_of_Painting");

                    b.Navigation("IdElementNavigation");

                    b.Navigation("IdJobNavigation");

                    b.Navigation("IdPaintingNavigation");
                });

            modelBuilder.Entity("MAS.Data.Replacement", b =>
                {
                    b.HasOne("MAS.Data.Job", "IdJobNavigation")
                        .WithMany("Replacements")
                        .HasForeignKey("IdJob")
                        .IsRequired()
                        .HasConstraintName("Replacement_Job");

                    b.HasOne("MAS.Data.Part", "IdPartNavigation")
                        .WithMany("Replacements")
                        .HasForeignKey("IdPart")
                        .IsRequired()
                        .HasConstraintName("Replacement_Part");

                    b.HasOne("MAS.Data.PartsExchange", "IdPartsExchangeNavigation")
                        .WithMany("Replacements")
                        .HasForeignKey("IdPartsExchange")
                        .IsRequired()
                        .HasConstraintName("Replacement_PartsExchange");

                    b.Navigation("IdJobNavigation");

                    b.Navigation("IdPartNavigation");

                    b.Navigation("IdPartsExchangeNavigation");
                });

            modelBuilder.Entity("MAS.Data.ServiceActivity", b =>
                {
                    b.HasOne("MAS.Data.Overview", "IdOverviewNavigation")
                        .WithMany("ServiceActivities")
                        .HasForeignKey("IdOverview")
                        .HasConstraintName("ServiceActivity_Overview");

                    b.HasOne("MAS.Data.Painting", "IdPaintingNavigation")
                        .WithMany("ServiceActivities")
                        .HasForeignKey("IdPainting")
                        .HasConstraintName("ServiceActivity_Painting");

                    b.HasOne("MAS.Data.PartsExchange", "IdPartsExchangeNavigation")
                        .WithMany("ServiceActivities")
                        .HasForeignKey("IdPartsExchange")
                        .HasConstraintName("ServiceActivity_PartsExchange");

                    b.Navigation("IdOverviewNavigation");

                    b.Navigation("IdPaintingNavigation");

                    b.Navigation("IdPartsExchangeNavigation");
                });

            modelBuilder.Entity("MAS.Data.Serviceman", b =>
                {
                    b.HasOne("MAS.Data.Person", "IdPersonNavigation")
                        .WithOne("Serviceman")
                        .HasForeignKey("MAS.Data.Serviceman", "IdPerson")
                        .IsRequired()
                        .HasConstraintName("Serviceman_Person");

                    b.HasOne("MAS.Data.Service", "IdServiceNavigation")
                        .WithMany("Servicemen")
                        .HasForeignKey("IdService")
                        .IsRequired()
                        .HasConstraintName("Serviceman_Service");

                    b.Navigation("IdPersonNavigation");

                    b.Navigation("IdServiceNavigation");
                });

            modelBuilder.Entity("MAS.Data.Trainee", b =>
                {
                    b.HasOne("MAS.Data.Person", "IdPersonNavigation")
                        .WithOne("Trainee")
                        .HasForeignKey("MAS.Data.Trainee", "IdPerson")
                        .IsRequired()
                        .HasConstraintName("Trainee_Person");

                    b.HasOne("MAS.Data.Service", "IdServiceNavigation")
                        .WithMany("Trainees")
                        .HasForeignKey("IdService")
                        .IsRequired()
                        .HasConstraintName("Trainee_Service");

                    b.Navigation("IdPersonNavigation");

                    b.Navigation("IdServiceNavigation");
                });

            modelBuilder.Entity("MAS.Data.Car", b =>
                {
                    b.Navigation("Jobs");
                });

            modelBuilder.Entity("MAS.Data.Client", b =>
                {
                    b.Navigation("Cars");
                });

            modelBuilder.Entity("MAS.Data.Element", b =>
                {
                    b.Navigation("PaintingElements");
                });

            modelBuilder.Entity("MAS.Data.Job", b =>
                {
                    b.Navigation("Diagnoses");

                    b.Navigation("Overviews");

                    b.Navigation("PaintingElements");

                    b.Navigation("Replacements");
                });

            modelBuilder.Entity("MAS.Data.Manager", b =>
                {
                    b.Navigation("Diagnoses");
                });

            modelBuilder.Entity("MAS.Data.Overview", b =>
                {
                    b.Navigation("ServiceActivities");
                });

            modelBuilder.Entity("MAS.Data.Painting", b =>
                {
                    b.Navigation("PaintingElements");

                    b.Navigation("ServiceActivities");
                });

            modelBuilder.Entity("MAS.Data.Part", b =>
                {
                    b.Navigation("Replacements");
                });

            modelBuilder.Entity("MAS.Data.PartsExchange", b =>
                {
                    b.Navigation("Replacements");

                    b.Navigation("ServiceActivities");
                });

            modelBuilder.Entity("MAS.Data.Person", b =>
                {
                    b.Navigation("Client");

                    b.Navigation("Manager");

                    b.Navigation("Serviceman");

                    b.Navigation("Trainee");
                });

            modelBuilder.Entity("MAS.Data.Service", b =>
                {
                    b.Navigation("Managers");

                    b.Navigation("Servicemen");

                    b.Navigation("Trainees");
                });

            modelBuilder.Entity("MAS.Data.Serviceman", b =>
                {
                    b.Navigation("Jobs");
                });
#pragma warning restore 612, 618
        }
    }
}
