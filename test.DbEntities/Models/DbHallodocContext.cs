﻿using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace test.DbEntities.Models;

public partial class DbHallodocContext : DbContext
{
    public DbHallodocContext()
    {
    }

    public DbHallodocContext(DbContextOptions<DbHallodocContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Admin> Admins { get; set; }

    public virtual DbSet<AdminRegion> AdminRegions { get; set; }

    public virtual DbSet<AspNetRole> AspNetRoles { get; set; }

    public virtual DbSet<AspNetUser> AspNetUsers { get; set; }

    public virtual DbSet<AspNetUserRole> AspNetUserRoles { get; set; }

    public virtual DbSet<BlockRequest> BlockRequests { get; set; }

    public virtual DbSet<Business> Businesses { get; set; }

    public virtual DbSet<CaseTag> CaseTags { get; set; }

    public virtual DbSet<Chat> Chats { get; set; }

    public virtual DbSet<Concierge> Concierges { get; set; }

    public virtual DbSet<EmailLog> EmailLogs { get; set; }

    public virtual DbSet<EncounterForm> EncounterForms { get; set; }

    public virtual DbSet<HealthProfessional> HealthProfessionals { get; set; }

    public virtual DbSet<HealthProfessionalType> HealthProfessionalTypes { get; set; }

    public virtual DbSet<Menu> Menus { get; set; }

    public virtual DbSet<OrderDetail> OrderDetails { get; set; }

    public virtual DbSet<Payrate> Payrates { get; set; }

    public virtual DbSet<Physician> Physicians { get; set; }

    public virtual DbSet<PhysicianLocation> PhysicianLocations { get; set; }

    public virtual DbSet<PhysicianNotification> PhysicianNotifications { get; set; }

    public virtual DbSet<PhysicianRegion> PhysicianRegions { get; set; }

    public virtual DbSet<Region> Regions { get; set; }

    public virtual DbSet<Request> Requests { get; set; }

    public virtual DbSet<RequestBusiness> RequestBusinesses { get; set; }

    public virtual DbSet<RequestClient> RequestClients { get; set; }

    public virtual DbSet<RequestClosed> RequestCloseds { get; set; }

    public virtual DbSet<RequestConcierge> RequestConcierges { get; set; }

    public virtual DbSet<RequestNote> RequestNotes { get; set; }

    public virtual DbSet<RequestStatusLog> RequestStatusLogs { get; set; }

    public virtual DbSet<RequestType> RequestTypes { get; set; }

    public virtual DbSet<RequestWiseFile> RequestWiseFiles { get; set; }

    public virtual DbSet<Role> Roles { get; set; }

    public virtual DbSet<RoleMenu> RoleMenus { get; set; }

    public virtual DbSet<Shift> Shifts { get; set; }

    public virtual DbSet<ShiftDetail> ShiftDetails { get; set; }

    public virtual DbSet<ShiftDetailRegion> ShiftDetailRegions { get; set; }

    public virtual DbSet<Smslog> Smslogs { get; set; }

    public virtual DbSet<Timesheet> Timesheets { get; set; }

    public virtual DbSet<TimesheetDetail> TimesheetDetails { get; set; }

    public virtual DbSet<TimesheetReimbursement> TimesheetReimbursements { get; set; }

    public virtual DbSet<User> Users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseNpgsql("Host=localhost;Database=Db_hallodoc;Username=postgres;Password=tatva123");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Admin>(entity =>
        {
            entity.HasKey(e => e.AdminId).HasName("Admin_pkey");

            entity.ToTable("Admin");

            entity.Property(e => e.Address1).HasMaxLength(500);
            entity.Property(e => e.Address2).HasMaxLength(500);
            entity.Property(e => e.AltPhone).HasMaxLength(20);
            entity.Property(e => e.AspNetUserId).HasMaxLength(128);
            entity.Property(e => e.City).HasMaxLength(100);
            entity.Property(e => e.CreatedBy).HasMaxLength(128);
            entity.Property(e => e.CreatedDate).HasColumnType("timestamp without time zone");
            entity.Property(e => e.Email).HasMaxLength(50);
            entity.Property(e => e.FirstName).HasMaxLength(100);
            entity.Property(e => e.IsDeleted).HasColumnType("bit(1)");
            entity.Property(e => e.LastName).HasMaxLength(100);
            entity.Property(e => e.Mobile).HasMaxLength(20);
            entity.Property(e => e.ModifiedBy).HasMaxLength(128);
            entity.Property(e => e.ModifiedDate).HasColumnType("timestamp without time zone");
            entity.Property(e => e.Zip).HasMaxLength(10);

            entity.HasOne(d => d.AspNetUser).WithMany(p => p.AdminAspNetUsers)
                .HasForeignKey(d => d.AspNetUserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("Admin_AspNetUserId_fkey");

            entity.HasOne(d => d.ModifiedByNavigation).WithMany(p => p.AdminModifiedByNavigations)
                .HasForeignKey(d => d.ModifiedBy)
                .HasConstraintName("Admin_ModifiedBy_fkey");
        });

        modelBuilder.Entity<AdminRegion>(entity =>
        {
            entity.HasKey(e => e.AdminRegionId).HasName("AdminRegion_pkey");

            entity.ToTable("AdminRegion");

            entity.HasOne(d => d.Admin).WithMany(p => p.AdminRegions)
                .HasForeignKey(d => d.AdminId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_AdminRegion_AdminId");

            entity.HasOne(d => d.Region).WithMany(p => p.AdminRegions)
                .HasForeignKey(d => d.RegionId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_AdminRegion_RegionId");
        });

        modelBuilder.Entity<AspNetRole>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("AspNetRoles_pkey");

            entity.Property(e => e.Id).HasMaxLength(128);
            entity.Property(e => e.Name).HasMaxLength(256);
        });

        modelBuilder.Entity<AspNetUser>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("AspNetUsers_pkey");

            entity.Property(e => e.Id).HasMaxLength(128);
            entity.Property(e => e.CreatedDate).HasColumnType("timestamp without time zone");
            entity.Property(e => e.Email).HasMaxLength(256);
            entity.Property(e => e.Ip)
                .HasMaxLength(20)
                .HasColumnName("IP");
            entity.Property(e => e.ModifiedDate).HasColumnType("timestamp without time zone");
            entity.Property(e => e.PasswordHash).HasColumnType("character varying");
            entity.Property(e => e.PhoneNumber).HasMaxLength(20);
            entity.Property(e => e.UserName).HasMaxLength(256);
        });

        modelBuilder.Entity<AspNetUserRole>(entity =>
        {
            entity.HasKey(e => new { e.UserId, e.RoleId }).HasName("AspNetUserRoles_pkey");

            entity.Property(e => e.UserId).HasMaxLength(128);
            entity.Property(e => e.RoleId).HasMaxLength(128);

            entity.HasOne(d => d.User).WithMany(p => p.AspNetUserRoles)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("AspNetUserRoles_UserId_fkey");
        });

        modelBuilder.Entity<BlockRequest>(entity =>
        {
            entity.HasKey(e => e.BlockRequestId).HasName("BlockRequests_pkey");

            entity.Property(e => e.CreatedDate).HasColumnType("timestamp without time zone");
            entity.Property(e => e.Email).HasMaxLength(50);
            entity.Property(e => e.Ip)
                .HasMaxLength(20)
                .HasColumnName("IP");
            entity.Property(e => e.ModifiedDate).HasColumnType("timestamp without time zone");
            entity.Property(e => e.PhoneNumber).HasMaxLength(50);
            entity.Property(e => e.Reason).HasColumnType("character varying");

            entity.HasOne(d => d.Request).WithMany(p => p.BlockRequests)
                .HasForeignKey(d => d.RequestId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("BlockRequests_RequestId_fkey");
        });

        modelBuilder.Entity<Business>(entity =>
        {
            entity.HasKey(e => e.BusinessId).HasName("Business_pkey");

            entity.ToTable("Business");

            entity.Property(e => e.Address1).HasMaxLength(500);
            entity.Property(e => e.Address2).HasMaxLength(500);
            entity.Property(e => e.City).HasMaxLength(50);
            entity.Property(e => e.CreatedBy).HasMaxLength(128);
            entity.Property(e => e.CreatedDate).HasColumnType("timestamp without time zone");
            entity.Property(e => e.FaxNumber).HasMaxLength(20);
            entity.Property(e => e.Ip)
                .HasMaxLength(20)
                .HasColumnName("IP");
            entity.Property(e => e.ModifiedBy).HasMaxLength(128);
            entity.Property(e => e.ModifiedDate).HasColumnType("timestamp without time zone");
            entity.Property(e => e.Name).HasMaxLength(100);
            entity.Property(e => e.PhoneNumber).HasMaxLength(20);
            entity.Property(e => e.ZipCode).HasMaxLength(10);

            entity.HasOne(d => d.CreatedByNavigation).WithMany(p => p.BusinessCreatedByNavigations)
                .HasForeignKey(d => d.CreatedBy)
                .HasConstraintName("Business_CreatedBy_fkey");

            entity.HasOne(d => d.ModifiedByNavigation).WithMany(p => p.BusinessModifiedByNavigations)
                .HasForeignKey(d => d.ModifiedBy)
                .HasConstraintName("Business_ModifiedBy_fkey");

            entity.HasOne(d => d.Region).WithMany(p => p.Businesses)
                .HasForeignKey(d => d.RegionId)
                .HasConstraintName("Business_RegionId_fkey");
        });

        modelBuilder.Entity<CaseTag>(entity =>
        {
            entity.HasKey(e => e.CaseTagId).HasName("CaseTag_pkey");

            entity.ToTable("CaseTag");

            entity.Property(e => e.Name).HasMaxLength(50);
        });

        modelBuilder.Entity<Chat>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("chat_pkey");

            entity.ToTable("chat");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Message)
                .HasColumnType("character varying")
                .HasColumnName("message");
            entity.Property(e => e.Receiverid)
                .HasColumnType("character varying")
                .HasColumnName("receiverid");
            entity.Property(e => e.Senderid)
                .HasColumnType("character varying")
                .HasColumnName("senderid");
            entity.Property(e => e.Sentdate)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("sentdate");
            entity.Property(e => e.Senttime).HasColumnName("senttime");

            entity.HasOne(d => d.Receiver).WithMany(p => p.ChatReceivers)
                .HasForeignKey(d => d.Receiverid)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("chat_receiverid_fkey");

            entity.HasOne(d => d.Sender).WithMany(p => p.ChatSenders)
                .HasForeignKey(d => d.Senderid)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("chat_senderid_fkey");
        });

        modelBuilder.Entity<Concierge>(entity =>
        {
            entity.HasKey(e => e.ConciergeId).HasName("Concierge_pkey");

            entity.ToTable("Concierge");

            entity.Property(e => e.Address).HasMaxLength(150);
            entity.Property(e => e.City).HasMaxLength(50);
            entity.Property(e => e.ConciergeName).HasMaxLength(100);
            entity.Property(e => e.CreatedDate).HasColumnType("timestamp without time zone");
            entity.Property(e => e.RoleId).HasMaxLength(20);
            entity.Property(e => e.State).HasMaxLength(50);
            entity.Property(e => e.Street).HasMaxLength(50);
            entity.Property(e => e.ZipCode).HasMaxLength(50);

            entity.HasOne(d => d.Region).WithMany(p => p.Concierges)
                .HasForeignKey(d => d.RegionId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("Concierge_RegionId_fkey");
        });

        modelBuilder.Entity<EmailLog>(entity =>
        {
            entity.HasKey(e => e.EmailLogId).HasName("EmailLog_pkey");

            entity.ToTable("EmailLog");

            entity.Property(e => e.EmailLogId)
                .HasPrecision(9)
                .HasColumnName("EmailLogID");
            entity.Property(e => e.ConfirmationNumber).HasMaxLength(200);
            entity.Property(e => e.CreateDate).HasColumnType("timestamp without time zone");
            entity.Property(e => e.EmailId)
                .HasMaxLength(200)
                .HasColumnName("EmailID");
            entity.Property(e => e.EmailTemplate).HasColumnType("character varying");
            entity.Property(e => e.FilePath).HasColumnType("character varying");
            entity.Property(e => e.SentDate).HasColumnType("timestamp without time zone");
            entity.Property(e => e.SubjectName).HasMaxLength(200);
        });

        modelBuilder.Entity<EncounterForm>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("EncounterForm_pkey");

            entity.ToTable("EncounterForm");

            entity.Property(e => e.Abd).HasColumnName("ABD");
            entity.Property(e => e.BpD).HasColumnName("BP(D)");
            entity.Property(e => e.BpS).HasColumnName("BP(S)");
            entity.Property(e => e.Cv).HasColumnName("CV");
            entity.Property(e => e.Date).HasColumnType("timestamp without time zone");
            entity.Property(e => e.FollowUp).HasColumnName("Follow_up");
            entity.Property(e => e.Heent).HasColumnName("HEENT");
            entity.Property(e => e.HistoryIllness).HasColumnName("history_illness");
            entity.Property(e => e.Hr).HasColumnName("HR");
            entity.Property(e => e.IsFinalized)
                .HasDefaultValueSql("'0'::\"bit\"")
                .HasColumnType("bit(1)")
                .HasColumnName("isFinalized");
            entity.Property(e => e.MedicalHistory).HasColumnName("medical_history");
            entity.Property(e => e.MedicationDispensed).HasColumnName("medication_dispensed");
            entity.Property(e => e.Procedures).HasColumnName("procedures");
            entity.Property(e => e.Rr).HasColumnName("RR");
            entity.Property(e => e.TreatmentPlan).HasColumnName("Treatment_Plan");

            entity.HasOne(d => d.Request).WithMany(p => p.EncounterForms)
                .HasForeignKey(d => d.RequestId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_encounter_request");
        });

        modelBuilder.Entity<HealthProfessional>(entity =>
        {
            entity.HasKey(e => e.VendorId).HasName("HealthProfessionals_pkey");

            entity.Property(e => e.Address).HasMaxLength(150);
            entity.Property(e => e.BusinessContact).HasMaxLength(100);
            entity.Property(e => e.City).HasMaxLength(100);
            entity.Property(e => e.CreatedDate).HasColumnType("timestamp without time zone");
            entity.Property(e => e.Email).HasMaxLength(50);
            entity.Property(e => e.FaxNumber).HasMaxLength(50);
            entity.Property(e => e.Ip)
                .HasMaxLength(20)
                .HasColumnName("IP");
            entity.Property(e => e.ModifiedDate).HasColumnType("timestamp without time zone");
            entity.Property(e => e.PhoneNumber).HasMaxLength(100);
            entity.Property(e => e.State).HasMaxLength(50);
            entity.Property(e => e.VendorName).HasMaxLength(100);
            entity.Property(e => e.Zip).HasMaxLength(50);

            entity.HasOne(d => d.ProfessionNavigation).WithMany(p => p.HealthProfessionals)
                .HasForeignKey(d => d.Profession)
                .HasConstraintName("HealthProfessionals_Profession_fkey");
        });

        modelBuilder.Entity<HealthProfessionalType>(entity =>
        {
            entity.HasKey(e => e.HealthProfessionalId).HasName("HealthProfessionalType_pkey");

            entity.ToTable("HealthProfessionalType");

            entity.Property(e => e.CreatedDate).HasColumnType("timestamp without time zone");
            entity.Property(e => e.ProfessionName).HasMaxLength(50);
        });

        modelBuilder.Entity<Menu>(entity =>
        {
            entity.HasKey(e => e.MenuId).HasName("Menu_pkey");

            entity.ToTable("Menu");

            entity.Property(e => e.Name).HasMaxLength(50);
        });

        modelBuilder.Entity<OrderDetail>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("OrderDetails_pkey");

            entity.Property(e => e.BusinessContact).HasMaxLength(100);
            entity.Property(e => e.CreatedBy).HasMaxLength(100);
            entity.Property(e => e.CreatedDate).HasColumnType("timestamp without time zone");
            entity.Property(e => e.Email).HasMaxLength(50);
            entity.Property(e => e.FaxNumber).HasMaxLength(50);
            entity.Property(e => e.Prescription).HasColumnType("character varying");
        });

        modelBuilder.Entity<Payrate>(entity =>
        {
            entity.HasKey(e => e.PayrateId).HasName("Payrate_pkey");

            entity.ToTable("Payrate");

            entity.Property(e => e.BatchTesting).HasDefaultValueSql("0");
            entity.Property(e => e.Housecall).HasDefaultValueSql("0");
            entity.Property(e => e.HousecallNightWeekend).HasDefaultValueSql("0");
            entity.Property(e => e.NightShiftWeekend).HasDefaultValueSql("0");
            entity.Property(e => e.Phoneconsult).HasDefaultValueSql("0");
            entity.Property(e => e.PhoneconsultNightWeekend).HasDefaultValueSql("0");
            entity.Property(e => e.Shift).HasDefaultValueSql("0");

            entity.HasOne(d => d.Physician).WithMany(p => p.Payrates)
                .HasForeignKey(d => d.PhysicianId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("Payrate_PhysicianId_fkey");
        });

        modelBuilder.Entity<Physician>(entity =>
        {
            entity.HasKey(e => e.PhysicianId).HasName("Physician_pkey");

            entity.ToTable("Physician");

            entity.Property(e => e.PhysicianId)
                .UseIdentityAlwaysColumn()
                .HasIdentityOptions(20L, null, null, null, null, null);
            entity.Property(e => e.Address1).HasMaxLength(500);
            entity.Property(e => e.Address2).HasMaxLength(500);
            entity.Property(e => e.AdminNotes).HasMaxLength(500);
            entity.Property(e => e.AltPhone).HasMaxLength(20);
            entity.Property(e => e.AspNetUserId).HasMaxLength(128);
            entity.Property(e => e.BusinessName).HasMaxLength(100);
            entity.Property(e => e.BusinessWebsite).HasMaxLength(200);
            entity.Property(e => e.City).HasMaxLength(100);
            entity.Property(e => e.CreatedBy).HasMaxLength(128);
            entity.Property(e => e.CreatedDate).HasColumnType("timestamp without time zone");
            entity.Property(e => e.Email).HasMaxLength(50);
            entity.Property(e => e.FirstName).HasMaxLength(100);
            entity.Property(e => e.LastName).HasMaxLength(100);
            entity.Property(e => e.MedicalLicense).HasMaxLength(500);
            entity.Property(e => e.Mobile).HasMaxLength(20);
            entity.Property(e => e.ModifiedBy).HasMaxLength(128);
            entity.Property(e => e.ModifiedDate).HasColumnType("timestamp without time zone");
            entity.Property(e => e.Npinumber)
                .HasMaxLength(500)
                .HasColumnName("NPINumber");
            entity.Property(e => e.Photo).HasMaxLength(100);
            entity.Property(e => e.Signature).HasMaxLength(100);
            entity.Property(e => e.SyncEmailAddress).HasMaxLength(50);
            entity.Property(e => e.Zip).HasMaxLength(10);

            entity.HasOne(d => d.AspNetUser).WithMany(p => p.PhysicianAspNetUsers)
                .HasForeignKey(d => d.AspNetUserId)
                .HasConstraintName("Physician_AspNetUserId_fkey");

            entity.HasOne(d => d.CreatedByNavigation).WithMany(p => p.PhysicianCreatedByNavigations)
                .HasForeignKey(d => d.CreatedBy)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("Physician_CreatedBy_fkey");

            entity.HasOne(d => d.ModifiedByNavigation).WithMany(p => p.PhysicianModifiedByNavigations)
                .HasForeignKey(d => d.ModifiedBy)
                .HasConstraintName("Physician_ModifiedBy_fkey");
        });

        modelBuilder.Entity<PhysicianLocation>(entity =>
        {
            entity.HasKey(e => e.LocationId).HasName("PhysicianLocation_pkey");

            entity.ToTable("PhysicianLocation");

            entity.Property(e => e.Address).HasMaxLength(500);
            entity.Property(e => e.CreatedDate).HasColumnType("timestamp without time zone");
            entity.Property(e => e.Latitude).HasPrecision(11, 8);
            entity.Property(e => e.Longitude).HasPrecision(11, 8);
            entity.Property(e => e.PhysicianName).HasMaxLength(50);

            entity.HasOne(d => d.Physician).WithMany(p => p.PhysicianLocations)
                .HasForeignKey(d => d.PhysicianId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("PhysicianLocation_PhysicianId_fkey");
        });

        modelBuilder.Entity<PhysicianNotification>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PhysicianNotification_pkey");

            entity.ToTable("PhysicianNotification");

            entity.Property(e => e.Id).HasColumnName("id");

            entity.HasOne(d => d.Physician).WithMany(p => p.PhysicianNotifications)
                .HasForeignKey(d => d.PhysicianId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("PhysicianNotification_PhysicianId_fkey");
        });

        modelBuilder.Entity<PhysicianRegion>(entity =>
        {
            entity.HasKey(e => e.PhysicianRegionId).HasName("PhysicianRegion_pkey");

            entity.ToTable("PhysicianRegion");

            entity.HasOne(d => d.Physician).WithMany(p => p.PhysicianRegions)
                .HasForeignKey(d => d.PhysicianId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("PhysicianRegion_PhysicianId_fkey");

            entity.HasOne(d => d.Region).WithMany(p => p.PhysicianRegions)
                .HasForeignKey(d => d.RegionId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("PhysicianRegion_RegionId_fkey");
        });

        modelBuilder.Entity<Region>(entity =>
        {
            entity.HasKey(e => e.RegionId).HasName("Region_pkey");

            entity.ToTable("Region");

            entity.Property(e => e.Abbreviation).HasMaxLength(50);
            entity.Property(e => e.Name).HasMaxLength(50);
        });

        modelBuilder.Entity<Request>(entity =>
        {
            entity.HasKey(e => e.RequestId).HasName("Request_pkey");

            entity.ToTable("Request");

            entity.Property(e => e.AcceptedDate).HasColumnType("timestamp without time zone");
            entity.Property(e => e.CaseNumber).HasMaxLength(50);
            entity.Property(e => e.CaseTagPhysician).HasMaxLength(50);
            entity.Property(e => e.ConfirmationNumber).HasMaxLength(20);
            entity.Property(e => e.CreatedDate).HasColumnType("timestamp without time zone");
            entity.Property(e => e.DeclinedBy).HasMaxLength(250);
            entity.Property(e => e.Email).HasMaxLength(50);
            entity.Property(e => e.FirstName).HasMaxLength(100);
            entity.Property(e => e.Ip)
                .HasMaxLength(20)
                .HasColumnName("IP");
            entity.Property(e => e.LastName).HasMaxLength(100);
            entity.Property(e => e.LastReservationDate).HasColumnType("timestamp without time zone");
            entity.Property(e => e.LastWellnessDate).HasColumnType("timestamp without time zone");
            entity.Property(e => e.ModifiedDate).HasColumnType("timestamp without time zone");
            entity.Property(e => e.PatientAccountId).HasMaxLength(128);
            entity.Property(e => e.PhoneNumber).HasMaxLength(23);
            entity.Property(e => e.RelationName).HasMaxLength(100);
            entity.Property(e => e.UserId).ValueGeneratedOnAdd();

            entity.HasOne(d => d.CaseTag).WithMany(p => p.Requests)
                .HasForeignKey(d => d.CaseTagId)
                .HasConstraintName("Request_CaseTagId_fkey");

            entity.HasOne(d => d.Physician).WithMany(p => p.Requests)
                .HasForeignKey(d => d.PhysicianId)
                .HasConstraintName("Request_PhysicianId_fkey");

            entity.HasOne(d => d.User).WithMany(p => p.Requests)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("Request_UserId_fkey");
        });

        modelBuilder.Entity<RequestBusiness>(entity =>
        {
            entity.HasKey(e => e.RequestBusinessId).HasName("RequestBusiness_pkey");

            entity.ToTable("RequestBusiness");

            entity.Property(e => e.Ip)
                .HasMaxLength(20)
                .HasColumnName("IP");

            entity.HasOne(d => d.Business).WithMany(p => p.RequestBusinesses)
                .HasForeignKey(d => d.BusinessId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("RequestBusiness_BusinessId_fkey");

            entity.HasOne(d => d.Request).WithMany(p => p.RequestBusinesses)
                .HasForeignKey(d => d.RequestId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("RequestBusiness_RequestId_fkey");
        });

        modelBuilder.Entity<RequestClient>(entity =>
        {
            entity.HasKey(e => e.RequestClientId).HasName("RequestClient_pkey");

            entity.ToTable("RequestClient");

            entity.Property(e => e.Address).HasMaxLength(500);
            entity.Property(e => e.City).HasMaxLength(100);
            entity.Property(e => e.Email).HasMaxLength(50);
            entity.Property(e => e.FirstName).HasMaxLength(100);
            entity.Property(e => e.IntDate).HasColumnName("intDate");
            entity.Property(e => e.IntYear).HasColumnName("intYear");
            entity.Property(e => e.Ip)
                .HasMaxLength(20)
                .HasColumnName("IP");
            entity.Property(e => e.LastName).HasMaxLength(100);
            entity.Property(e => e.Latitude).HasPrecision(11, 8);
            entity.Property(e => e.Location).HasMaxLength(100);
            entity.Property(e => e.Longitude).HasPrecision(11, 8);
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
                .HasConstraintName("RequestClient_RegionId_fkey");

            entity.HasOne(d => d.Request).WithMany(p => p.RequestClients)
                .HasForeignKey(d => d.RequestId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("RequestClient_RequestId_fkey");
        });

        modelBuilder.Entity<RequestClosed>(entity =>
        {
            entity.HasKey(e => e.RequestClosedId).HasName("RequestClosed_pkey");

            entity.ToTable("RequestClosed");

            entity.Property(e => e.ClientNotes).HasMaxLength(500);
            entity.Property(e => e.Ip)
                .HasMaxLength(20)
                .HasColumnName("IP");
            entity.Property(e => e.PhyNotes).HasMaxLength(500);

            entity.HasOne(d => d.Request).WithMany(p => p.RequestCloseds)
                .HasForeignKey(d => d.RequestId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("RequestClosed_RequestId_fkey");

            entity.HasOne(d => d.RequestStatusLog).WithMany(p => p.RequestCloseds)
                .HasForeignKey(d => d.RequestStatusLogId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("RequestClosed_RequestStatusLogId_fkey");
        });

        modelBuilder.Entity<RequestConcierge>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("RequestConcierge_pkey");

            entity.ToTable("RequestConcierge");

            entity.Property(e => e.Ip)
                .HasMaxLength(20)
                .HasColumnName("IP");

            entity.HasOne(d => d.Concierge).WithMany(p => p.RequestConcierges)
                .HasForeignKey(d => d.ConciergeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("RequestConcierge_ConciergeId_fkey");

            entity.HasOne(d => d.Request).WithMany(p => p.RequestConcierges)
                .HasForeignKey(d => d.RequestId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("RequestConcierge_RequestId_fkey");
        });

        modelBuilder.Entity<RequestNote>(entity =>
        {
            entity.HasKey(e => e.RequestNotesId).HasName("RequestNotes_pkey");

            entity.Property(e => e.AdminNotes).HasMaxLength(500);
            entity.Property(e => e.AdministrativeNotes).HasMaxLength(500);
            entity.Property(e => e.CreatedBy).HasMaxLength(128);
            entity.Property(e => e.CreatedDate).HasColumnType("timestamp without time zone");
            entity.Property(e => e.IntDate).HasColumnName("intDate");
            entity.Property(e => e.IntYear).HasColumnName("intYear");
            entity.Property(e => e.Ip)
                .HasMaxLength(20)
                .HasColumnName("IP");
            entity.Property(e => e.ModifiedBy).HasMaxLength(128);
            entity.Property(e => e.ModifiedDate).HasColumnType("timestamp without time zone");
            entity.Property(e => e.PhysicianNotes).HasMaxLength(500);
            entity.Property(e => e.StrMonth)
                .HasMaxLength(20)
                .HasColumnName("strMonth");

            entity.HasOne(d => d.Request).WithMany(p => p.RequestNotes)
                .HasForeignKey(d => d.RequestId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("RequestNotes_RequestId_fkey");
        });

        modelBuilder.Entity<RequestStatusLog>(entity =>
        {
            entity.HasKey(e => e.RequestStatusLogId).HasName("RequestStatusLog_pkey");

            entity.ToTable("RequestStatusLog");

            entity.Property(e => e.CreatedDate).HasColumnType("timestamp without time zone");
            entity.Property(e => e.Ip)
                .HasMaxLength(20)
                .HasColumnName("IP");
            entity.Property(e => e.Notes).HasMaxLength(500);

            entity.HasOne(d => d.Admin).WithMany(p => p.RequestStatusLogs)
                .HasForeignKey(d => d.AdminId)
                .HasConstraintName("RequestStatusLog_AdminId_fkey");

            entity.HasOne(d => d.Physician).WithMany(p => p.RequestStatusLogPhysicians)
                .HasForeignKey(d => d.PhysicianId)
                .HasConstraintName("RequestStatusLog_PhysicianId_fkey");

            entity.HasOne(d => d.Request).WithMany(p => p.RequestStatusLogs)
                .HasForeignKey(d => d.RequestId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("RequestStatusLog_RequestId_fkey");

            entity.HasOne(d => d.TransToPhysician).WithMany(p => p.RequestStatusLogTransToPhysicians)
                .HasForeignKey(d => d.TransToPhysicianId)
                .HasConstraintName("RequestStatusLog_TransToPhysicianId_fkey");
        });

        modelBuilder.Entity<RequestType>(entity =>
        {
            entity.HasKey(e => e.RequestTypeId).HasName("RequestType_pkey");

            entity.ToTable("RequestType");

            entity.Property(e => e.Name).HasMaxLength(50);
        });

        modelBuilder.Entity<RequestWiseFile>(entity =>
        {
            entity.HasKey(e => e.RequestWiseFileId).HasName("RequestWiseFile_pkey");

            entity.ToTable("RequestWiseFile");

            entity.Property(e => e.RequestWiseFileId).HasColumnName("RequestWiseFileID");
            entity.Property(e => e.CreatedDate).HasColumnType("timestamp without time zone");
            entity.Property(e => e.FileName).HasMaxLength(500);
            entity.Property(e => e.Ip)
                .HasMaxLength(20)
                .HasColumnName("IP");

            entity.HasOne(d => d.Admin).WithMany(p => p.RequestWiseFiles)
                .HasForeignKey(d => d.AdminId)
                .HasConstraintName("RequestWiseFile_AdminId_fkey");

            entity.HasOne(d => d.Physician).WithMany(p => p.RequestWiseFiles)
                .HasForeignKey(d => d.PhysicianId)
                .HasConstraintName("RequestWiseFile_PhysicianId_fkey");

            entity.HasOne(d => d.Request).WithMany(p => p.RequestWiseFiles)
                .HasForeignKey(d => d.RequestId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("RequestWiseFile_RequestId_fkey");
        });

        modelBuilder.Entity<Role>(entity =>
        {
            entity.HasKey(e => e.RoleId).HasName("Role_pkey");

            entity.ToTable("Role");

            entity.Property(e => e.CreatedBy).HasMaxLength(128);
            entity.Property(e => e.CreatedDate).HasColumnType("timestamp without time zone");
            entity.Property(e => e.Ip)
                .HasMaxLength(20)
                .HasColumnName("IP");
            entity.Property(e => e.ModifiedBy).HasMaxLength(128);
            entity.Property(e => e.ModifiedDate).HasColumnType("timestamp without time zone");
            entity.Property(e => e.Name).HasMaxLength(50);
        });

        modelBuilder.Entity<RoleMenu>(entity =>
        {
            entity.HasKey(e => e.RoleMenuId).HasName("RoleMenu_pkey");

            entity.ToTable("RoleMenu");

            entity.HasOne(d => d.Menu).WithMany(p => p.RoleMenus)
                .HasForeignKey(d => d.MenuId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("RoleMenu_MenuId_fkey");

            entity.HasOne(d => d.Role).WithMany(p => p.RoleMenus)
                .HasForeignKey(d => d.RoleId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("RoleMenu_RoleId_fkey");
        });

        modelBuilder.Entity<Shift>(entity =>
        {
            entity.HasKey(e => e.ShiftId).HasName("Shift_pkey");

            entity.ToTable("Shift");

            entity.Property(e => e.CreatedBy).HasMaxLength(128);
            entity.Property(e => e.CreatedDate).HasColumnType("timestamp without time zone");
            entity.Property(e => e.Ip)
                .HasMaxLength(20)
                .HasColumnName("IP");
            entity.Property(e => e.WeekDays)
                .HasMaxLength(7)
                .IsFixedLength();

            entity.HasOne(d => d.CreatedByNavigation).WithMany(p => p.Shifts)
                .HasForeignKey(d => d.CreatedBy)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("Shift_CreatedBy_fkey");

            entity.HasOne(d => d.Physician).WithMany(p => p.Shifts)
                .HasForeignKey(d => d.PhysicianId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("Shift_PhysicianId_fkey");
        });

        modelBuilder.Entity<ShiftDetail>(entity =>
        {
            entity.HasKey(e => e.ShiftDetailId).HasName("ShiftDetail_pkey");

            entity.ToTable("ShiftDetail");

            entity.Property(e => e.EventId).HasMaxLength(100);
            entity.Property(e => e.LastRunningDate).HasColumnType("timestamp without time zone");
            entity.Property(e => e.ModifiedBy).HasMaxLength(128);
            entity.Property(e => e.ModifiedDate).HasColumnType("timestamp without time zone");
            entity.Property(e => e.ShiftDate).HasColumnType("timestamp without time zone");

            entity.HasOne(d => d.ModifiedByNavigation).WithMany(p => p.ShiftDetails)
                .HasForeignKey(d => d.ModifiedBy)
                .HasConstraintName("ShiftDetail_ModifiedBy_fkey");

            entity.HasOne(d => d.Shift).WithMany(p => p.ShiftDetails)
                .HasForeignKey(d => d.ShiftId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("ShiftDetail_ShiftId_fkey");
        });

        modelBuilder.Entity<ShiftDetailRegion>(entity =>
        {
            entity.HasKey(e => e.ShiftDetailRegionId).HasName("ShiftDetailRegion_pkey");

            entity.ToTable("ShiftDetailRegion");

            entity.HasOne(d => d.Region).WithMany(p => p.ShiftDetailRegions)
                .HasForeignKey(d => d.RegionId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("ShiftDetailRegion_RegionId_fkey");

            entity.HasOne(d => d.ShiftDetail).WithMany(p => p.ShiftDetailRegions)
                .HasForeignKey(d => d.ShiftDetailId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("ShiftDetailRegion_ShiftDetailId_fkey");
        });

        modelBuilder.Entity<Smslog>(entity =>
        {
            entity.HasKey(e => e.SmslogId).HasName("SMSLog_pkey");

            entity.ToTable("SMSLog");

            entity.Property(e => e.SmslogId)
                .HasPrecision(9)
                .HasColumnName("SMSLogID");
            entity.Property(e => e.ConfirmationNumber).HasMaxLength(200);
            entity.Property(e => e.CreateDate).HasColumnType("timestamp without time zone");
            entity.Property(e => e.IsSmssent).HasColumnName("IsSMSSent");
            entity.Property(e => e.MobileNumber).HasMaxLength(50);
            entity.Property(e => e.SentDate).HasColumnType("timestamp without time zone");
            entity.Property(e => e.Smstemplate)
                .HasColumnType("character varying")
                .HasColumnName("SMSTemplate");
        });

        modelBuilder.Entity<Timesheet>(entity =>
        {
            entity.HasKey(e => e.TimesheetId).HasName("Timesheet_pkey");

            entity.ToTable("Timesheet");

            entity.Property(e => e.IsFinalized)
                .HasColumnType("bit(1)")
                .HasColumnName("isFinalized");

            entity.HasOne(d => d.Physician).WithMany(p => p.Timesheets)
                .HasForeignKey(d => d.PhysicianId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("Timesheet_PhysicianId_fkey");
        });

        modelBuilder.Entity<TimesheetDetail>(entity =>
        {
            entity.HasKey(e => e.TimesheetDetailId).HasName("TimesheetDetails_pkey");

            entity.Property(e => e.Housecall).HasDefaultValueSql("0");
            entity.Property(e => e.IsWeekend)
                .HasColumnType("bit(1)")
                .HasColumnName("isWeekend");
            entity.Property(e => e.PhoneConsult).HasDefaultValueSql("0");
            entity.Property(e => e.ShiftHours).HasDefaultValueSql("0");

            entity.HasOne(d => d.Timesheet).WithMany(p => p.TimesheetDetails)
                .HasForeignKey(d => d.TimesheetId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("TimesheetDetails_TimesheetId_fkey");
        });

        modelBuilder.Entity<TimesheetReimbursement>(entity =>
        {
            entity.HasKey(e => e.TimesheetReimbursementId).HasName("TimesheetReimbursement_pkey");

            entity.ToTable("TimesheetReimbursement");

            entity.HasOne(d => d.Timesheet).WithMany(p => p.TimesheetReimbursements)
                .HasForeignKey(d => d.TimesheetId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("TimesheetReimbursement_TimesheetId_fkey");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.UserId).HasName("User_pkey");

            entity.ToTable("User");

            entity.Property(e => e.AspNetUserId).HasMaxLength(128);
            entity.Property(e => e.City).HasMaxLength(100);
            entity.Property(e => e.CreatedBy).HasMaxLength(128);
            entity.Property(e => e.CreatedDate).HasColumnType("timestamp without time zone");
            entity.Property(e => e.Email).HasMaxLength(50);
            entity.Property(e => e.FirstName).HasMaxLength(100);
            entity.Property(e => e.IntDate).HasColumnName("intDate");
            entity.Property(e => e.IntYear).HasColumnName("intYear");
            entity.Property(e => e.Ip)
                .HasMaxLength(20)
                .HasColumnName("IP");
            entity.Property(e => e.LastName).HasMaxLength(100);
            entity.Property(e => e.Mobile).HasMaxLength(20);
            entity.Property(e => e.ModifiedBy).HasMaxLength(128);
            entity.Property(e => e.ModifiedDate).HasColumnType("timestamp without time zone");
            entity.Property(e => e.State).HasMaxLength(100);
            entity.Property(e => e.StrMonth)
                .HasMaxLength(20)
                .HasColumnName("strMonth");
            entity.Property(e => e.Street).HasMaxLength(100);
            entity.Property(e => e.ZipCode).HasMaxLength(10);

            entity.HasOne(d => d.AspNetUser).WithMany(p => p.Users)
                .HasForeignKey(d => d.AspNetUserId)
                .HasConstraintName("User_AspNetUserId_fkey");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
