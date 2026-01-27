using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace My_Web_APP.DBContext;

public partial class TxsdemoAzuredevContext : DbContext
{
    public TxsdemoAzuredevContext()
    {
    }

    public TxsdemoAzuredevContext(DbContextOptions<TxsdemoAzuredevContext> options)
        : base(options)
    {
    }

    public virtual DbSet<User> Users { get; set; }

//    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
//        => optionsBuilder.UseSqlServer("Server=190.92.172.185;Database=txsdemo_azuredev;user id=txsdemo_azuredevusr;password=3#FgO4Ee!buVe2$mj;Trusted_Connection=false;TrustServerCertificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.HasDefaultSchema("txsdemo_azuredevusr");

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__users__3214EC073E1BF866");

            entity.ToTable("users");

            entity.HasIndex(e => e.Email, "UQ__users__AB6E61649AEE4589").IsUnique();

            entity.Property(e => e.Email)
                .HasMaxLength(150)
                .IsUnicode(false)
                .HasColumnName("email");
            entity.Property(e => e.Name)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("name");
            entity.Property(e => e.Password)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("password");
            entity.Property(e => e.Phone)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("phone");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
