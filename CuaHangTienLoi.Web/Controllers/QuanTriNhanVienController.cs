using CuaHangTienLoi.Web.Models.ChucVuModel;
using CuaHangTienLoi.Web.Models.NhanVienModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CuaHangTienLoi.Web.Controllers
{
    public class QuanTriNhanVienController : Controller
    {
        // GET: QuanTriDanhMuc
        public ActionResult Index()
        {
            ViewBag.TenChucVu = ChucVuDAO.getAllChucVu();
            if (Session["nguoidung"] != null)
            {
                List<NhanVien> danhmuc = new List<NhanVien>();

                danhmuc = NhanVienDAO.getAllNhanVien();

                return View(danhmuc);
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
        }
        public ActionResult EditNhanVien()
        {
            ViewBag.TenChucVu = ChucVuDAO.getAllChucVu();
            if (Session["nguoidung"] != null)
            {
                NhanVien cd = new NhanVien();

                if (Request["saveclose"] != null)
                {
                    NhanVien tmp = new NhanVien();
                    tmp.MaNhanVien = int.Parse(Request["manhanvien"]);
                    tmp.MaChucVu = int.Parse(Request["machucvu"]);
                    tmp.HoTen = Request["hoten"];
                    tmp.SoDienThoai = Request["sodienthoai"];
                    tmp.DiaChi = Request["diachi"];
                    tmp.NgaySinh = Convert.ToDateTime(Request["ngaysinh"]);
                    tmp.GioiTinh = Convert.ToBoolean(Request["gioitinh"]);
                    tmp.NgayThamGia = Convert.ToDateTime(Request["ngaythamgia"]);
                    tmp.Luong = Int32.Parse(Request["luong"]);

                    NhanVienDAO.saveNhanVien(tmp);
                    return RedirectToAction("Index", "QuanTriNhanVien");
                }
                else if (Request["cancel"] != null)
                {
                    return RedirectToAction("Index", "QuanTriNhanVien");
                }
                else
                {
                    cd = NhanVienDAO.getNhanVienByID(int.Parse(Request.Params["t"]));
                }
                return View(cd);
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }


        }
        public ActionResult CreateNhanVien()
        {
            ViewBag.TenChucVu = ChucVuDAO.getAllChucVu();
            if (Session["nguoidung"] != null)
            {
                if (Request["save"] != null)
                {
                    NhanVien cd = new NhanVien();
                    cd.MaChucVu = int.Parse(Request["machucvu"]);
                    cd.HoTen = Request["hoten"];
                    cd.SoDienThoai = Request["sodienthoai"];
                    cd.DiaChi = Request["diachi"];
                    cd.NgaySinh = Convert.ToDateTime(Request["ngaysinh"]);
                    cd.GioiTinh = Convert.ToBoolean(Request["gioitinh"]);
                    cd.NgayThamGia = DateTime.Now;
                    cd.Luong = Int32.Parse(Request["luong"]);

                    NhanVienDAO.addNhanVien(cd);
                }
                else if (Request["saveclose"] != null)
                {
                    NhanVien cd = new NhanVien();
                    cd.MaChucVu = int.Parse(Request["machucvu"]);
                    cd.HoTen = Request["hoten"];
                    cd.SoDienThoai = Request["sodienthoai"];
                    cd.DiaChi = Request["diachi"];
                    cd.NgaySinh = Convert.ToDateTime(Request["ngaysinh"]);
                    if (Request["show"] == "on")
                    {
                        cd.GioiTinh = true;
                    }
                    else
                    {
                        cd.GioiTinh = false;
                    }
                    cd.NgayThamGia = DateTime.Now;
                    cd.Luong = Int32.Parse(Request["luong"]);

                    NhanVienDAO.addNhanVien(cd);
                    Response.Redirect("Index");
                }
                else if (Request["cancel"] != null)
                {
                    Response.Redirect("Index");
                }
                return View();
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }


        }
        public ActionResult DeleteNhanVien()
        {
            NhanVienDAO.removeNhanVien(int.Parse(Request.Params["t"]));
            return RedirectToAction("Index", "QuanTriNhanVien");
        }
    }
}