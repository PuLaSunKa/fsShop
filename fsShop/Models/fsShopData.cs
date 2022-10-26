using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace fsShop.Models
{
    public partial class fsShopData : DbContext
    {
        public fsShopData()
            : base("name=fsShopData")
        {
        }

        public virtual DbSet<BaiDang> BaiDangs { get; set; }
        public virtual DbSet<ChiTietDonHang> ChiTietDonHangs { get; set; }
        public virtual DbSet<DangHinhAnh> DangHinhAnhs { get; set; }
        public virtual DbSet<DanhMuc> DanhMucs { get; set; }
        public virtual DbSet<DonHang> DonHangs { get; set; }
        public virtual DbSet<GiaTriThuocTinh> GiaTriThuocTinhs { get; set; }
        public virtual DbSet<NguoiDung> NguoiDungs { get; set; }
        public virtual DbSet<NhanHang> NhanHangs { get; set; }
        public virtual DbSet<Quyen> Quyens { get; set; }
        public virtual DbSet<SanPham> SanPhams { get; set; }
        public virtual DbSet<sysdiagram> sysdiagrams { get; set; }
        public virtual DbSet<TheLoai> TheLoais { get; set; }
        public virtual DbSet<ThuocTinh> ThuocTinhs { get; set; }
        public virtual DbSet<ThuocTinhSanPham> ThuocTinhSanPhams { get; set; }
        public virtual DbSet<VaiTro> VaiTroes { get; set; }
        public virtual DbSet<VaiTroChoPhep> VaiTroChoPheps { get; set; }
        public virtual DbSet<HinhAnhSanPham> HinhAnhSanPhams { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<BaiDang>()
                .Property(e => e.TieuDeWeb)
                .IsFixedLength();

            modelBuilder.Entity<DonHang>()
                .HasMany(e => e.ChiTietDonHangs)
                .WithRequired(e => e.DonHang)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<GiaTriThuocTinh>()
                .HasMany(e => e.ThuocTinhSanPhams)
                .WithRequired(e => e.GiaTriThuocTinh)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<NguoiDung>()
                .Property(e => e.TenDangNhap)
                .IsFixedLength();

            modelBuilder.Entity<NguoiDung>()
                .Property(e => e.MatKhau)
                .IsFixedLength();

            modelBuilder.Entity<NguoiDung>()
                .Property(e => e.SoDienThoai)
                .HasPrecision(18, 0);

            modelBuilder.Entity<NguoiDung>()
                .HasMany(e => e.BaiDangs)
                .WithRequired(e => e.NguoiDung)
                .HasForeignKey(e => e.NguoiTao);

            modelBuilder.Entity<NguoiDung>()
                .HasMany(e => e.DonHangs)
                .WithRequired(e => e.NguoiDung)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Quyen>()
                .HasMany(e => e.VaiTroChoPheps)
                .WithRequired(e => e.Quyen)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<SanPham>()
                .HasMany(e => e.ChiTietDonHangs)
                .WithRequired(e => e.SanPham)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<SanPham>()
                .HasMany(e => e.HinhAnhSanPhams)
                .WithRequired(e => e.SanPham)
                .HasForeignKey(e => e.MaSanPhan);

            modelBuilder.Entity<SanPham>()
                .HasMany(e => e.ThuocTinhSanPhams)
                .WithRequired(e => e.SanPham)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<TheLoai>()
                .HasMany(e => e.SanPhams)
                .WithOptional(e => e.TheLoai)
                .HasForeignKey(e => e.MaTheLoai);

            modelBuilder.Entity<ThuocTinh>()
                .HasMany(e => e.GiaTriThuocTinhs)
                .WithRequired(e => e.ThuocTinh)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<VaiTro>()
                .HasMany(e => e.NguoiDungs)
                .WithRequired(e => e.VaiTro1)
                .HasForeignKey(e => e.VaiTro)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<VaiTro>()
                .HasMany(e => e.VaiTroChoPheps)
                .WithRequired(e => e.VaiTro)
                .WillCascadeOnDelete(false);
        }
    }
}
