using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CuaHangTienLoi.Web.Models.NhaCungCapModel
{

    public class NhaCungCapDAO
    {
        public static List<NhaCungCap> getAllNhaCungCap()
        {
            List<NhaCungCap> nhacungcap = (from sx in DBModels.Instance.NhaCungCaps select sx).ToList();
            if (nhacungcap.Any())
                return nhacungcap;
            return null;
        }

        public static NhaCungCap getByIdNhaCungCap(int id)
        {
        NhaCungCap nhacungcap = (from nsx in DBModels.Instance.NhaCungCaps where nsx.MaNhaCungCap == id select nsx).FirstOrDefault();
            return nhacungcap;
        }

        public static bool saveNhaCungCap(NhaCungCap nhacungcap)
        {
            NhaCungCap tmp = NhaCungCapDAO.getByIdNhaCungCap(nhacungcap.MaNhaCungCap);
            tmp.TenNhaCungCap = nhacungcap.TenNhaCungCap;
            tmp.LienHe = nhacungcap.LienHe;
            int result = DBModels.Instance.SaveChanges();
            return result == 1 ? true : false;
        }

        public static bool remove(NhaCungCap nhacungcap)
        {
            DBModels.Instance.NhaCungCaps.Remove(nhacungcap);
            int result = DBModels.Instance.SaveChanges();
            return result == 1 ? true : false;
        }

        public static bool removeNhaCungCap(int id)
        {
            NhaCungCap rm = NhaCungCapDAO.getByIdNhaCungCap(id);
            if (remove(rm))
                return true;
            return false;
        }

        public static bool addNhaCungCap(NhaCungCap nhacungcap)
        {
            DBModels.Instance.NhaCungCaps.Add(nhacungcap);
            int result = DBModels.Instance.SaveChanges();
            return result == 1 ? true : false;
        }

    }

}