using CuaHangTienLoi.Web.Models.DanhMucModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CuaHangTienLoi.Web.Controllers
{
    public class QuanTriController : Controller
    {
        // GET: QuanTri
        public ActionResult Index()
        {
            List<DanhMuc> danhmuc = new List<DanhMuc>();
            if (Session["nguoidung"] != null)
            {
                if (Request["add"] != null)
                {
                    return RedirectToAction("CreateChude", "QuanTri");
                }
                else
                {
                    danhmuc = DanhMucDAO.getAllDanhMuc();
                }
                return View(danhmuc);
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
        }
    }
}