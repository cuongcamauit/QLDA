using HumanResource.Models;
using Microsoft.EntityFrameworkCore;
using System.Net;

namespace HumanResource.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options) { }
        public DbSet<NhanVien> NhanViens { get; set; }
        public DbSet<PhongBan> PhongBans { get; set; }   
        public DbSet<MucLuong> MucLuongs { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<NhanVien>(entity =>
            {
                entity.HasKey(o => o.MaNV);

                entity.HasOne(o => o.PhongBan)
                        .WithMany(o => o.NhanViens)
                        .HasForeignKey(o => o.MaPhongBan);

                entity.HasOne(o => o.MucLuong)
                        .WithMany(o => o.NhanViens)
                        .HasForeignKey(o => o.TenMucLuong);
                
            });

            modelBuilder.Entity<PhongBan>(entity =>
            {
                entity.HasKey(o => o.MaPhongBan);

                entity.HasMany(o => o.NhanViens)
                        .WithOne(o => o.PhongBan)
                        .HasForeignKey(o => o.MaPhongBan);
            });

            modelBuilder.Entity<MucLuong>(entity =>
            {
                entity.HasKey(o => o.TenMucLuong);

                entity.HasMany(o => o.NhanViens)
                        .WithOne(o => o.MucLuong)
                        .HasForeignKey(o => o.TenMucLuong);
            });
        }
    }
}
