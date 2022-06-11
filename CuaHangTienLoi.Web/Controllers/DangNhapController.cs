using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CuaHangTienLoi.Web.Models.TaiKhoanModel;

namespace CuaHangTienLoi.Web.Controllers
{
    public class DangNhapController : Controller
    {
        // GET: DangNhap
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult DangNhapKH()
        {
            TaiKhoan khs = new TaiKhoan();
            try
            {
                if (Request["btndangnhap"] != null)
                {

                    string tendn = Request["tendangnhap"];
                    string matkhau = Request["matkhau"];
                    khs = TaiKhoanDAO.getUserByTenDangNhapAndMatKhau(tendn, matkhau);
                    if (khs != null)
                    {
                        Session["nguoidung"] = khs.TenDangNhap;
                        return RedirectToAction("Index", "ThanhToan");
                    }
                    else
                    {

                        return RedirectToAction("Index", "Home");
                    }

                }
                else
                {
                    return RedirectToAction("Index", "Home");
                }
            }
            catch (Exception ex)
            {
                return Json(new { error = ex.Message });
            }
        }
    }
}