using CuaHangTienLoi.Web.Models.DanhMucModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CuaHangTienLoi.Web.Controllers
{
    public class QuanTriDanhMucController : Controller
    {
        // GET: QuanTriDanhMuc
        public ActionResult Index()
        {
            if (Session["nguoidung"] != null)
            {
                List<DanhMuc> danhmuc = new List<DanhMuc>();

                danhmuc = DanhMucDAO.getAllDanhMucs();

                return View(danhmuc);
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
        }

        public ActionResult EditDanhMuc()
        {
            if (Session["nguoidung"] != null)
            {
                DanhMuc cd = new DanhMuc();

                if (Request["saveclose"] != null)
                {
                    DanhMuc tmp = new DanhMuc();
                    tmp.MaDanhMuc = int.Parse(Request["madanhmuc"]);
                    tmp.TenDanhMuc = Request["tendanhmuc"];
                    tmp.Stt = 0;
                    if (Request["show"] == "on")
                    {
                        tmp.TrangThai = true;
                    }
                    else
                    {
                        tmp.TrangThai = false;
                    }

                    DanhMucDAO.saveDanhMuc(tmp);
                    return RedirectToAction("Index", "QuanTriDanhMuc");
                }
                else if (Request["cancel"] != null)
                {
                    return RedirectToAction("Index", "QuanTriDanhMuc");
                }
                else
                {
                    cd = DanhMucDAO.getByIdDanhMuc(int.Parse(Request.Params["t"]));
                }
                return View(cd);
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }

            
        }
        public ActionResult CreateDanhMuc()
        {
            if (Session["nguoidung"] != null)
            {
                if (Request["save"] != null)
                {
                    DanhMuc cd = new DanhMuc();
                    cd.TenDanhMuc = Request["tendanhmuc"];
                    cd.Stt = 0;
                    if (Request["show"] == "on")
                    {
                        cd.TrangThai = true;
                    }
                    else
                    {
                        cd.TrangThai = false;
                    }

                    DanhMucDAO.addDanhMuc(cd);
                }
                else if (Request["saveclose"] != null)
                {
                    DanhMuc cd = new DanhMuc();
                    cd.TenDanhMuc = Request["tendanhmuc"];
                    cd.Stt = 0;
                    if (Request["show"] == "on")
                    {
                        cd.TrangThai = true;
                    }
                    else
                    {
                        cd.TrangThai = false;
                    }

                    DanhMucDAO.addDanhMuc(cd);
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
        public ActionResult DeleteDanhMuc()
        {
            DanhMucDAO.removeDanhMuc(int.Parse(Request.Params["t"]));
            return RedirectToAction("Index", "QuanTriDanhMuc");
        }
    }
}