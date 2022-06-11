using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CuaHangTienLoi.Web.Models.SanPhamModel;

namespace CuaHangTienLoi.Web.Controllers
{
    public class ChiTietSanPhamController : Controller
    {
        // GET: ChiTietSanPham
        public ActionResult Index()
        {
            SanPham sanpham = new SanPham();

            if (Request.Params["sp"] != null)
            {
                sanpham = SanPhamDAO.getSanPhamByID(int.Parse(Request.Params["sp"]));

            }
            return View(sanpham);
        }
    }
}