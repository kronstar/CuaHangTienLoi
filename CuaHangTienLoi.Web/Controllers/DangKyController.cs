using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CuaHangTienLoi.Web.Models.TaiKhoanModel;

namespace CuaHangTienLoi.Web.Controllers
{
    public class DangKyController : Controller
    {
        // GET: DangKy
        public ActionResult Index()
        {
            if (Request["dangky"] != null)
            {
                try
                {
                    TaiKhoan kh = new TaiKhoan();
                    kh.TenDangNhap = Request["tendangnhap"];
                    kh.MatKhau = Request["matkhau"];
                    kh.HoTen = Request["hoten"];
                    kh.NgaySinh = Convert.ToDateTime(Request["ngaysinh"]);
                    if (Request["show"] == "on")
                    {
                        kh.GioiTinh = true;
                    }
                    else
                    {
                        kh.GioiTinh = false;
                    }

                    kh.DiaChi = Request["diachi"];
                    kh.SoDienThoai = Request["sodienthoai"];
                    kh.Email = Request["email"];

                    if (Request["show1"] == "on")
                    {
                        kh.PhanQuyen = true;
                    }
                    else
                    {
                        kh.PhanQuyen = false;
                    }
                    TaiKhoanDAO.addKhachHang(kh);
                    Session["nguoidung"] = kh.TenDangNhap;
                    Response.Redirect("Home");
                }
                catch (Exception ex)
                {
                }
            }
            else { }

            return View();
        }
    }
}