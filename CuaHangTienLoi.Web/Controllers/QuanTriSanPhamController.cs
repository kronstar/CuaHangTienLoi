using CuaHangTienLoi.Web.Models.DanhMucModel;
using CuaHangTienLoi.Web.Models.NhaCungCapModel;
using CuaHangTienLoi.Web.Models.SanPhamModel;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CuaHangTienLoi.Web.Controllers
{
    public class QuanTriSanPhamController : Controller
    {
        // GET: QuanTriSanPham
        public ActionResult Index()
        {
            if (Session["nguoidung"] != null)
            {
                List<SanPham> sanphams = new List<SanPham>();
                sanphams = SanPhamDAO.getAllSanPham();
                return View(sanphams);
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
        }

        public ActionResult CreateSanPham()
        {
            if (Session["nguoidung"] != null)
            {
                ViewBag.TenDanhMuc = DanhMucDAO.getAllDanhMucs();
                ViewBag.TenNhaCungCap = NhaCungCapDAO.getAllNhaCungCap();

                HttpPostedFileBase myFile = Request.Files["file"];
                if (Request["save"] != null)
                {
                    SanPham sp = new SanPham();
                    sp.MaDanhMuc = int.Parse(Request["ddlChudeSanpham"]);
                    sp.MaNhaCungCap = int.Parse(Request["ddlNhaSanXuat"]);
                    sp.TenSanPham = Request["tensanpham"];
                    if (Request["show"] == "on")
                    {
                        sp.TinhTrang = true;
                    }
                    else
                    {
                        sp.TinhTrang = false;
                    }
                    if (myFile == null || myFile.ContentLength == 0)
                    {
                        sp.LinkAnh = Request["linkduongdanslide"];
                    }
                    else
                    {

                        string filename = DateTime.Now.Day + "" + DateTime.Now.Month + "" + DateTime.Now.Year + "" + DateTime.Now.Hour + "" + DateTime.Now.Minute + "" + DateTime.Now.Second + "" + DateTime.Now.Millisecond + Path.GetExtension(myFile.FileName);
                        var path = Path.Combine(Server.MapPath("~/Content/img/product/"), filename);

                        myFile.SaveAs(path);
                        sp.LinkAnh = filename;
                    }
                    string detail = Request["txtDetail"];
                    sp.MoTa = detail;
                    sp.DonGia = int.Parse(Request["dongia"]);
                    sp.GiamGia = int.Parse(Request["giamgia"]);
                    sp.PhanTramGiamGia = int.Parse(Request["sale"]);
                    sp.LuotMua = int.Parse(Request["luotmua"]);
                    sp.NgayDang = DateTime.Now;
                    sp.SoLuong = int.Parse(Request["soluong"]);
                    if (Request["show"] == "on")
                    {
                        sp.DaXoa = true;
                    }
                    else
                    {
                        sp.DaXoa = false;
                    }
                    SanPhamDAO.addSanPham(sp);
                }
                else if (Request["saveclose"] != null)
                {
                    SanPham sp = new SanPham();
                    sp.MaDanhMuc = int.Parse(Request["ddlChudeSanpham"]);
                    sp.MaNhaCungCap = int.Parse(Request["ddlNhaSanXuat"]);
                    sp.TenSanPham = Request["tensanpham"];
                    if (Request["show"] == "on")
                    {
                        sp.TinhTrang = true;
                    }
                    else
                    {
                        sp.TinhTrang = false;
                    }
                    if (myFile == null || myFile.ContentLength == 0)
                    {
                        sp.LinkAnh = Request["linkduongdanslide"];
                    }
                    else
                    {

                        string filename = DateTime.Now.Day + "" + DateTime.Now.Month + "" + DateTime.Now.Year + "" + DateTime.Now.Hour + "" + DateTime.Now.Minute + "" + DateTime.Now.Second + "" + DateTime.Now.Millisecond + Path.GetExtension(myFile.FileName);
                        var path = Path.Combine(Server.MapPath("~/Content/img/product/"), filename);

                        myFile.SaveAs(path);
                        sp.LinkAnh = filename;
                    }
                    string detail = Request["txtDetail"];
                    sp.MoTa = detail;
                    sp.DonGia = int.Parse(Request["dongia"]);
                    sp.GiamGia = int.Parse(Request["giamgia"]);
                    sp.PhanTramGiamGia = int.Parse(Request["sale"]);
                    sp.LuotMua = int.Parse(Request["luotmua"]);
                    sp.NgayDang = DateTime.Now;
                    if (Request["show"] == "on")
                    {
                        sp.DaXoa = true;
                    }
                    else
                    {
                        sp.DaXoa = false;
                    }
                    sp.SoLuong = int.Parse(Request["soluong"]);
                    SanPhamDAO.addSanPham(sp);
                    Response.Redirect("index");
                }
                else if (Request["cancel"] != null)
                {
                    return RedirectToAction("Index", "QuanTriSanPham");
                }
                else { }
                return View();
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }

            
        }

        public ActionResult EditSanPham()
        {
            //ViewBag.Tenchude = ChuDeService.getAllChuDes();
            //ViewBag.Nhasanxuat = NhaSanXuaService.getAllnhasanxuat();
            //ViewBag.Mausac = MauSacSanPhamService.getAllMausacSanpham();
            //ViewBag.Kichthuoc = KichThuocService.getAllkichthuoc();

            if (Session["nguoidung"] != null)
            {
                HttpPostedFileBase myFile = Request.Files["file"];

                SanPham sp = new SanPham();
                if (Request["saveclose"] != null)
                {
                    SanPham tmp = new SanPham();
                    tmp.MaSanPham = Int32.Parse(Request["masanpham"]);
                    tmp.TenSanPham = Request["tensanpham"];
                    if (Request["show"] == "on")
                    {
                        tmp.TinhTrang = true;
                    }
                    else
                    {
                        tmp.TinhTrang = false;
                    }
                    if (myFile == null || myFile.ContentLength == 0)
                    {
                        tmp.LinkAnh = Request["linkduongdanslide"];
                    }
                    else
                    {

                        string filename = DateTime.Now.Day + "" + DateTime.Now.Month + "" + DateTime.Now.Year + "" + DateTime.Now.Hour + "" + DateTime.Now.Minute + "" + DateTime.Now.Second + "" + DateTime.Now.Millisecond + Path.GetExtension(myFile.FileName);
                        var path = Path.Combine(Server.MapPath("~/Content/img/product"), filename);

                        myFile.SaveAs(path);
                        tmp.LinkAnh = filename;
                    }
                    string detail = Request["txtDetail"];
                    tmp.MoTa = detail;
                    tmp.DonGia = Int32.Parse(Request["dongia"]);
                    tmp.GiamGia = Int32.Parse(Request["giamgia"]);
                    tmp.PhanTramGiamGia = Int32.Parse(Request["sale"]);
                    tmp.LuotMua = Int32.Parse(Request["luotmua"]);
                    tmp.NgayDang = DateTime.Now;
                    if (Request["show"] == "on")
                    {
                        tmp.DaXoa = true;
                    }
                    else
                    {
                        tmp.DaXoa = false;
                    }
                    tmp.SoLuong = Int32.Parse(Request["soluong"]);
                    SanPhamDAO.saveSanPham(tmp);
                    return RedirectToAction("Index", "QuanTriSanPham");
                }
                else if (Request["cancel"] != null)
                {
                    return RedirectToAction("Index", "QuanTriSanPham");
                }
                else
                {
                    sp = SanPhamDAO.getSanPhamByID(int.Parse(Request.Params["t"]));
                }

                return View(sp);
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }

            
        }

        public ActionResult DeleteSanPham()
        {
            SanPhamDAO.removeSanpham(int.Parse(Request.Params["t"]));
            return RedirectToAction("Index", "QuanTriSanPham");
        }
    }
}