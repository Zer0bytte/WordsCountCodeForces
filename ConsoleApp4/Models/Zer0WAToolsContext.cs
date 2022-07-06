using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace ConsoleApp4.Models
{
    public partial class Zer0WAToolsContext : DbContext
    {
        public Zer0WAToolsContext()
        {
        }

        public Zer0WAToolsContext(DbContextOptions<Zer0WAToolsContext> options)
            : base(options)
        {
        }

        public virtual DbSet<TbAdmin> TbAdmins { get; set; }
        public virtual DbSet<Tblicense> Tblicenses { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=DESKTOP-62P7HA1\\SQLEXPRESS;Database=Zer0WATools;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<TbAdmin>(entity =>
            {
                entity.HasKey(e => e.AdminId);

                entity.Property(e => e.Password).IsRequired();

                entity.Property(e => e.Username).IsRequired();
            });

            modelBuilder.Entity<Tblicense>(entity =>
            {
                entity.HasKey(e => e.LicenseId);

                entity.ToTable("TBLicenses");

                entity.Property(e => e.Hwid).HasColumnName("HWID");

                entity.Property(e => e.LicenseKey).IsRequired();

                entity.Property(e => e.UsedDate).HasColumnType("datetime");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
