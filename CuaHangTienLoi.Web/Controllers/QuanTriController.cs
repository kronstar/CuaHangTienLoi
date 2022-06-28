using CuaHangTienLoi.Web.Models.DanhMucModel;
using CuaHangTienLoi.Web.Models.HoaDonModel;
using CuaHangTienLoi.Web.Models.NhanVienModel;
using CuaHangTienLoi.Web.Models.SanPhamModel;
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
            ViewBag.TongHoaDon = HoaDonDAO.getTongHoaDon();
            ViewBag.DatHangThanhCong = HoaDonDAO.getDatHangThanhCong();
            ViewBag.DangGiaoHang = HoaDonDAO.getDangGiaoHang();
            ViewBag.HoanThanh = HoaDonDAO.getHoanThanh();
            ViewBag.DaHuy = HoaDonDAO.getDaHuy();

            ViewBag.TongDoanhThuHienTai = HoaDonDAO.getTongDoanhThuHienTai();
            ViewBag.TongDoanhThuDuKien = HoaDonDAO.getTongDoanhThuDuKien();
            ViewBag.TongDoanhThuThangNay = HoaDonDAO.getTongDoanhThuThangNay();
            ViewBag.TongDoanhThuThangNayDuKien = HoaDonDAO.getTongDoanhThuThangNayDuKien();
            ViewBag.TongDoanhThuChoVeThangNay = HoaDonDAO.getTongDoanhThuChoVeThangNay();

            ViewBag.NhanVien = NhanVienDAO.countNhanVien();
            ViewBag.TongLuong = NhanVienDAO.tinhTongLuong();

            ViewBag.TongSanPham = SanPhamDAO.countAllSanPham();

            ViewBag.DoanhThu = ViewBag.TongDoanhThuThangNay - ViewBag.TongLuong;

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