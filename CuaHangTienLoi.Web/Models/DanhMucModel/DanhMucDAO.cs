using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CuaHangTienLoi.Web.Models.DanhMucModel
{
    public class DanhMucDAO
    {
        public static List<DanhMuc> getAllDanhMuc()
        {
            List<DanhMuc> danhmuc = (from cd in DBModels.Instance.DanhMucs where cd.TrangThai == true select cd).OrderBy(p => p.Stt).ToList();
            if (danhmuc.Any())
                return danhmuc;
            return null;
        }

        public static List<DanhMuc> getAllDanhMucs()
        {
            List<DanhMuc> danhmuc = (from cd in DBModels.Instance.DanhMucs select cd).OrderBy(p => p.Stt).ToList();
            if (danhmuc.Any())
                return danhmuc;
            return null;
        }

        public static DanhMuc getByIdDanhMuc(int id)
        {
            DanhMuc danhmuc = (from cd in DBModels.Instance.DanhMucs where cd.MaDanhMuc == id select cd).FirstOrDefault();
            return danhmuc;
        }
        public static List<DanhMuc> getAllByIdDanhMuc(int id)
        {
            List<DanhMuc> danhmuc = (from cd in DBModels.Instance.DanhMucs where cd.MaDanhMuc == id select cd).ToList();
            return danhmuc;
        }

        public static bool addDanhMuc(DanhMuc danhmuc)
        {
            DBModels.Instance.DanhMucs.Add(danhmuc);
            int result = DBModels.Instance.SaveChanges();
            return result == 1 ? true : false;

        }

        public static bool saveDanhMuc(DanhMuc danhmuc)
        {
            DanhMuc tmp = DanhMucDAO.getByIdDanhMuc(danhmuc.MaDanhMuc);
            tmp.TenDanhMuc = danhmuc.TenDanhMuc;
            tmp.Stt = danhmuc.Stt;
            tmp.TrangThai = danhmuc.TrangThai;
            int result = DBModels.Instance.SaveChanges();
            return result == 1 ? true : false;

        }

        public static bool Remove(DanhMuc danhmuc)
        {
            DBModels.Instance.DanhMucs.Remove(danhmuc);
            int result = DBModels.Instance.SaveChanges();
            return result == 1 ? true : false;
        }

        public static bool removeDanhMuc(int id)
        {
            DanhMuc rm = DanhMucDAO.getByIdDanhMuc(id);
            if (Remove(rm))
                return true;
            return false;

        }

    }
}