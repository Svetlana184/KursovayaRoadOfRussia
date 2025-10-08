using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Session2.Model;

public partial class RoadOfRussiaContext : DbContext
{
    public RoadOfRussiaContext()
    {
        Database.EnsureCreated();
    }

    public RoadOfRussiaContext(DbContextOptions<RoadOfRussiaContext> options)
        : base(options)
    {
        Database.EnsureCreated();
    }

    public virtual DbSet<Calendar_> Calendars { get; set; }

    public virtual DbSet<Candidate> Candidates { get; set; }

    public virtual DbSet<Comment> Comments { get; set; }

    public virtual DbSet<Department> Departments { get; set; }

    public virtual DbSet<Employee> Employees { get; set; }

    public virtual DbSet<Event> Events { get; set; }

    public virtual DbSet<EventMaterial> EventMaterials { get; set; }

    public virtual DbSet<Material> Materials { get; set; }

    public virtual DbSet<WorkingCalendar> WorkingCalendars { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=RoadOfRussia.db");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Calendar_>(entity =>
        {
            entity.HasKey(e => e.IdCalendar);

            entity.ToTable("Calendar");

            entity.HasIndex(e => e.IdAlternate, "IX_Calendar_IdAlternate");

            entity.HasIndex(e => e.IdEmployee, "IX_Calendar_IdEmployee");

            entity.HasIndex(e => e.IdEvent, "IX_Calendar_IdEvent");

            entity.HasOne(d => d.IdAlternateNavigation).WithMany(p => p.CalendarIdAlternateNavigations).HasForeignKey(d => d.IdAlternate);

            entity.HasOne(d => d.IdEmployeeNavigation).WithMany(p => p.CalendarIdEmployeeNavigations).HasForeignKey(d => d.IdEmployee);

            entity.HasOne(d => d.IdEventNavigation).WithMany(p => p.Calendars).HasForeignKey(d => d.IdEvent);
        });

        modelBuilder.Entity<Candidate>(entity =>
        {
            entity.HasKey(e => e.IdCandidate);

            entity.ToTable("Candidate");
        });

        modelBuilder.Entity<Comment>(entity =>
        {
            entity.HasKey(e => e.IdComment);

            entity.ToTable("Comment");

            entity.HasIndex(e => e.AuthorOfComment, "IX_Comment_AuthorOfComment");

            entity.HasIndex(e => e.IdMaterial, "IX_Comment_IdMaterial");

            entity.Property(e => e.CommentText).HasColumnType("ntext");
            entity.Property(e => e.DateCreated).HasColumnType("datetime");
            entity.Property(e => e.DateUpdated).HasColumnType("datetime");

            entity.HasOne(d => d.AuthorOfCommentNavigation).WithMany(p => p.Comments)
                .HasForeignKey(d => d.AuthorOfComment)
                .OnDelete(DeleteBehavior.ClientSetNull);

            entity.HasOne(d => d.IdMaterialNavigation).WithMany(p => p.CommentsNavigation)
                .HasForeignKey(d => d.IdMaterial)
                .OnDelete(DeleteBehavior.ClientSetNull);
        });

        modelBuilder.Entity<Department>(entity =>
        {
            entity.HasKey(e => e.IdDepartment);

            entity.ToTable("Department");

            entity.HasIndex(e => e.IdEmployee, "IX_Department_IdEmployee");

            entity.Property(e => e.Description).HasColumnType("ntext");

            entity.HasOne(d => d.IdEmployeeNavigation).WithMany(p => p.Departments).HasForeignKey(d => d.IdEmployee);
        });

        modelBuilder.Entity<Employee>(entity =>
        {
            entity.HasKey(e => e.IdEmployee);

            entity.ToTable("Employee");

            entity.HasIndex(e => e.IdDepartment, "IX_Employee_IdDepartment");

            entity.Property(e => e.Password).HasColumnName("password");

            entity.HasOne(d => d.IdDepartmentNavigation).WithMany(p => p.Employees)
                .HasForeignKey(d => d.IdDepartment)
                .OnDelete(DeleteBehavior.ClientSetNull);
        });

        modelBuilder.Entity<Event>(entity =>
        {
            entity.HasKey(e => e.IdEvent);

            entity.ToTable("Event");

            entity.Property(e => e.DateOfEvent).HasColumnType("datetime");
            entity.Property(e => e.EventDescription).HasColumnType("ntext");
        });

        modelBuilder.Entity<EventMaterial>(entity =>
        {
            entity.HasKey(e => e.IdEventMaterial);

            entity.ToTable("EventMaterial");

            entity.HasIndex(e => e.IdEvent, "IX_EventMaterial_IdEvent");

            entity.HasIndex(e => e.IdMaterial, "IX_EventMaterial_IdMaterial");

            entity.HasOne(d => d.IdEventNavigation).WithMany(p => p.EventMaterials)
                .HasForeignKey(d => d.IdEvent)
                .OnDelete(DeleteBehavior.ClientSetNull);

            entity.HasOne(d => d.IdMaterialNavigation).WithMany(p => p.EventMaterials)
                .HasForeignKey(d => d.IdMaterial)
                .OnDelete(DeleteBehavior.ClientSetNull);
        });

        modelBuilder.Entity<Material>(entity =>
        {
            entity.HasKey(e => e.IdMaterial);

            entity.ToTable("Material");

            entity.Property(e => e.DateApproval).HasColumnType("datetime");
            entity.Property(e => e.DateChanges).HasColumnType("datetime");
        });

        modelBuilder.Entity<WorkingCalendar>(entity =>
        {
            entity.ToTable("WorkingCalendar");

            entity.Property(e => e.Id).ValueGeneratedNever();
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
