using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace ConsoleApp4.Models
{
    public partial class KashafaContext : DbContext
    {
        public KashafaContext()
        {
        }

        public KashafaContext(DbContextOptions<KashafaContext> options)
            : base(options)
        {
        }

        public virtual DbSet<TbAttendence> TbAttendences { get; set; }
        public virtual DbSet<TbMember> TbMembers { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=DESKTOP-62P7HA1\\SQLEXPRESS;Database=Kashafa;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<TbAttendence>(entity =>
            {
                entity.HasKey(e => e.AttId)
                    .HasName("PK_Table_1");

                entity.ToTable("TbAttendence");

                entity.HasOne(d => d.Member)
                    .WithMany(p => p.TbAttendences)
                    .HasForeignKey(d => d.MemberId)
                    .HasConstraintName("FK_TbAttendence_TbMembers");
            });

            modelBuilder.Entity<TbMember>(entity =>
            {
                entity.HasKey(e => e.MemberId);

                entity.Property(e => e.BornDate).HasColumnType("datetime");

                entity.Property(e => e.MemberName).IsRequired();
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
