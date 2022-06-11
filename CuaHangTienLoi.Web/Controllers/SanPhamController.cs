using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CuaHangTienLoi.Web.Models.SanPhamModel;
using CuaHangTienLoi.Web.Models.DanhMucModel;

namespace CuaHangTienLoi.Web.Controllers
{
    public class SanPhamController : Controller
    {
        // GET: SanPham
        public ActionResult Index()
        {
            List<SanPham> sanphams = new List<SanPham>();
            sanphams = SanPhamDAO.getAllSanPham();
            return View(sanphams);
        }
    }
}