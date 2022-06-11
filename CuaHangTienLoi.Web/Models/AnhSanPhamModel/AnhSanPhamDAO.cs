using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CuaHangTienLoi.Web.Models.AnhSanPhamModel
{
    public class AnhSanPhamDAO
    {
        public static List<AnhSanPham> getAllAnhChiTietSanPhams()
        {
            List<AnhSanPham> anhsanpham = (from hsp in DBModels.Instance.AnhSanPhams select hsp).ToList();
            if (anhsanpham.Any())
                return anhsanpham;
            return null;
        }

        public static AnhSanPham getByIdAnhSanPham(int id)
        {
            AnhSanPham anhsanpham = (from hsp in DBModels.Instance.AnhSanPhams where hsp.MaAnhSanPham == id select hsp).FirstOrDefault();
            return anhsanpham;
        }

        public static bool saveAnhSanPham(AnhSanPham anhsanpham)
        {
            AnhSanPham tmp = AnhSanPhamDAO.getByIdAnhSanPham(anhsanpham.MaAnhSanPham);
            tmp.MaAnhSanPham = anhsanpham.MaAnhSanPham;
            tmp.LinkAnh = anhsanpham.LinkAnh;
            int result = DBModels.Instance.SaveChanges();
            return result == 1 ? true : false;
        }

        public static bool remove(AnhSanPham anhsanpham)
        {
            DBModels.Instance.AnhSanPhams.Remove(anhsanpham);
            int result = DBModels.Instance.SaveChanges();
            return result == 1 ? true : false;
        }

        public static bool removeAnhSanPham(int id)
        {
            AnhSanPham rm = AnhSanPhamDAO.getByIdAnhSanPham(id);
            if (remove(rm))
                return true;
            return false;
        }

        public static bool addAnhSanPham(AnhSanPham anhsanpham)
        {
            DBModels.Instance.AnhSanPhams.Add(anhsanpham);
            int result = DBModels.Instance.SaveChanges();
            return result == 1 ? true : false;
        }
    }
}