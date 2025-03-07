using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Models;

namespace Data;

public partial class Cpk25Context : DbContext
{
    public Cpk25Context()
    {
    }

    public Cpk25Context(DbContextOptions<Cpk25Context> options)
        : base(options)
    {
    }

    public virtual DbSet<Line1003> Line1003s { get; set; }

    public virtual DbSet<Line1010> Line1010s { get; set; }

    public virtual DbSet<Line1011> Line1011s { get; set; }

    public virtual DbSet<Line10113> Line10113s { get; set; }

    public virtual DbSet<Line1013> Line1013s { get; set; }

    public virtual DbSet<Line1014> Line1014s { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Line1003>().ToTable(t => t.HasTrigger("tr_dbo_Line1003_b0792f02-af10-4efb-8d4d-cf1b736d8bff_Sender"));
        modelBuilder.Entity<Line1010>().ToTable(t => t.HasTrigger("tr_dbo_Line1010_b0792f02-af10-4efb-8d4d-cf1b736d8bff_Sender"));
        modelBuilder.Entity<Line1011>().ToTable(t => t.HasTrigger("tr_dbo_Line1011_b0792f02-af10-4efb-8d4d-cf1b736d8bff_Sender"));
        modelBuilder.Entity<Line10113>().ToTable(t => t.HasTrigger("tr_dbo_Line10113_b0792f02-af10-4efb-8d4d-cf1b736d8bff_Sender"));
        modelBuilder.Entity<Line1013>().ToTable(t => t.HasTrigger("tr_dbo_Line1013_b0792f02-af10-4efb-8d4d-cf1b736d8bff_Sender"));
        modelBuilder.Entity<Line1014>().ToTable(t => t.HasTrigger("tr_dbo_Line1014_b0792f02-af10-4efb-8d4d-cf1b736d8bff_Sender"));

        modelBuilder.UseCollation("SQL_Latin1_General_CP1_CI_AS");

        modelBuilder.Entity<Line1003>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__line1003__3213E83F05B3C89B");

            entity.ToTable("line1003");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CpkLin3We3Numericid).HasColumnName("cpk_lin3_we3_NUMERICID");
            entity.Property(e => e.CpkLin3We3Quality).HasColumnName("cpk_lin3_we3_QUALITY");
            entity.Property(e => e.CpkLin3We3Timestamp)
                .HasColumnType("datetime")
                .HasColumnName("cpk_lin3_we3_TIMESTAMP");
            entity.Property(e => e.CpkLin3We3Value).HasColumnName("cpk_lin3_we3_VALUE");
        });

        modelBuilder.Entity<Line1010>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__line1010__3213E83F932DD795");

            entity.ToTable("line1010");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CpkLin10We10Numericid).HasColumnName("cpk_lin10_we10_NUMERICID");
            entity.Property(e => e.CpkLin10We10Quality).HasColumnName("cpk_lin10_we10_QUALITY");
            entity.Property(e => e.CpkLin10We10Timestamp)
                .HasColumnType("datetime")
                .HasColumnName("cpk_lin10_we10_TIMESTAMP");
            entity.Property(e => e.CpkLin10We10Value).HasColumnName("cpk_lin10_we10_VALUE");
        });

        modelBuilder.Entity<Line1011>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__line1011__3213E83FB3C1EA90");

            entity.ToTable("line1011");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CpkLin11We11Numericid).HasColumnName("cpk_lin11_we11_NUMERICID");
            entity.Property(e => e.CpkLin11We11Quality).HasColumnName("cpk_lin11_we11_QUALITY");
            entity.Property(e => e.CpkLin11We11Timestamp)
                .HasColumnType("datetime")
                .HasColumnName("cpk_lin11_we11_TIMESTAMP");
            entity.Property(e => e.CpkLin11We11Value).HasColumnName("cpk_lin11_we11_VALUE");
        });

        modelBuilder.Entity<Line10113>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__line1011__3213E83F919E2201");

            entity.ToTable("line10113");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CpkLin3We3Numericid).HasColumnName("cpk_lin3_we3_NUMERICID");
            entity.Property(e => e.CpkLin3We3Quality).HasColumnName("cpk_lin3_we3_QUALITY");
            entity.Property(e => e.CpkLin3We3Timestamp)
                .HasColumnType("datetime")
                .HasColumnName("cpk_lin3_we3_TIMESTAMP");
            entity.Property(e => e.CpkLin3We3Value).HasColumnName("cpk_lin3_we3_VALUE");
        });

        modelBuilder.Entity<Line1013>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__line1013__3213E83F166093E0");

            entity.ToTable("line1013");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CpkLine13Wei13Numericid).HasColumnName("cpk_line_13_wei13_NUMERICID");
            entity.Property(e => e.CpkLine13Wei13Quality).HasColumnName("cpk_line_13_wei13_QUALITY");
            entity.Property(e => e.CpkLine13Wei13Timestamp)
                .HasColumnType("datetime")
                .HasColumnName("cpk_line_13_wei13_TIMESTAMP");
            entity.Property(e => e.CpkLine13Wei13Value).HasColumnName("cpk_line_13_wei13_VALUE");
        });

        modelBuilder.Entity<Line1014>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__line1014__3213E83F6EE6D6E7");

            entity.ToTable("line1014");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CpkLine14We14Timestamp)
                .HasColumnType("datetime")
                .HasColumnName("cpk_lin14_we14_TIMESTAMP");
            entity.Property(e => e.CpkLine14We14Value).HasColumnName("cpk_lin14_we14_VALUE");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
