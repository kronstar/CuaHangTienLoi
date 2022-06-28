using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CuaHangTienLoi.Web.Models.ChucVuModel
{
    public class ChucVuDAO
    {

        public static List<ChucVu> getAllChucVu()
        {
            List<ChucVu> chucvus = (from sp in DBModels.Instance.ChucVus select sp).ToList();
            if (chucvus.Any())
                return chucvus;
            return null;
        }
        public static List<ChucVu> getAllChucVuById(int id)
        {
            List<ChucVu> chucvus = (from sp in DBModels.Instance.ChucVus where sp.MaChucVu == id select sp).ToList();
            return chucvus;
        }

        public static ChucVu getChucVuByID(int id)
        {
            ChucVu chucvus = (from sp in DBModels.Instance.ChucVus where sp.MaChucVu == id select sp).FirstOrDefault();
            return chucvus;
        }

        public static List<ChucVu> searchByName(string name)
        {
            bool existUnicodeCharacter = name.Any(c => c > 255);
            List<ChucVu> result;
            if (!existUnicodeCharacter)
                result = (from sp in DBModels.Instance.Set<ChucVu>().AsEnumerable() where Core.convertToUnsign(sp.TenChucVu).ToLower().Contains(name.ToLower()) select sp).ToList();
            else
                result = (from sp in DBModels.Instance.Set<ChucVu>().AsEnumerable()
                          where sp.TenChucVu.ToLower().Contains(name.ToLower())
                          select sp).ToList();
            return result;
        }

        public static bool remove(ChucVu chucvu)
        {
            DBModels.Instance.ChucVus.Remove(chucvu);
            int result = DBModels.Instance.SaveChanges();
            return result == 1 ? true : false;
        }

        public static bool removeChucVu(int id)
        {
            ChucVu rm = ChucVuDAO.getChucVuByID(id);
            if (remove(rm))
                return true;
            return false;
        }

        public static bool addChucVu(ChucVu chucvu)
        {
            DBModels.Instance.ChucVus.Add(chucvu);
            int result = DBModels.Instance.SaveChanges();
            return result == 1 ? true : false;
        }

        public static bool saveChucVu(ChucVu chucvu)
        {
            ChucVu tmp = ChucVuDAO.getChucVuByID(chucvu.MaChucVu);
            //tmp.IdChuDe = sanpham.IdChuDe;
            //tmp.IdNhaSanXuat = sanpham.IdNhaSanXuat;
            tmp.TenChucVu = chucvu.TenChucVu;
            int result = DBModels.Instance.SaveChanges();
            return result == 1 ? true : false;
        }
    }
}