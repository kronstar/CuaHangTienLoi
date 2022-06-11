using CuaHangTienLoi.Web.Models.HoaDonModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CuaHangTienLoi.Web.Controllers
{
    public class QuanTriHoaDonController : Controller
    {
        // GET: QuanTriHoaDon
        public ActionResult Index()
        {
            

            if (Session["nguoidung"] != null)
            {
                List<HoaDon> hoadons = new List<HoaDon>();
                hoadons = HoaDonDAO.getAllHoaDon();
                return View(hoadons);
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
        }
    }
}