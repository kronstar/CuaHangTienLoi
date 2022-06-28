using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;
using CuaHangTienLoi.Web.Models.AnhSanPhamModel;
using CuaHangTienLoi.Web.Models.ChiTietHoaDonModel;
using CuaHangTienLoi.Web.Models.ChucVuModel;
using CuaHangTienLoi.Web.Models.DanhMucModel;
using CuaHangTienLoi.Web.Models.HoaDonModel;
using CuaHangTienLoi.Web.Models.NhaCungCapModel;
using CuaHangTienLoi.Web.Models.NhanVienModel;
using CuaHangTienLoi.Web.Models.SanPhamModel;
using CuaHangTienLoi.Web.Models.SliderModel;
using CuaHangTienLoi.Web.Models.TaiKhoanModel;
using CuaHangTienLoi.Web.Models.TinTucModel;

namespace CuaHangTienLoi.Web.Models
{
    public partial class DBModels : DbContext
    {
        public DBModels()
            : base("name=DBModels")
        {
        }

        private static volatile DBModels instance;
        private static object synRoot = new Object();

        public static DBModels Instance
        {
            get
            {
                if (instance == null)
                {
                    lock (synRoot)
                    {
                        if (instance == null)
                            instance = new DBModels();
                    }
                }
                return instance;
            }
        }

        public static int saveChange()
        { 
            return DBModels.instance.SaveChanges();
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }

        public DbSet<AnhSanPham> AnhSanPhams { get; set; }
        public DbSet<ChiTietHoaDon> ChiTietHoaDons { get; set; }
        public DbSet<DanhMuc> DanhMucs { get; set; }
        public DbSet<HoaDon> HoaDons { get; set; }
        public DbSet<NhaCungCap> NhaCungCaps { get; set; }
        public DbSet<SanPham> SanPhams { get; set; }
        public DbSet<Slider> Sliders { get; set; }
        public DbSet<TaiKhoan> TaiKhoans { get; set; }
        public DbSet<TinTuc> TinTucs { get; set; }
        public DbSet<ChucVu> ChucVus { get; set; }
        public DbSet<NhanVien> NhanViens { get; set; }

        /*protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<SanPham>()
                .Property(e => e.LinkAnh)
                .IsFixedLength();

            modelBuilder.Entity<TaiKhoan>()
                .Property(e => e.SoDienThoai)
                .IsFixedLength();
        }*/
    }
}