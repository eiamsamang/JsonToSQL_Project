using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace JsonToSQL_Project.DAL
{
    public partial class dbYTContext : DbContext
    {
        public dbYTContext()
        {
        }

        public dbYTContext(DbContextOptions<dbYTContext> options)
            : base(options)
        {
        }

        public virtual DbSet<TbJson> TbJsons { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("SERVER=localhost;User ID = yt;Password=ytlogin_2021;Database=dbYT");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<TbJson>(entity =>
            {
                entity.ToTable("tbJSON");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Fname)
                    .HasMaxLength(100)
                    .HasColumnName("FName");

                entity.Property(e => e.Lname)
                    .HasMaxLength(100)
                    .HasColumnName("LName");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
