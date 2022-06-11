using CuaHangTienLoi.Web.Models.NhaCungCapModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CuaHangTienLoi.Web.Controllers
{
    public class QuanTriNhaCungCapController : Controller
    {
        // GET: QuanTriNhaCungCap
        public ActionResult Index()
        {
            if (Session["nguoidung"] != null)
            {
                List<NhaCungCap> nhacungcap = new List<NhaCungCap>();
                nhacungcap = NhaCungCapDAO.getAllNhaCungCap();
                return View(nhacungcap);
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
        }

        public ActionResult EditNhaCungCap()
        {
            NhaCungCap nsx = new NhaCungCap();
            if (Request["saveclose"] != null)
            {
                NhaCungCap tmp = new NhaCungCap();
                tmp.MaNhaCungCap = int.Parse(Request["mancc"]);
                tmp.TenNhaCungCap = Request["tenncc"];
                tmp.LienHe = Request["lienhe"];
                NhaCungCapDAO.saveNhaCungCap(tmp);
                return RedirectToAction("Index", "QuanTriNhaCungCap");
            }
            else if (Request["cancel"] != null)
            {
                return RedirectToAction("Index", "QuanTriNhaCungCap");
            }
            else
            {
                nsx = NhaCungCapDAO.getByIdNhaCungCap(int.Parse(Request.Params["t"]));
            }
            return View(nsx);
        }


        public ActionResult DeleteNhaCungCap()
        {
            NhaCungCapDAO.removeNhaCungCap(int.Parse(Request.Params["t"]));
            return RedirectToAction("Index", "QuanTriNhaCungCap");
        }

        public ActionResult CreateNhaCungCap()
        {
            if (Request["save"] != null)
            {
                NhaCungCap nsx = new NhaCungCap();
                nsx.TenNhaCungCap = Request["tenncc"];
                nsx.LienHe = Request["lienhe"];
                NhaCungCapDAO.addNhaCungCap(nsx);
            }
            else if (Request["saveclose"] != null)
            {
                NhaCungCap nsx = new NhaCungCap();
                nsx.TenNhaCungCap = Request["tennsx"];
                nsx.LienHe = Request["lienhe"];
                NhaCungCapDAO.addNhaCungCap(nsx);
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