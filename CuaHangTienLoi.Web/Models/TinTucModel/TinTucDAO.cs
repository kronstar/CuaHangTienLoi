using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CuaHangTienLoi.Web.Models.TinTucModel
{
    public class TinTucDAO
    {

        public static List<TinTuc> getAllTinTuc()
        {
            List<TinTuc> tintucs = (from sp in DBModels.Instance.TinTucs select sp).ToList();
            if (tintucs.Any())
                return tintucs;
            return null;
        }

        public static TinTuc getByIdTinTuc(int id)
        {
            TinTuc tintucs = (from nsx in DBModels.Instance.TinTucs where nsx.MaTin == id select nsx).FirstOrDefault();
            return tintucs;
        }

        public static bool saveTinTuc(TinTuc tintucs)
        {
            TinTuc tmp = TinTucDAO.getByIdTinTuc(tintucs.MaTin);
            tmp.TieuDe = tintucs.TieuDe;
            tmp.NoiDung = tintucs.NoiDung;
            tmp.NgayDang = DateTime.Now;
            int result = DBModels.Instance.SaveChanges();
            return result == 1 ? true : false;
        }

        public static bool remove(TinTuc tintucs)
        {
            DBModels.Instance.TinTucs.Remove(tintucs);
            int result = DBModels.Instance.SaveChanges();
            return result == 1 ? true : false;
        }

        public static bool removeTinTuc(int id)
        {
            TinTuc rm = TinTucDAO.getByIdTinTuc(id);
            if (remove(rm))
                return true;
            return false;
        }

        public static bool addTinTuc(TinTuc tintucs)
        {
            DBModels.Instance.TinTucs.Add(tintucs);
            int result = DBModels.Instance.SaveChanges();
            return result == 1 ? true : false;
        }
    }
}