using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CuaHangTienLoi.Web.Models.ChiTietHoaDonModel
{
    public class ChiTietHoaDonDAO
    {
        public static bool addCTHoaDon(ChiTietHoaDon CTHoaDon)
        {
            DBModels.Instance.ChiTietHoaDons.Add(CTHoaDon);
            int result = DBModels.Instance.SaveChanges();
            return result == 1 ? true : false;
        }
    }
}