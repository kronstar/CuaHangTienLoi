using CuaHangTienLoi.Web.Models.TaiKhoanModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CuaHangTienLoi.Web.Controllers
{
    public class QuanTriKhachHangController : Controller
    {
        // GET: QuanTriKhachHang
        public ActionResult Index()
        {
            

            if (Session["nguoidung"] != null)
            {
                List<TaiKhoan> khachhangs = new List<TaiKhoan>();
                khachhangs = TaiKhoanDAO.getAllUser();
                return View(khachhangs);
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
        }
    }
}