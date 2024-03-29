using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace HelloDoc.Models;

public partial class HelloDocContext : DbContext
{
    public HelloDocContext()
    {
    }

    public HelloDocContext(DbContextOptions<HelloDocContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Admin> Admins { get; set; }

    public virtual DbSet<AspNetUser> AspNetUsers { get; set; }

    public virtual DbSet<Concierge> Concierges { get; set; }

    public virtual DbSet<Physician> Physicians { get; set; }

    public virtual DbSet<Region> Regions { get; set; }

    public virtual DbSet<Request> Requests { get; set; }

    public virtual DbSet<RequestClient> RequestClients { get; set; }

    public virtual DbSet<RequestWiseFile> RequestWiseFiles { get; set; }

    public virtual DbSet<User> Users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("server=(localdb)\\MSSQLLocalDB; database=HelloDoc; trusted_connection=true;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Admin>(entity =>
        {
            entity.HasKey(e => e.Adminld).HasName("PK__Admin__719D1B73272865D6");

            entity.ToTable("Admin");

            entity.Property(e => e.Address1).HasMaxLength(500);
            entity.Property(e => e.Address2).HasMaxLength(500);
            entity.Property(e => e.AltPhone).HasMaxLength(20);
            entity.Property(e => e.AspNetUserld).HasMaxLength(128);
            entity.Property(e => e.City).HasMaxLength(100);
            entity.Property(e => e.CreatedBy).HasMaxLength(128);
            entity.Property(e => e.CreatedDate).HasColumnType("datetime");
            entity.Property(e => e.Email).HasMaxLength(50);
            entity.Property(e => e.FirstName).HasMaxLength(100);
            entity.Property(e => e.LastName).HasMaxLength(100);
            entity.Property(e => e.Mobile).HasMaxLength(20);
            entity.Property(e => e.ModifiedBy).HasMaxLength(128);
            entity.Property(e => e.ModifiedDate).HasColumnType("datetime");
            entity.Property(e => e.Zip).HasMaxLength(10);

            entity.HasOne(d => d.AspNetUserldNavigation).WithMany(p => p.AdminAspNetUserldNavigations)
                .HasForeignKey(d => d.AspNetUserld)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Admin__AspNetUse__38996AB5");

            entity.HasOne(d => d.ModifiedByNavigation).WithMany(p => p.AdminModifiedByNavigations)
                .HasForeignKey(d => d.ModifiedBy)
                .HasConstraintName("FK__Admin__ModifiedB__398D8EEE");
        });

        modelBuilder.Entity<AspNetUser>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__AspNetUs__3214EC07341C9190");

            entity.Property(e => e.Id).HasMaxLength(128);
            entity.Property(e => e.CreatedDate).HasColumnType("datetime");
            entity.Property(e => e.Email).HasMaxLength(256);
            entity.Property(e => e.Ip)
                .HasMaxLength(20)
                .HasColumnName("IP");
            entity.Property(e => e.ModifiedDate).HasColumnType("datetime");
            entity.Property(e => e.PhoneNumber).HasMaxLength(20);
            entity.Property(e => e.UserName).HasMaxLength(256);
        });

        modelBuilder.Entity<Concierge>(entity =>
        {
            entity.HasKey(e => e.ConciergeId).HasName("PK__Concierg__8BCFB3F4B3CDB2CA");

            entity.ToTable("Concierge");

            entity.Property(e => e.ConciergeId).ValueGeneratedNever();
            entity.Property(e => e.Address).HasMaxLength(150);
            entity.Property(e => e.City).HasMaxLength(50);
            entity.Property(e => e.ConciergeName).HasMaxLength(100);
            entity.Property(e => e.CreatedDate).HasColumnType("datetime");
            entity.Property(e => e.State).HasMaxLength(50);
            entity.Property(e => e.Street).HasMaxLength(50);
            entity.Property(e => e.ZipCode).HasMaxLength(50);

            entity.HasOne(d => d.Region).WithMany(p => p.Concierges)
                .HasForeignKey(d => d.RegionId)
                .HasConstraintName("FK__Concierge__Regio__49C3F6B7");
        });

        modelBuilder.Entity<Physician>(entity =>
        {
            entity.HasKey(e => e.PhysicianId).HasName("PK__Physicia__DFF5D293C59864F4");

            entity.ToTable("Physician");

            entity.Property(e => e.Address1).HasMaxLength(500);
            entity.Property(e => e.Address2).HasMaxLength(500);
            entity.Property(e => e.AdminNotes).HasMaxLength(500);
            entity.Property(e => e.AltPhone).HasMaxLength(20);
            entity.Property(e => e.AspNetUserId).HasMaxLength(128);
            entity.Property(e => e.BusinessName).HasMaxLength(100);
            entity.Property(e => e.BusinessWebsite).HasMaxLength(200);
            entity.Property(e => e.City).HasMaxLength(100);
            entity.Property(e => e.CreatedBy).HasMaxLength(128);
            entity.Property(e => e.CreatedDate).HasColumnType("datetime");
            entity.Property(e => e.Email).HasMaxLength(50);
            entity.Property(e => e.FirstName).HasMaxLength(100);
            entity.Property(e => e.LastName).HasMaxLength(100);
            entity.Property(e => e.MedicalLicense).HasMaxLength(500);
            entity.Property(e => e.Mobile).HasMaxLength(20);
            entity.Property(e => e.ModifiedBy).HasMaxLength(128);
            entity.Property(e => e.ModifiedDate).HasColumnType("datetime");
            entity.Property(e => e.Npinumber)
                .HasMaxLength(500)
                .HasColumnName("NPINumber");
            entity.Property(e => e.Photo).HasMaxLength(100);
            entity.Property(e => e.Signature).HasMaxLength(100);
            entity.Property(e => e.SyncEmailAddress).HasMaxLength(50);
            entity.Property(e => e.Zip).HasMaxLength(10);

            entity.HasOne(d => d.AspNetUser).WithMany(p => p.PhysicianAspNetUsers)
                .HasForeignKey(d => d.AspNetUserId)
                .HasConstraintName("FK__Physician__AspNe__286302EC");

            entity.HasOne(d => d.CreatedByNavigation).WithMany(p => p.PhysicianCreatedByNavigations)
                .HasForeignKey(d => d.CreatedBy)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Physician__Creat__29572725");

            entity.HasOne(d => d.ModifiedByNavigation).WithMany(p => p.PhysicianModifiedByNavigations)
                .HasForeignKey(d => d.ModifiedBy)
                .HasConstraintName("FK__Physician__Modif__2A4B4B5E");
        });

        modelBuilder.Entity<Region>(entity =>
        {
            entity.HasKey(e => e.RegionId).HasName("PK__Region__ACD844A3D714A5B1");

            entity.ToTable("Region");

            entity.Property(e => e.Abbreviation).HasMaxLength(50);
            entity.Property(e => e.Name).HasMaxLength(50);
        });

        modelBuilder.Entity<Request>(entity =>
        {
            entity.HasKey(e => e.RequestId).HasName("PK__Request__33A8517AF3753BD0");

            entity.ToTable("Request");

            entity.Property(e => e.AcceptedDate).HasColumnType("datetime");
            entity.Property(e => e.CaseNumber).HasMaxLength(50);
            entity.Property(e => e.CaseTag).HasMaxLength(50);
            entity.Property(e => e.CaseTagPhysician).HasMaxLength(50);
            entity.Property(e => e.ConfirmationNumber).HasMaxLength(20);
            entity.Property(e => e.CreatedDate).HasColumnType("datetime");
            entity.Property(e => e.DeclinedBy)
                .HasMaxLength(250)
                .IsUnicode(false);
            entity.Property(e => e.Email).HasMaxLength(50);
            entity.Property(e => e.FirstName).HasMaxLength(100);
            entity.Property(e => e.Ip)
                .HasMaxLength(20)
                .HasColumnName("IP");
            entity.Property(e => e.LastName).HasMaxLength(100);
            entity.Property(e => e.LastReservationDate).HasColumnType("datetime");
            entity.Property(e => e.LastWellnessDate).HasColumnType("datetime");
            entity.Property(e => e.ModifiedDate).HasColumnType("datetime");
            entity.Property(e => e.PhoneNumber).HasMaxLength(23);
            entity.Property(e => e.RelationName).HasMaxLength(100);
            entity.Property(e => e.RequestTypeId).HasDefaultValueSql("(NEXT VALUE FOR [RequestTypeIdSequence])");

            entity.HasOne(d => d.Physician).WithMany(p => p.Requests)
                .HasForeignKey(d => d.PhysicianId)
                .HasConstraintName("FK__Request__Physici__300424B4");

            entity.HasOne(d => d.User).WithMany(p => p.Requests)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("FK__Request__UserId__2F10007B");
        });

        modelBuilder.Entity<RequestClient>(entity =>
        {
            entity.HasKey(e => e.RequestClientId).HasName("PK__RequestC__7BB6396D1E0ECBA6");

            entity.ToTable("RequestClient");

            entity.Property(e => e.Address).HasMaxLength(500);
            entity.Property(e => e.City).HasMaxLength(100);
            entity.Property(e => e.Email).HasMaxLength(500);
            entity.Property(e => e.FirstName).HasMaxLength(100);
            entity.Property(e => e.IntDate).HasColumnName("intDate");
            entity.Property(e => e.IntYear).HasColumnName("intYear");
            entity.Property(e => e.Ip)
                .HasMaxLength(20)
                .HasColumnName("IP");
            entity.Property(e => e.LastName).HasMaxLength(100);
            entity.Property(e => e.Latitude).HasColumnType("decimal(9, 0)");
            entity.Property(e => e.Location).HasMaxLength(100);
            entity.Property(e => e.Longitude).HasColumnType("decimal(9, 0)");
            entity.Property(e => e.Notes).HasMaxLength(500);
            entity.Property(e => e.NotiEmail).HasMaxLength(50);
            entity.Property(e => e.NotiMobile).HasMaxLength(20);
            entity.Property(e => e.PhoneNumber).HasMaxLength(23);
            entity.Property(e => e.State).HasMaxLength(100);
            entity.Property(e => e.StrMonth)
                .HasMaxLength(20)
                .HasColumnName("strMonth");
            entity.Property(e => e.Street).HasMaxLength(100);
            entity.Property(e => e.ZipCode).HasMaxLength(10);

            entity.HasOne(d => d.Region).WithMany(p => p.RequestClients)
                .HasForeignKey(d => d.RegionId)
                .HasConstraintName("FK__RequestCl__Regio__35BCFE0A");

            entity.HasOne(d => d.Request).WithMany(p => p.RequestClients)
                .HasForeignKey(d => d.RequestId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__RequestCl__Reque__34C8D9D1");
        });

        modelBuilder.Entity<RequestWiseFile>(entity =>
        {
            entity.HasKey(e => e.RequestWiseFileId).HasName("PK__RequestW__C2397E8BCCD24BA8");

            entity.ToTable("RequestWiseFile");

            entity.Property(e => e.RequestWiseFileId).HasColumnName("RequestWiseFileID");
            entity.Property(e => e.CreatedDate).HasColumnType("datetime");
            entity.Property(e => e.FileName).HasMaxLength(500);
            entity.Property(e => e.Ip)
                .HasMaxLength(20)
                .HasColumnName("IP");

            entity.HasOne(d => d.AdminldNavigation).WithMany(p => p.RequestWiseFiles)
                .HasForeignKey(d => d.Adminld)
                .HasConstraintName("FK__RequestWi__Admin__3E52440B");

            entity.HasOne(d => d.PhysicianldNavigation).WithMany(p => p.RequestWiseFiles)
                .HasForeignKey(d => d.Physicianld)
                .HasConstraintName("FK__RequestWi__Physi__3D5E1FD2");

            entity.HasOne(d => d.Request).WithMany(p => p.RequestWiseFiles)
                .HasForeignKey(d => d.Requestid)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__RequestWi__Reque__3C69FB99");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.UserId).HasName("PK__User__1788CC4C58BD860E");

            entity.ToTable("User");

            entity.Property(e => e.AspNetUserId).HasMaxLength(128);
            entity.Property(e => e.BirthDate).HasColumnType("datetime");
            entity.Property(e => e.City).HasMaxLength(50);
            entity.Property(e => e.CreatedBy).HasMaxLength(256);
            entity.Property(e => e.CreatedDate).HasColumnType("datetime");
            entity.Property(e => e.Email).HasMaxLength(256);
            entity.Property(e => e.FirstName).HasMaxLength(100);
            entity.Property(e => e.IntDate).HasColumnName("intDate");
            entity.Property(e => e.IntYear).HasColumnName("intYear");
            entity.Property(e => e.Ip)
                .HasMaxLength(20)
                .HasColumnName("IP");
            entity.Property(e => e.LastName).HasMaxLength(100);
            entity.Property(e => e.Mobile).HasMaxLength(20);
            entity.Property(e => e.ModifiedBy).HasMaxLength(256);
            entity.Property(e => e.ModifiedDate).HasColumnType("datetime");
            entity.Property(e => e.State).HasMaxLength(20);
            entity.Property(e => e.StrMonth)
                .HasMaxLength(20)
                .HasColumnName("strMonth");
            entity.Property(e => e.Street).HasMaxLength(100);
            entity.Property(e => e.ZipCode).HasMaxLength(10);

            entity.HasOne(d => d.AspNetUser).WithMany(p => p.Users)
                .HasForeignKey(d => d.AspNetUserId)
                .HasConstraintName("FK__User__AspNetUser__25869641");
        });
        modelBuilder.HasSequence("RequestTypeIdSequence");

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
