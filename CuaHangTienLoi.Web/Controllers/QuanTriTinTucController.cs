using CuaHangTienLoi.Web.Models.TinTucModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CuaHangTienLoi.Web.Controllers
{
    public class QuanTriTinTucController : Controller
    {
        // GET: QuanTriTinTuc
        public ActionResult Index()
        {
            

            if (Session["nguoidung"] != null)
            {
                List<TinTuc> tintuc = new List<TinTuc>();
                tintuc = TinTucDAO.getAllTinTuc();
                return View(tintuc);
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
        }

        public ActionResult EditTinTuc()
        {
            TinTuc nsx = new TinTuc();
            if (Request["saveclose"] != null)
            {
                TinTuc tmp = new TinTuc();
                /*tmp.MaTaiKhoan = Int32.Parse(Request["nguoidung"]);*/
                tmp.MaTin = Int32.Parse(Request["matin"]);
                tmp.TieuDe = Request["tieude"];
                tmp.NoiDung = Request["noidung"];
                tmp.NgayDang = DateTime.Now;
                TinTucDAO.saveTinTuc(tmp);
                return RedirectToAction("Index", "QuanTriTinTuc");
            }
            else if (Request["cancel"] != null)
            {
                return RedirectToAction("Index", "QuanTriTinTuc");
            }
            else
            {
                nsx = TinTucDAO.getByIdTinTuc(int.Parse(Request.Params["t"]));
            }
            return View(nsx);
        }


        public ActionResult DeleteTinTuc()
        {
            TinTucDAO.removeTinTuc(int.Parse(Request.Params["t"]));
            return RedirectToAction("Index", "QuanTriTinTuc");
        }

        public ActionResult CreateTinTuc()
        {
            if (Request["save"] != null)
            {
                TinTuc nsx = new TinTuc();
                nsx.TieuDe = Request["tieude"];
                nsx.NoiDung = Request["noidung"];
                nsx.NgayDang = DateTime.Now;
                TinTucDAO.addTinTuc(nsx);
            }
            else if (Request["saveclose"] != null)
            {
                TinTuc nsx = new TinTuc();
                nsx.TieuDe = Request["tieude"];
                nsx.NoiDung = Request["noidung"];
                nsx.NgayDang = DateTime.Now;
                TinTucDAO.addTinTuc(nsx);
                Response.Redirect("index");
            }
            else if (Request["cancel"] != null)
            {
                Response.Redirect("index");
            }
            return View();
        }
    }
}