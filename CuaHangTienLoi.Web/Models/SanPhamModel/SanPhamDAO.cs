using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CuaHangTienLoi.Web.Models.SanPhamModel
{
    public class SanPhamDAO
    {

        public static List<SanPham> getAllSanPham()
        {
            List<SanPham> sanphams = (from sp in DBModels.Instance.SanPhams select sp).ToList();
            if (sanphams.Any())
                return sanphams;
            return null;
        }
        public static List<SanPham> getAllSanPhamById(int id)
        {
            List<SanPham> sanphams = (from sp in DBModels.Instance.SanPhams where sp.MaSanPham == id select sp).ToList();
            return sanphams;
        }
        public static List<SanPham> getAllSanPhamNoiBat()
        {
            List<SanPham> sanphams = (from sp in DBModels.Instance.SanPhams select sp).OrderByDescending(m => m.LuotMua).ToList();
            if (sanphams.Any())
                return sanphams;
            return null;
        }

        public static List<SanPham> getAllSanPhamByIdDanhMuc(int id)
        {
            List<SanPham> sanphams = (from sp in DBModels.Instance.SanPhams where sp.MaDanhMuc == id select sp).ToList();
            return sanphams;
        }

        public static SanPham getSanPhamByID(int id)
        {
            SanPham sanphams = (from sp in DBModels.Instance.SanPhams where sp.MaSanPham == id select sp).FirstOrDefault();
            return sanphams;
        }

        public static List<SanPham> searchByName(string name)
        {
            bool existUnicodeCharacter = name.Any(c => c > 255);
            List<SanPham> result;
            if (!existUnicodeCharacter)
                result = (from sp in DBModels.Instance.Set<SanPham>().AsEnumerable() where Core.convertToUnsign(sp.TenSanPham).ToLower().Contains(name.ToLower()) select sp).ToList();
            else
                result = (from sp in DBModels.Instance.Set<SanPham>().AsEnumerable()
                          where sp.TenSanPham.ToLower().Contains(name.ToLower())
                          select sp).ToList();
            return result;
            //List<SanPham> items = (from item in DBContextEvaShop.Instance.Set<SanPham>().AsEnumerable()
            //                       where Func.convertToUnsign(item.TenSanPham).ToLower().Contains(Func.convertToUnsign(name.ToLower()))
            //                       select item).ToList();
            //return items;
        }

        public static bool remove(SanPham sanpham)
        {
            DBModels.Instance.SanPhams.Remove(sanpham);
            int result = DBModels.Instance.SaveChanges();
            return result == 1 ? true : false;
        }

        public static bool removeSanpham(int id)
        {
            SanPham rm = SanPhamDAO.getSanPhamByID(id);
            if (remove(rm))
                return true;
            return false;
        }

        public static bool addSanPham(SanPham sanpham)
        {
            DBModels.Instance.SanPhams.Add(sanpham);
            int result = DBModels.Instance.SaveChanges();
            return result == 1 ? true : false;
        }

        public static bool saveSanPham(SanPham sanpham)
        {
            SanPham tmp = SanPhamDAO.getSanPhamByID(sanpham.MaSanPham);
            //tmp.IdChuDe = sanpham.IdChuDe;
            //tmp.IdNhaSanXuat = sanpham.IdNhaSanXuat;
            tmp.TenSanPham = sanpham.TenSanPham;
            tmp.TinhTrang = sanpham.TinhTrang;
            tmp.LinkAnh = sanpham.LinkAnh;
            tmp.MoTa = sanpham.MoTa;
            tmp.DonGia = sanpham.DonGia;
            tmp.GiamGia = sanpham.GiamGia;
            tmp.PhanTramGiamGia = sanpham.PhanTramGiamGia;
            tmp.LuotMua = sanpham.LuotMua;
            tmp.NgayDang = sanpham.NgayDang;
            tmp.DaXoa = sanpham.DaXoa;
            tmp.SoLuong = sanpham.SoLuong;
            int result = DBModels.Instance.SaveChanges();
            return result == 1 ? true : false;
        }
    }
}