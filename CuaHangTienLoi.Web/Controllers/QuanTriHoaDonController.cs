using CuaHangTienLoi.Web.Models.ChiTietHoaDonModel;
using CuaHangTienLoi.Web.Models.HoaDonModel;
using CuaHangTienLoi.Web.Models.NhanVienModel;
using CuaHangTienLoi.Web.Models.SanPhamModel;
using CuaHangTienLoi.Web.Models.TaiKhoanModel;
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
        public ActionResult HoaDon()
        {
            if (Session["nguoidung"] != null)
            {
                int mataikhoan = int.Parse(Session["mataikhoan"].ToString());
                List<HoaDon> hoadons = new List<HoaDon>();
                hoadons = HoaDonDAO.getAllHoaDonByUserId(mataikhoan);

                return View(hoadons);
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
        }

        public ActionResult EditHoaDon()
        {
            ViewBag.Shipper = NhanVienDAO.getAllShipper();

            HoaDon nsx = new HoaDon();
            if (Request["saveclose"] != null)
            {
                HoaDon tmp = new HoaDon();
                tmp.MaNhanVien = int.Parse(Request["manhanvien"]);
                tmp.MaHoaDon = int.Parse(Request["mahoadon"]);
                /*tmp.NgayDat = Convert.ToDateTime(Request["ngaydat"]);*/
                tmp.TrangThai = int.Parse(Request["trangthai"]);
                /*tmp.TongHoaDon = int.Parse(Request["tonghoadon"]);*/
                tmp.GhiChu = Request["ghichu"];
                /*tmp.HoTenNguoiMua = Request["hotennguoimua"];
                tmp.DiaChi = Request["diachi"];
                tmp.DienThoai = Request["dienthoai"];
                tmp.Email = Request["email"];*/
                tmp.TinhTrangDonHang = int.Parse(Request["tinhtrangdonhang"]);
                HoaDonDAO.saveHoaDon(tmp);
                return RedirectToAction("Index", "QuanTriHoaDon");
            }
            else if (Request["cancel"] != null)
            {
                return RedirectToAction("Index", "QuanTriHoaDon");
            }
            else
            {
                nsx = HoaDonDAO.getByIdHoaDon(int.Parse(Request.Params["t"]));
            }
            return View(nsx);
        }

        public ActionResult ChiTietHoaDon()
        {
            ViewBag.Shipper = NhanVienDAO.getAllShipper();

            HoaDon nsx = new HoaDon();
            if (Request["saveclose"] != null)
            {
                HoaDon tmp = new HoaDon();
                tmp.MaNhanVien = int.Parse(Request["manhanvien"]);
                tmp.MaHoaDon = int.Parse(Request["mahoadon"]);
                /*tmp.NgayDat = Convert.ToDateTime(Request["ngaydat"]);*/
                tmp.TrangThai = int.Parse(Request["trangthai"]);
                /*tmp.TongHoaDon = int.Parse(Request["tonghoadon"]);*/
                tmp.GhiChu = Request["ghichu"];
                /*tmp.HoTenNguoiMua = Request["hotennguoimua"];
                tmp.DiaChi = Request["diachi"];
                tmp.DienThoai = Request["dienthoai"];
                tmp.Email = Request["email"];*/
                tmp.TinhTrangDonHang = int.Parse(Request["tinhtrangdonhang"]);

                HoaDonDAO.saveHoaDon(tmp);
                return RedirectToAction("HoaDon", "QuanTriHoaDon");
            }
            else if (Request["done"] != null)
            {
                HoaDon tmp = new HoaDon();
                tmp.MaNhanVien = int.Parse(Request["manhanvien"]);
                tmp.MaHoaDon = int.Parse(Request["mahoadon"]);
                /*tmp.NgayDat = Convert.ToDateTime(Request["ngaydat"]);*/
                tmp.TrangThai = 1;
                /*tmp.TongHoaDon = int.Parse(Request["tonghoadon"]);*/
                tmp.GhiChu = Request["ghichu"];
                /*tmp.HoTenNguoiMua = Request["hotennguoimua"];
                tmp.DiaChi = Request["diachi"];
                tmp.DienThoai = Request["dienthoai"];
                tmp.Email = Request["email"];*/
                tmp.TinhTrangDonHang = 3;
                HoaDonDAO.saveHoaDon(tmp);
                return RedirectToAction("HoaDon", "QuanTriHoaDon");
            }
            else if (Request["cancelOrder"] != null)
            {
                HoaDon tmp = new HoaDon();
                /*tmp.MaNhanVien = int.Parse(Request["manhanvien"]);*/
                tmp.MaHoaDon = int.Parse(Request["mahoadon"]);
                /*tmp.NgayDat = Convert.ToDateTime(Request["ngaydat"]);*/
                tmp.TrangThai = 3;
                /*tmp.TongHoaDon = int.Parse(Request["tonghoadon"]);*/
                tmp.GhiChu = Request["ghichu"];
                /*tmp.HoTenNguoiMua = Request["hotennguoimua"];
                tmp.DiaChi = Request["diachi"];
                tmp.DienThoai = Request["dienthoai"];
                tmp.Email = Request["email"];*/
                tmp.TinhTrangDonHang = 4;
                HoaDonDAO.saveHoaDon(tmp);
                return RedirectToAction("HoaDon", "QuanTriHoaDon");
            }
            else if (Request["cancel"] != null)
            {
                return RedirectToAction("HoaDon", "QuanTriHoaDon");
            }
            else
            {
                nsx = HoaDonDAO.getByIdHoaDon(int.Parse(Request.Params["t"]));
            }
            return View(nsx);
        }
    }
} 