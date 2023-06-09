using System;
using System.Collections.Generic;
using MAS.Data;
using Microsoft.EntityFrameworkCore;

namespace MAS;

public partial class MasContext : DbContext
{
    public MasContext()
    {
    }

    public MasContext(DbContextOptions<MasContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Car> Cars { get; set; }

    public virtual DbSet<Client> Clients { get; set; }

    public virtual DbSet<Diagnosis> Diagnoses { get; set; }

    public virtual DbSet<Element> Elements { get; set; }

    public virtual DbSet<Job> Jobs { get; set; }

    public virtual DbSet<Manager> Managers { get; set; }

    public virtual DbSet<Overview> Overviews { get; set; }

    public virtual DbSet<Painting> Paintings { get; set; }

    public virtual DbSet<PaintingElement> PaintingElements { get; set; }

    public virtual DbSet<Part> Parts { get; set; }

    public virtual DbSet<PartsExchange> PartsExchanges { get; set; }

    public virtual DbSet<Person> People { get; set; }

    public virtual DbSet<Replacement> Replacements { get; set; }

    public virtual DbSet<Service> Services { get; set; }

    public virtual DbSet<ServiceActivity> ServiceActivities { get; set; }

    public virtual DbSet<Serviceman> Servicemen { get; set; }

    public virtual DbSet<Trainee> Trainees { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Car>(entity =>
        {
            entity.HasKey(e => e.IdCar).HasName("Car_pk");

            entity.ToTable("Car");

            entity.Property(e => e.IdCar)
                .HasColumnName("idCar");
            entity.Property(e => e.Brand)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("brand");
            entity.Property(e => e.IdPerson).HasColumnName("idPerson");
            entity.Property(e => e.Model)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("model");
            entity.Property(e => e.Plates)
                .HasMaxLength(9)
                .IsUnicode(false)
                .HasColumnName("plates");

            entity.HasOne(d => d.IdPersonNavigation).WithMany(p => p.Cars)
                .HasForeignKey(d => d.IdPerson)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("Car_Client");
        });

        modelBuilder.Entity<Client>(entity =>
        {
            entity.HasKey(e => e.IdPerson).HasName("Client_pk");

            entity.ToTable("Client");

            entity.Property(e => e.IdPerson)
                .ValueGeneratedNever()
                .HasColumnName("idPerson");
            entity.Property(e => e.Notes)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("notes");

            entity.HasOne(d => d.IdPersonNavigation).WithOne(p => p.Client)
                .HasForeignKey<Client>(d => d.IdPerson)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("Client_Person");
        });

        modelBuilder.Entity<Diagnosis>(entity =>
        {
            entity.HasKey(e => new { e.IdJob, e.IdPerson }).HasName("Diagnosis_pk");

            entity.ToTable("Diagnosis");

            entity.Property(e => e.IdJob).HasColumnName("idJob");
            entity.Property(e => e.IdPerson).HasColumnName("idPerson");
            entity.Property(e => e.DiagText)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("diagText");

            entity.HasOne(d => d.IdJobNavigation).WithMany(p => p.Diagnoses)
                .HasForeignKey(d => d.IdJob)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("Diagnosis_Job");

            entity.HasOne(d => d.IdPersonNavigation).WithMany(p => p.Diagnoses)
                .HasForeignKey(d => d.IdPerson)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("Diagnosis_Manager");
        });

        modelBuilder.Entity<Element>(entity =>
        {
            entity.HasKey(e => e.IdElement).HasName("Element_pk");

            entity.ToTable("Element");

            entity.Property(e => e.IdElement)
                .HasColumnName("idElement");
            entity.Property(e => e.Cost).HasColumnName("cost");
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("name");
        });

        modelBuilder.Entity<Job>(entity =>
        {
            entity.HasKey(e => e.IdJob).HasName("Job_pk");

            entity.ToTable("Job");

            entity.Property(e => e.IdJob)
                .HasColumnName("idJob");
            entity.Property(e => e.Cost).HasColumnName("cost");
            entity.Property(e => e.End)
                .HasColumnType("date")
                .HasColumnName("end");
            entity.Property(e => e.IdCar).HasColumnName("idCar");
            entity.Property(e => e.Note)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("note");
            entity.Property(e => e.IdPerson).HasColumnName("idPerson");
            entity.Property(e => e.Start)
                .HasColumnType("date")
                .HasColumnName("start");
            entity.Property(e => e.Status)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("status");

            entity.HasOne(d => d.IdCarNavigation).WithMany(p => p.Jobs)
                .HasForeignKey(d => d.IdCar)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("Job_Car");

            entity.HasOne(d => d.ServicemanIdPersonNavigation).WithMany(p => p.Jobs)
                .HasForeignKey(d => d.IdPerson)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("Job_Serviceman");
        });

        modelBuilder.Entity<Manager>(entity =>
        {
            entity.HasKey(e => e.IdPerson).HasName("Manager_pk");

            entity.ToTable("Manager");

            entity.Property(e => e.IdPerson)
                .ValueGeneratedNever()
                .HasColumnName("idPerson");
            entity.Property(e => e.HireDate)
                .HasColumnType("date")
                .HasColumnName("hireDate");
            entity.Property(e => e.IdService).HasColumnName("idService");
            entity.Property(e => e.Pesel).HasColumnName("pesel");
            entity.Property(e => e.PromotionDate)
                .HasColumnType("date")
                .HasColumnName("promotionDate");

            entity.HasOne(d => d.IdPersonNavigation).WithOne(p => p.Manager)
                .HasForeignKey<Manager>(d => d.IdPerson)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("Manager_Person");

            entity.HasOne(d => d.IdServiceNavigation).WithMany(p => p.Managers)
                .HasForeignKey(d => d.IdService)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("Manager_Service");
        });

        modelBuilder.Entity<Overview>(entity =>
        {
            entity.HasKey(e => e.IdOverview).HasName("Overview_pk");

            entity.ToTable("Overview");

            entity.Property(e => e.IdOverview)
                .HasColumnName("idOverview");
            entity.Property(e => e.Cost).HasColumnName("cost");
            entity.Property(e => e.IdJob).HasColumnName("idJob");

            entity.HasOne(d => d.IdJobNavigation).WithMany(p => p.Overviews)
                .HasForeignKey(d => d.IdJob)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("Overview_Job");
        });

        modelBuilder.Entity<Painting>(entity =>
        {
            entity.HasKey(e => e.IdPainting).HasName("Painting_pk");

            entity.ToTable("Painting");

            entity.Property(e => e.IdPainting)
                .HasColumnName("idPainting");
            entity.Property(e => e.Colour)
                .HasMaxLength(7)
                .IsUnicode(false)
                .HasColumnName("colour");
        });

        modelBuilder.Entity<PaintingElement>(entity =>
        {
            entity.HasKey(e => new { e.IdElement, e.IdPainting, e.IdJob }).HasName("PaintingElement_pk");

            entity.ToTable("PaintingElement");

            entity.Property(e => e.IdElement).HasColumnName("idElement");
            entity.Property(e => e.IdPainting).HasColumnName("idPainting");
            entity.Property(e => e.IdJob).HasColumnName("idJob");

            entity.HasOne(d => d.IdElementNavigation).WithMany(p => p.PaintingElements)
                .HasForeignKey(d => d.IdElement)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("PaintingElement_Copy_of_Element");

            entity.HasOne(d => d.IdJobNavigation).WithMany(p => p.PaintingElements)
                .HasForeignKey(d => d.IdJob)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("PaintingElement_Job");

            entity.HasOne(d => d.IdPaintingNavigation).WithMany(p => p.PaintingElements)
                .HasForeignKey(d => d.IdPainting)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("PaintingElement_Copy_of_Painting");
        });

        modelBuilder.Entity<Part>(entity =>
        {
            entity.HasKey(e => e.IdPart).HasName("Part_pk");

            entity.ToTable("Part");

            entity.Property(e => e.IdPart)
                .HasColumnName("idPart");
            entity.Property(e => e.Cost).HasColumnName("cost");
            entity.Property(e => e.Name)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("name");
        });

        modelBuilder.Entity<PartsExchange>(entity =>
        {
            entity.HasKey(e => e.IdPartsExchange).HasName("PartsExchange_pk");

            entity.ToTable("PartsExchange");

            entity.Property(e => e.IdPartsExchange)
                .HasColumnName("idPartsExchange");
        });

        modelBuilder.Entity<Person>(entity =>
        {
            entity.HasKey(e => e.IdPerson).HasName("Person_pk");

            entity.ToTable("Person");

            entity.Property(e => e.IdPerson)
                .HasColumnName("idPerson");
            entity.Property(e => e.FirstName)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("firstName");
            entity.Property(e => e.LastName)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("lastName");
            entity.Property(e => e.PhoneNumber).HasColumnName("phoneNumber");
        });

        modelBuilder.Entity<Replacement>(entity =>
        {
            entity.HasKey(e => new { e.IdPartsExchange, e.IdJob, e.IdPart }).HasName("Replacement_pk");

            entity.ToTable("Replacement");

            entity.Property(e => e.IdPartsExchange).HasColumnName("idPartsExchange");
            entity.Property(e => e.IdJob).HasColumnName("idJob");
            entity.Property(e => e.IdPart).HasColumnName("idPart");

            entity.HasOne(d => d.IdJobNavigation).WithMany(p => p.Replacements)
                .HasForeignKey(d => d.IdJob)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("Replacement_Job");

            entity.HasOne(d => d.IdPartNavigation).WithMany(p => p.Replacements)
                .HasForeignKey(d => d.IdPart)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("Replacement_Part");

            entity.HasOne(d => d.IdPartsExchangeNavigation).WithMany(p => p.Replacements)
                .HasForeignKey(d => d.IdPartsExchange)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("Replacement_PartsExchange");
        });

        modelBuilder.Entity<Service>(entity =>
        {
            entity.HasKey(e => e.IdService).HasName("Service_pk");

            entity.ToTable("Service");

            entity.Property(e => e.IdService)
                .HasColumnName("idService");
            entity.Property(e => e.Address)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("address");
            entity.Property(e => e.Closing)
                .HasColumnType("datetime")
                .HasColumnName("closing");
            entity.Property(e => e.EmpAmount).HasColumnName("empAmount");
            entity.Property(e => e.MaxEmpAmount).HasColumnName("maxEmpAmount");
            entity.Property(e => e.Opening)
                .HasColumnType("datetime")
                .HasColumnName("opening");
            entity.Property(e => e.PhoneNumber)
                .HasMaxLength(15)
                .IsUnicode(false)
                .HasColumnName("phoneNumber");
        });

        modelBuilder.Entity<ServiceActivity>(entity =>
        {
            entity.HasKey(e => e.IdServiceActivity).HasName("ServiceActivity_pk");

            entity.ToTable("ServiceActivity");

            entity.Property(e => e.IdServiceActivity)
                .HasColumnName("idServiceActivity");
            entity.Property(e => e.DifficultyLevel).HasColumnName("difficultyLevel");
            entity.Property(e => e.ServiceDate).HasColumnName("serviceDate");
            entity.Property(e => e.IdOverview).HasColumnName("idOverview");
            entity.Property(e => e.IdPainting).HasColumnName("idPainting");
            entity.Property(e => e.IdPartsExchange).HasColumnName("idPartsExchange");
            entity.Property(e => e.Name).HasColumnName("name");

            entity.HasOne(d => d.IdOverviewNavigation).WithMany(p => p.ServiceActivities)
                .HasForeignKey(d => d.IdOverview)
                .HasConstraintName("ServiceActivity_Overview");

            entity.HasOne(d => d.IdPaintingNavigation).WithMany(p => p.ServiceActivities)
                .HasForeignKey(d => d.IdPainting)
                .HasConstraintName("ServiceActivity_Painting");

            entity.HasOne(d => d.IdPartsExchangeNavigation).WithMany(p => p.ServiceActivities)
                .HasForeignKey(d => d.IdPartsExchange)
                .HasConstraintName("ServiceActivity_PartsExchange");
        });

        modelBuilder.Entity<Serviceman>(entity =>
        {
            entity.HasKey(e => e.IdPerson).HasName("Serviceman_pk");

            entity.ToTable("Serviceman");

            entity.Property(e => e.IdPerson)
                .ValueGeneratedNever()
                .HasColumnName("idPerson");
            entity.Property(e => e.HireDate)
                .HasColumnType("date")
                .HasColumnName("hireDate");
            entity.Property(e => e.IdService).HasColumnName("idService");
            entity.Property(e => e.Pesel).HasColumnName("pesel");
            entity.Property(e => e.RepairAmount).HasColumnName("repairAmount");
            entity.Property(e => e.Skills).HasColumnName("skills");

            entity.HasOne(d => d.IdPersonNavigation).WithOne(p => p.Serviceman)
                .HasForeignKey<Serviceman>(d => d.IdPerson)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("Serviceman_Person");

            entity.HasOne(d => d.IdServiceNavigation).WithMany(p => p.Servicemen)
                .HasForeignKey(d => d.IdService)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("Serviceman_Service");
        });

        modelBuilder.Entity<Trainee>(entity =>
        {
            entity.HasKey(e => e.IdPerson).HasName("Trainee_pk");

            entity.ToTable("Trainee");

            entity.Property(e => e.IdPerson)
                .ValueGeneratedNever()
                .HasColumnName("idPerson");
            entity.Property(e => e.IdService).HasColumnName("idService");
            entity.Property(e => e.InternshipStartDate)
                .HasColumnType("date")
                .HasColumnName("internshipStartDate");
            entity.Property(e => e.LengthOfInternship).HasColumnName("lengthOfInternship");
            entity.Property(e => e.Salary).HasColumnName("salary");

            entity.HasOne(d => d.IdPersonNavigation).WithOne(p => p.Trainee)
                .HasForeignKey<Trainee>(d => d.IdPerson)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("Trainee_Person");

            entity.HasOne(d => d.IdServiceNavigation).WithMany(p => p.Trainees)
                .HasForeignKey(d => d.IdService)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("Trainee_Service");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
