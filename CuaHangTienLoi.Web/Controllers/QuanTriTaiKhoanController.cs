using CuaHangTienLoi.Web.Models.TaiKhoanModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CuaHangTienLoi.Web.Controllers
{
    public class QuanTriTaiKhoanController : Controller
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

        public ActionResult EditTaiKhoan()
        {
            TaiKhoan nsx = new TaiKhoan();
            if (Request["saveclose"] != null)
            {
                TaiKhoan tmp = new TaiKhoan();
                tmp.MaTaiKhoan = int.Parse(Request["mataikhoan"]);
                tmp.TenDangNhap = Request["tendangnhap"];
                tmp.MatKhau = Request["matkhau"];
                tmp.HoTen = Request["hoten"];
                tmp.PhanQuyen = Convert.ToBoolean(Request["phanquyen"]);
                tmp.DiaChi = Request["diachi"];
                tmp.SoDienThoai = Request["sodienthoai"];
                tmp.Email = Request["email"];
                tmp.NgaySinh = Convert.ToDateTime(Request["ngaysinh"]);
                tmp.GioiTinh = Convert.ToBoolean(Request["gioitinh"]);
                TaiKhoanDAO.saveKhachHang(tmp);
                return RedirectToAction("Index", "QuanTriTaiKhoan");
            }
            else if (Request["cancel"] != null)
            {
                return RedirectToAction("Index", "QuanTriTaiKhoan");
            }
            else
            {
                nsx = TaiKhoanDAO.getUserById(int.Parse(Request.Params["t"]));
            }
            return View(nsx);
        }
    }
}