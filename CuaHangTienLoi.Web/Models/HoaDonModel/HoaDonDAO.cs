using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CuaHangTienLoi.Web.Models.HoaDonModel
{
    public class HoaDonDAO
    {
        public static List<HoaDon> getAllHoaDon()
        {
            List<HoaDon> hoadon = (from hd in DBModels.Instance.HoaDons select hd).ToList();
            if (hoadon.Any())
                return hoadon;
            return null;
        }
        public static List<HoaDon> getAllHoaDonByUserId(int id)
        {
            List<HoaDon> hoadon = (from hd in DBModels.Instance.HoaDons where hd.MaTaiKhoan == id select hd).ToList();
            if (hoadon.Any())
                return hoadon;
            return null;
        }
        public static int getTongHoaDon()
        {
            List<HoaDon> hoadon = (from hd in DBModels.Instance.HoaDons select hd).ToList();
            int tong = hoadon.Select(x => x.MaHoaDon).Count();
            if (tong == 0)
            {
                return 0;
            }
            return tong;
        }
        public static int getDatHangThanhCong()
        {
            List<HoaDon> hoadon = (from hd in DBModels.Instance.HoaDons where hd.TinhTrangDonHang == 1 select hd).ToList();
            int tong = hoadon.Select(x => x.MaHoaDon).Count();
            if (tong == 0)
            {
                return 0;
            }
            return tong;
        }
        public static int getDangGiaoHang()
        {
            List<HoaDon> hoadon = (from hd in DBModels.Instance.HoaDons where hd.TinhTrangDonHang == 2 select hd).ToList();
            int tong = hoadon.Select(x => x.MaHoaDon).Count();
            if (tong == 0)
            {
                return 0;
            }
            return tong;
        }
        public static int getHoanThanh()
        {
            List<HoaDon> hoadon = (from hd in DBModels.Instance.HoaDons where hd.TinhTrangDonHang == 3 select hd).ToList();
            int tong = hoadon.Select(x => x.MaHoaDon).Count();
            if (tong == 0)
            {
                return 0;
            }
            return tong;
        }
        public static int getDaHuy()
        {
            List<HoaDon> hoadon = (from hd in DBModels.Instance.HoaDons where hd.TinhTrangDonHang == 4 select hd).ToList();
            int tong = hoadon.Select(x => x.MaHoaDon).Count();
            if (tong == 0)
            {
                return 0;
            }
            return tong;
        }

        public static int getTongDoanhThuHienTai()
        {
            List<HoaDon> hoadon = (from hd in DBModels.Instance.HoaDons where hd.TinhTrangDonHang == 3 && hd.TrangThai==1 select hd).ToList();
            int tong = hoadon.Select(x => x.TongHoaDon).Sum();
            if (tong == 0)
            {
                return 0;
            }
            return tong;
        }

        public static int getTongDoanhThuDuKien()
        {
            List<HoaDon> hoadon = (from hd in DBModels.Instance.HoaDons where hd.TinhTrangDonHang <4 select hd).ToList();
            int tong = hoadon.Select(x => x.TongHoaDon).Sum();
            if (tong == 0)
            {
                return 0;
            }
            return tong;
        }

        public static int getTongDoanhThuThangNay()
        {
            DateTime frommonth = DateTime.Now.AddMonths(-1);
            DateTime tomonth = DateTime.Now;
            List<HoaDon> hoadon = (from hd in DBModels.Instance.HoaDons where hd.NgayDat.Value >= frommonth && hd.NgayDat.Value < tomonth && hd.TrangThai == 1 && hd.TinhTrangDonHang == 3 select hd).ToList();
            int tong = hoadon.Select(x => x.TongHoaDon).Sum();
            if (tong == 0)
            {
                return 0;
            }
            return tong;
        }

        public static int getTongDoanhThuThangNayDuKien()
        {
            DateTime frommonth = DateTime.Now.AddMonths(-1);
            DateTime tomonth = DateTime.Now;
            List<HoaDon> hoadon = (from hd in DBModels.Instance.HoaDons where hd.NgayDat.Value >= frommonth && hd.NgayDat.Value < tomonth && hd.TinhTrangDonHang <4 && hd.TrangThai <3 select hd).ToList();
            int tong = hoadon.Select(x => x.TongHoaDon).Sum();
            if (tong == 0)
            {
                return 0;
            }
            return tong;
        }

        public static int getTongDoanhThuChoVeThangNay()
        {
            DateTime frommonth = DateTime.Now.AddMonths(-1);
            DateTime tomonth = DateTime.Now;
            List<HoaDon> hoadon = (from hd in DBModels.Instance.HoaDons where hd.NgayDat.Value >= frommonth && hd.NgayDat.Value < tomonth && hd.TinhTrangDonHang <3 select hd).ToList();
            int tong = hoadon.Select(x => x.TongHoaDon).Sum();
            if (tong == 0)
            {
                return 0;
            }
            return tong;
        }

        public static bool addHoaDon(HoaDon hoadon)
        {
            DBModels.Instance.HoaDons.Add(hoadon);
            int result = DBModels.Instance.SaveChanges();
            return result == 1 ? true : false;
        }

        public static HoaDon getByIdHoaDon(int id)
        {
            HoaDon hoadon = (from hd in DBModels.Instance.HoaDons where hd.MaHoaDon == id select hd).FirstOrDefault();
            return hoadon;
        }
        public static bool saveHoaDon(HoaDon hoadon)
        {
            HoaDon tmp = HoaDonDAO.getByIdHoaDon(hoadon.MaHoaDon);
            tmp.TrangThai = hoadon.TrangThai;
            tmp.GhiChu = hoadon.GhiChu;
            tmp.TinhTrangDonHang = hoadon.TinhTrangDonHang;
            tmp.MaNhanVien = hoadon.MaNhanVien;
            int result = DBModels.Instance.SaveChanges();
            return result == 1 ? true : false;
        }
    }
}