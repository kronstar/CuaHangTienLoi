using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CuaHangTienLoi.Web.Models;
using CuaHangTienLoi.Web.Models.SanPhamModel;
using CuaHangTienLoi.Web.Models.SliderModel;
using CuaHangTienLoi.Web.Models.DanhMucModel;
using CuaHangTienLoi.Web.Models.TaiKhoanModel;
using CuaHangTienLoi.Web.Models.CartModel;

namespace CuaHangTienLoi.Web.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            List<SanPham> sanphams = new List<SanPham>();

            sanphams = SanPhamDAO.getAllSanPham();

            if (sanphams == null)
            {
                return View();
            }
            else
            {
                sanphams = SanPhamDAO.getAllSanPham().Take(2).ToList();

                ViewBag.SPNB = SanPhamDAO.getAllSanPhamNoiBat().Take(3).OrderByDescending(p => p.LuotMua);

                ViewBag.SPK = SanPhamDAO.getAllSanPham().Skip(6).Take(3);

                ViewBag.Slide = SliderDAO.getAllSlide();
                return View(sanphams);
            }
        }
        [ChildActionOnly]
        public ActionResult Menu()
        {
            string str = "";
            List<DanhMuc> chudes = new List<DanhMuc>();
            chudes = DanhMucDAO.getAllDanhMuc();

            /*foreach (var menu in chudes)
            {
                str += "<a class='dropdown-item' href='/sanpham/index?sp=" + menu.MaDanhMuc + "'>" + menu.TenDanhMuc;
                List<DanhMuc> tmp = new List<DanhMuc>();
                *//*tmp = DanhMucDAO.getByIdParenDanhMuc(menu.MaDanhMuc);*/
                /*if (chudes.Count > 0)
                {
                    str += "<ul>";
                    foreach (var i in chudes)
                    {
                        str += "<li><a href='/sanpham/index?sp=" + i.MaDanhMuc + "'>" + i.TenDanhMuc + "</a></li>";
                    }
                    str += "</ul>";
                }*//*
                str += "</a>";

            }
            //ViewBag.Menu = str;*/
            return this.PartialView("Menu", str);
        }

        public ActionResult DangNhap()
        {
            TaiKhoan taikhoan = new TaiKhoan();
            try
            {
                if (Request["btndangnhap"] != null)
                {

                    string tendangnhap = Request["tendangnhap"];
                    string matkhau = Request["matkhau"];
                    taikhoan = TaiKhoanDAO.getUserByTenDangNhapAndMatKhau(tendangnhap, matkhau);
                    if (taikhoan != null)
                    {
                        Session["nguoidung"] = taikhoan.TenDangNhap;
                        Session["mataikhoan"] = taikhoan.MaTaiKhoan;
                        return RedirectToAction("Index", "Home");
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

        public ActionResult DangKy()
        {
            try
            {
                if (Request["dangky"] != null)
                {
                    try
                    {
                        TaiKhoan kh = new TaiKhoan();
                        kh.TenDangNhap = Request["tendangnhapdangky"];
                        kh.MatKhau = Request["matkhaudangky"];
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
                    }
                    catch (Exception ex)
                    {
                        return Json(new { error = ex.Message });
                    }
                }
                else { }
            }
            catch (Exception ex)
            {
                return Json(new { error = ex.Message });
            }

            return RedirectToAction("Index", "Home");
        }

        public ActionResult DangXuat()
        {
            Session["nguoidung"] = null;
            return RedirectToAction("Index", "Home");
        }
        [ChildActionOnly]
        public ActionResult CartItem()
        {
            string str = "";
            CartModel model = new CartModel();
            model.Cart = (Cart)Session["Cart"];
            if (model.Cart != null)
            {
                str += "<div class='dropdown-menu cart-dropdown dropdown-menu-right' style='min-width:300px;'>";
                foreach (var item in model.Cart.ListItem)
                {
                    str += "<div class='media'>";
                    str += "<a class='pull-left' href='#!'>";
                    str += "<img class='media-object'src='/Content/img/product/" + @item.AnhSanPham + "' alt='image'/>";
                    str += "</a>";
                    str += "<div class='media-body'>";
                    str += "<h4 class='media-heading'>";
                    str += "<a href='/Chitietsanpham/index?sp=" + item.MaGioHang + "'> " + @item.TenSanPham + "</a>";
                    str += "</h4>";
                    str += "<div class='cart-price'>";
                    str += "<span>" + @item.SoLuong + " x </span>";
                    str += "<span>"+ @item.DonGia.ToString("N0") + "&nbsp;VNĐ" + "</span>";
                    str += "</div>";
                    str += "<h5><strong>" + @item.TongDon.ToString("N0") + "&nbsp;VNĐ" + "</strong></h5>";
                    str += "</div>";
                    str += "</div>";
                    str += "<div class='cart-summary'>";
                    /*str += "<span>Tổng cộng</span>";
                    str += "<span class='total-price'>43.000 VNĐ</span>";*/
                    str += "</div>";
                }
                str += "</div>";
            }
            else
            {

            }
            return this.PartialView("CartItem", str);
        }

        public ActionResult DonHang()
        {
            return View();
        }
    }
}