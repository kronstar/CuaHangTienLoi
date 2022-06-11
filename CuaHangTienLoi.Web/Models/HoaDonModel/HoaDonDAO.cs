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
            tmp.TongHoaDon = hoadon.TongHoaDon;
            tmp.TrangThai = hoadon.TrangThai;
            int result = DBModels.Instance.SaveChanges();
            return result == 1 ? true : false;
        }
    }
}